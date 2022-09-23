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

    private Dir dir;
    private Vector3 ghostSpawnPosition;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public int randNum;

    private Vector3[][] g_pos;
     
    // [��/��/��/��][0��° ��Ʈ ��ġ �������] -> 9.5 / 0.5 / 10.5
    //              [1��° ��Ʈ ��ġ �������] -> 9.5 / 0.5 / 5.5
    private void Awake()
    {      
        g_pos = new Vector3[(int)Dir.Dir_Max][];

        for (int i = 0; i < 4; i++)
        {
            g_pos[i] = new Vector3[5];
            for (int j = 0; j < 5; j++)
            {
                if (i == 0)
                {
                    g_pos[i][j] = new Vector3(9.5f, 0.5f, 10.5f + (-5 * j));
                }
                else if (i == 1)
                {
                    g_pos[i][j] = new Vector3(9.5f - 5 * j, 0.5f, -9.5f);
                }
                else if (i == 2)
                {
                    g_pos[i][j] = new Vector3(-10.5f, 0.5f, -9.5f + 5 * j);
                }
                else
                {
                    g_pos[i][j] = new Vector3(-10.5f + 5 * j, 0.5f, 10.5f);
                }
            }
        }
        RandomNum();
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
            Instantiate(ghost, pos, Quaternion.identity, gameObject.transform);
        }
    }
}

// �����丵 �� �� �븮�� �̺�Ʈ
// float ���߹迭




