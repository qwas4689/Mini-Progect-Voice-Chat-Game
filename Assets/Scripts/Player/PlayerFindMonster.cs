using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class PlayerFindMonster : MonoBehaviour
{
    [PunRPC]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            UIManager.Instance._playerFindMonster.Invoke();
        }
    }

    [PunRPC]
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            if (Input.GetKey(KeyCode.F))
            {
                UIManager.Instance.CapturingSlider.value += Time.deltaTime * 0.33f;
                if (UIManager.Instance.CapturingSlider.value == 1f)
                {
                    UIManager.Instance._upScore.Invoke();
                    UIManager.Instance._playerMissingMonster.Invoke();
                    UIManager.Instance.CapturingSlider.value = 0f;
                    Destroy(other.gameObject);
                }
            }
            else
            {
                UIManager.Instance.CapturingSlider.value = 0f;
            }
        }
    }

    [PunRPC] 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            UIManager.Instance._playerMissingMonster.Invoke();
        }
    }
}