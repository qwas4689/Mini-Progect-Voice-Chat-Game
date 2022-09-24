using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFindMonster : MonoBehaviour
{


    private void Start()
    {

    }

    private void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            UIManager.Instance._playerFindMonster.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            UIManager.Instance._playerMissingMonster.Invoke();

        }
    }


}