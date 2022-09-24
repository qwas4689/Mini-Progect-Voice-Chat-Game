using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Dir
{
    East,
    West,
    South,
    North,
    Dir_Max
}
public class GhostSpawer : MonoBehaviour
{
    [SerializeField]
    private GameObject ghost;
    public float delay;
    public float mapSize;

    private Dir dir;
    public int randNum;

    private Vector3[][] g_pos;
     
    // [동/서/남/북][0번째 고스트 위치 어디어디어디] -> 9.5 / 0.5 / 10.5
    //              [1번째 고스트 위치 어디어디어디] -> 9.5 / 0.5 / 5.5
    private void Awake()
    {
        Ghost.Spawner = this;

        g_pos = new Vector3[(int)Dir.Dir_Max][];

        for (int i = 0; i < 4; i++)
        {
            g_pos[i] = new Vector3[5];
            for (int j = 0; j < 5; j++)
            {
                if (i == 0)
                {
                    g_pos[i][j] = new Vector3(9.5f - 5 * j, 0.5f, -9.5f);   // 남쪽
                }
                else if (i == 1)
                {
                    g_pos[i][j] = new Vector3(-10.5f, 0.5f, -9.5f + 5 * j);  // 서쪽
                }
                else if (i == 2)
                {
                    g_pos[i][j] = new Vector3(-10.5f + 5 * j, 0.5f, 10.5f);   // 북쪽
                }
                else
                {
                    g_pos[i][j] = new Vector3(9.5f, 0.5f, 10.5f + (-5 * j));  // 동쪽
                }
            }
        }
        spawnGhost();
    }

    //private Vector3[/*여기에 랜덤 값이 들어가고 (*/][/*여기에 0~4 값이 들어가니까 이것만 인자로 받는 함수를 쓰면 간단해지겠죠*/] g_pos =
    //    {
    //        // 직접 사용하시거나
    //        // 아ㅣ면 Awake에서 동적으로 미리 만들어 두고 사용하면 lookup 테이블 형식이라,
    //        // 이렇게 하면 함수로 빼서 Switch-case 문도 사라지게 됩니다
    //    };
    private void spawnGhost()
    {
        // 0 : Down, 1 : Left, 2 : Up, 3 : Right
        int randomDirection = Random.Range(0, 4);
        foreach (Vector3 pos in g_pos[randomDirection])
        {         
            GameObject newGhost = Instantiate(ghost, pos, Quaternion.identity, gameObject.transform);
            newGhost.transform.rotation = Quaternion.Euler(0, 90 * randomDirection, 0);
            Destroy(newGhost, delay);
        }
        
        StartCoroutine(respawn());
    }

    private IEnumerator respawn()
    {
        yield return new WaitForSeconds(delay);
        spawnGhost();
    }
}

// 리팩토링 할 때 대리자 이벤트
// float 이중배열




