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
     
    // [��/��/��/��][0��° ��Ʈ ��ġ �������] -> 9.5 / 0.5 / 10.5
    //              [1��° ��Ʈ ��ġ �������] -> 9.5 / 0.5 / 5.5
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
                    g_pos[i][j] = new Vector3(9.5f - 5 * j, 0.5f, -9.5f);   // ����
                }
                else if (i == 1)
                {
                    g_pos[i][j] = new Vector3(-10.5f, 0.5f, -9.5f + 5 * j);  // ����
                }
                else if (i == 2)
                {
                    g_pos[i][j] = new Vector3(-10.5f + 5 * j, 0.5f, 10.5f);   // ����
                }
                else
                {
                    g_pos[i][j] = new Vector3(9.5f, 0.5f, 10.5f + (-5 * j));  // ����
                }
            }
        }
        spawnGhost();
    }

    //private Vector3[/*���⿡ ���� ���� ���� (*/][/*���⿡ 0~4 ���� ���ϱ� �̰͸� ���ڷ� �޴� �Լ��� ���� ������������*/] g_pos =
    //    {
    //        // ���� ����Ͻðų�
    //        // �ƤӸ� Awake���� �������� �̸� ����� �ΰ� ����ϸ� lookup ���̺� �����̶�,
    //        // �̷��� �ϸ� �Լ��� ���� Switch-case ���� ������� �˴ϴ�
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

// �����丵 �� �� �븮�� �̺�Ʈ
// float ���߹迭




