using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject monsterPrefab;

    [SerializeField]
    private Transform[] monsterSpwanePosition;

    private int index;
    private int totalMonstersNumber = 8;

    void Start()
    {
        StartCoroutine(createMonster());
    }

    IEnumerator createMonster()
    {
        while (true)
        {
            Instantiate(monsterPrefab, monsterSpwanePosition[index].position, Quaternion.identity);
            yield return new WaitForSeconds(15f);
            index = Random.Range(0, totalMonstersNumber);
        }
    }

    private void randomIndex()
    {
        index = Random.Range(0, totalMonstersNumber);
    }
}
