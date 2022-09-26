using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject monsterPrefab = null;

    [SerializeField]
    private Transform[] monsterSpwanePosition;

    private int index;
    private int totalMonstersNumber = 8;

    private void Start()
    {
        StartCoroutine(createMonster());
    }

    private IEnumerator createMonster()
    {
        Debug.Assert(monsterPrefab != null);
        while (true)
        {
            Instantiate(monsterPrefab, monsterSpwanePosition[index].position, Quaternion.identity);
            yield return new WaitForSeconds(15f);
            randomIndex();
        }
    }

    private void randomIndex()
    {
        index = Random.Range(0, totalMonstersNumber);
    }
}
