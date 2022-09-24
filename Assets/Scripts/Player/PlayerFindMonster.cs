using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFindMonster : MonoBehaviour
{
    public UnityEvent _playerFindMonster;

    private void Awake()
    {
        _playerFindMonster = new UnityEvent();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {

            Debug.Log("EnterMonster");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {

            Debug.Log("ExitMonster");

        }
    }
}
