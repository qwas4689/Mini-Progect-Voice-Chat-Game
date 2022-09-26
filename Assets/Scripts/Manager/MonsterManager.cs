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

    private void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(createMonster());
        }
    }

    private IEnumerator createMonster()
    {
        Debug.Assert(monsterPrefab != null);
        while (true)
        {
            PhotonNetwork.Instantiate("Monster", monsterSpwanePosition[index].position, Quaternion.identity);
            yield return new WaitForSeconds(15f);
            randomIndex();
        }
    }

    private void randomIndex()
    {
        index = Random.Range(0, totalMonstersNumber);
    }
}
