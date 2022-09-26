using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerFindMonster : MonoBehaviourPun
{
    [SerializeField]
    private AudioSource captureMonster;

    public GameObject playerCapturingGameObject;
    private Slider playerCapturingSlider;

    private void Awake()
    {
        playerCapturingSlider = playerCapturingGameObject.GetComponent<Slider>();
    }

    private void Start()
    {
        captureMonster.Play();
        captureMonster.Pause();
        playerCapturingGameObject.SetActive(false);
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
            playerCapturingGameObject.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                captureMonster.UnPause();
                playerCapturingSlider.value += Time.deltaTime * 0.33f;
                if (playerCapturingSlider.value >= 1f)
                {
                    captureMonster.Pause();
                    if (PhotonNetwork.IsMasterClient)
                    {
                        playerCapturingSlider.value = 0f;
                        UIManager.Instance._upScore.Invoke();
                        PhotonNetwork.Destroy(other.gameObject);
                    }
                    UIManager.Instance._playerMissingMonster.Invoke();
                    playerCapturingSlider.gameObject.SetActive(false);

                }
            }
            else
            {
                captureMonster.Pause();
                playerCapturingSlider.value = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            captureMonster.Pause();
            UIManager.Instance._playerMissingMonster.Invoke();
            playerCapturingSlider.gameObject.SetActive(false);
        }
    }
}