using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Dir
{
    East,
    West,
    South,
    North,
}
public class GhostSpawer : MonoBehaviour
{
    [SerializeField]
    private GameObject ghost;

    private Dir dir;
    private Vector3 ghostSpawnPosition;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private int randNum;

    private Vector3[][] g_pos;
     
    // [동/서/남/북][0번째 고스트 위치 어디어디어디] -> 9.5 / 0.5 / 10.5
    //              [1번째 고스트 위치 어디어디어디] -> 9.5 / 0.5 / 5.5
    void Awake()
    {
        ghostSpawnPosition = new Vector3(10.5f, 0.5f, 11.5f);

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 0)
                {
                    g_pos[i][j] = new Vector3(ghostSpawnPosition.x, ghostSpawnPosition.y, (ghostSpawnPosition.z - 5 * j));
                }
                else if (i == 1)
                {
                    g_pos[i][j] = new Vector3(ghostSpawnPosition.x - 5 * j, ghostSpawnPosition.y,ghostSpawnPosition.z);
                }
                else if (i == 2)
                {
                    g_pos[i][j] = new Vector3(ghostSpawnPosition.x, ghostSpawnPosition.y, (ghostSpawnPosition.z + 5 * j));
                }
                else
                {
                    g_pos[i][j] = new Vector3(ghostSpawnPosition.x + 5 * j, ghostSpawnPosition.y, ghostSpawnPosition.z);
                }
            }
        }           
    }

    //private Vector3[/*여기에 랜덤 값이 들어가고 (*/][/*여기에 0~4 값이 들어가니까 이것만 인자로 받는 함수를 쓰면 간단해지겠죠*/] g_pos =
    //    {
    //        // 직접 사용하시거나
    //        // 아ㅣ면 Awake에서 동적으로 미리 만들어 두고 사용하면 lookup 테이블 형식이라,
    //        // 이렇게 하면 함수로 빼서 Switch-case 문도 사라지게 됩니다
    //    };
    //함수에서는
    public void RandomNum()
    {
        randNum = Random.Range(0, 4); // 난수 생성
        SetGhost(randNum); //이러면 Switch-case 사라짐!
    }
    private void SetGhost(int randNum)
    {
        foreach (Vector3 pos in g_pos[randNum])
        {
            
            Instantiate(ghost, pos, Quaternion.identity);
        }
    }
}

// 리팩토링 할 때 대리자 이벤트
// float 이중배열




