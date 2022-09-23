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
     
    // [��/��/��/��][0��° ��Ʈ ��ġ �������] -> 9.5 / 0.5 / 10.5
    //              [1��° ��Ʈ ��ġ �������] -> 9.5 / 0.5 / 5.5
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

    //private Vector3[/*���⿡ ���� ���� ���� (*/][/*���⿡ 0~4 ���� ���ϱ� �̰͸� ���ڷ� �޴� �Լ��� ���� ������������*/] g_pos =
    //    {
    //        // ���� ����Ͻðų�
    //        // �ƤӸ� Awake���� �������� �̸� ����� �ΰ� ����ϸ� lookup ���̺� �����̶�,
    //        // �̷��� �ϸ� �Լ��� ���� Switch-case ���� ������� �˴ϴ�
    //    };
    //�Լ�������
    public void RandomNum()
    {
        randNum = Random.Range(0, 4); // ���� ����
        SetGhost(randNum); //�̷��� Switch-case �����!
    }
    private void SetGhost(int randNum)
    {
        foreach (Vector3 pos in g_pos[randNum])
        {
            
            Instantiate(ghost, pos, Quaternion.identity);
        }
    }
}

// �����丵 �� �� �븮�� �̺�Ʈ
// float ���߹迭




