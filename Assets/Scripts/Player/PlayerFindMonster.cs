using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class PlayerFindMonster : MonoBehaviour
{
    public AudioSource captureMonster;

    private void Start()
    {
        captureMonster.Play();
        captureMonster.Pause();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            UIManager.Instance._playerFindMonster.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            if (Input.GetKey(KeyCode.F))
            {
                captureMonster.UnPause();
                UIManager.Instance.CapturingSlider.value += Time.deltaTime * 0.33f;
                if (UIManager.Instance.CapturingSlider.value == 1f)
                {
                    captureMonster.Pause();
                    UIManager.Instance._upScore.Invoke();
                    UIManager.Instance._playerMissingMonster.Invoke();
                    UIManager.Instance.CapturingSlider.value = 0f;
                    Destroy(other.gameObject);
                }
            }
            else
            {
                captureMonster.Pause();
                UIManager.Instance.CapturingSlider.value = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            captureMonster.Pause();
            UIManager.Instance._playerMissingMonster.Invoke();
        }
    }
}