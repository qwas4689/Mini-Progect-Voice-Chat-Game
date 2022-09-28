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
    private Monster monster;

    private bool isSliderMaxValue;

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
        if (false == photonView.IsMine)
        {
            return;
        }

        if (other.gameObject.tag == "Monster")
        {
            UIManager.Instance._playerFindMonster.Invoke();
            playerCapturingSlider.value = 0f;
            monster = other.GetComponent<Monster>();
            isSliderMaxValue = false;
            //monster.OnDie.RemoveListener(ResetPlayerCapturingSlider);
            //monster.OnDie.AddListener(ResetPlayerCapturingSlider);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (false == photonView.IsMine)
        {
            return;
        }

        if (other.gameObject.tag == "Monster")
        {


            playerCapturingGameObject.SetActive(true);
            captureMonster.Pause();
            
            if (Input.GetKey(KeyCode.F) && !isSliderMaxValue)
            {
                captureMonster.UnPause();

                if (playerCapturingSlider.value >= 1f)
                {
                    isSliderMaxValue = true;
                    UIManager.Instance.photonView.RPC("AddScore", RpcTarget.MasterClient);
                    playerCapturingSlider.value = 0f;
                    playerCapturingSlider.gameObject.SetActive(false);

                    other.gameObject.GetComponent<PhotonView>().RPC("MonsterDestory", RpcTarget.Others);
                    Destroy(other.gameObject);

                    captureMonster.Pause();
                }
                else
                {
                    playerCapturingSlider.value += Time.deltaTime * 0.33f;
                }
            }
            else
            {
                playerCapturingSlider.value = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (false == photonView.IsMine)
        {
            return;
        }

        if (other.gameObject.tag == "Monster")
        {
            captureMonster.Pause();
            UIManager.Instance._playerMissingMonster.Invoke();

            playerCapturingSlider.gameObject.SetActive(false);
            isSliderMaxValue = false;
        }
    }
}