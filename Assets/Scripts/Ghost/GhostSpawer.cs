using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

enum Dir
{
    East,
    West,
    South,
    North,
    Dir_Max
}
public class GhostSpawer : MonoBehaviourPun
{
    [SerializeField]
    private GameObject ghost;
    public float delay;
    public float mapSize;
    public int randNum;

    [SerializeField]
    private AudioSource spawnGhostSound;

    private Vector3[][] ghostPos;

    private void Awake()
    {
        Ghost.Spawner = this;

        ghostPos = new Vector3[(int)Dir.Dir_Max][];

        for (int i = 0; i < 4; i++)
        {
            ghostPos[i] = new Vector3[5];
            for (int j = 0; j < 5; j++)
            {
                if (i == 0)
                {
                    ghostPos[i][j] = new Vector3(10.5f - 5 * j, 0.5f, -10.5f);   // ����
                }
                else if (i == 1)
                {
                    ghostPos[i][j] = new Vector3(-10.5f, 0.5f, -10.5f + 5 * j);  // ����
                }
                else if (i == 2)
                {
                    ghostPos[i][j] = new Vector3(-9.5f + 5 * j, 0.5f, 10.5f);   // ����
                }
                else
                {
                    ghostPos[i][j] = new Vector3(10.5f, 0.5f, 9.5f + (-5 * j));  // ����
                }
            }
        }
        if (PhotonNetwork.IsMasterClient)
        {
            spawnGhost();
        }
    }

    //private Vector3[/*���⿡ ���� ���� ���� (*/][/*���⿡ 0~4 ���� ���ϱ� �̰͸� ���ڷ� �޴� �Լ��� ���� ������������*/] g_pos =
    //    {
    //        // ���� ����Ͻðų�
    //        // �ƤӸ� Awake���� �������� �̸� ����� �ΰ� ����ϸ� lookup ���̺� �����̶�,
    //        // �̷��� �ϸ� �Լ��� ���� Switch-case ���� ������� �˴ϴ�
    //    };
    private void spawnGhost()
    {
        spawnGhostSound.Play();
        // 0 : Down, 1 : Left, 2 : Up, 3 : Right
        int randomDirection = Random.Range(0, 4);
        foreach (Vector3 pos in ghostPos[randomDirection])
        {
            GameObject newGhost = PhotonNetwork.Instantiate("Ghost", pos, Quaternion.Euler(0, 90 * randomDirection, 0));
            StartCoroutine(DestroyAfter(newGhost, delay));
        }
        StartCoroutine(respawn());
    }
    private IEnumerator DestroyAfter(GameObject newGhost, float delay)
    {
        yield return new WaitForSeconds(delay);
        PhotonNetwork.Destroy(newGhost);
    }

    private IEnumerator respawn()
    {
        yield return new WaitForSeconds(delay);
        spawnGhost();
    }
}
