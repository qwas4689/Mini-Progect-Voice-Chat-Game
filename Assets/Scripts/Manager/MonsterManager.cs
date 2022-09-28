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
    private int inputIndex;
    private bool[] indexBoolList;

    private int totalMonstersNumber = 8;
    private float waitForTime = 15f;

    private void Start()
    {
        indexBoolList = new bool[7];

        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(createMonster());
        }
    }

    private IEnumerator createMonster()
    {
        Debug.Assert(monsterPrefab != null);
        while (true)
        {
            randomIndex();
            PhotonNetwork.Instantiate("Monster", monsterSpwanePosition[index].position, Quaternion.identity);
            yield return new WaitForSeconds(waitForTime);
        }
    }

    private void randomIndex()
    {
        index = Random.Range(0, totalMonstersNumber);
        
    }
}