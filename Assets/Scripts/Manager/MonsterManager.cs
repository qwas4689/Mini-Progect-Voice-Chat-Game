using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class MonsterManager : MonoBehaviourPun
{
    [SerializeField]
    private GameObject monsterPrefab = null;

    [SerializeField]
    private Transform[] monsterSpwanePosition;

    private int index;
    private int totalMonstersNumber = 8;
    public bool playerSlider { get; set; }

    private void Start()
    {
        playerSlider = false;
        if(PhotonNetwork.IsMasterClient)
        {
            createMonster();
        }
    }

    private void createMonster()
    {
        Debug.Assert(monsterPrefab != null);

        GameObject newMonster = PhotonNetwork.Instantiate("Monster", monsterSpwanePosition[index].position, Quaternion.identity);
        randomIndex();

        if ( playerSlider)
        {
            destoryMonster(newMonster)
        }
    }

    private void randomIndex()
    {
        index = Random.Range(0, totalMonstersNumber);
    }

    private void destoryMonster(GameObject monster)
    {
        PhotonNetwork.Destroy(monster);
        playerSlider = false;
        createMonster();
    }
}
