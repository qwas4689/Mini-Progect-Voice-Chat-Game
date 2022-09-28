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
        if (false == photonView.IsMine)
        {
            return;
        }

        if (other.gameObject.tag == "Monster")
        {
            UIManager.Instance._playerFindMonster.Invoke();
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
            
            if (Input.GetKey(KeyCode.F))
            {
                captureMonster.UnPause();

                if (playerCapturingSlider.value >= 1f)
                {
                    UIManager.Instance.photonView.RPC("AddScore", RpcTarget.MasterClient);
                    other.gameObject.GetComponent<PhotonView>().RPC("MonsterDestory", RpcTarget.All);
                    captureMonster.Pause();
                    playerCapturingSlider.gameObject.SetActive(false);
                    playerCapturingSlider.value = 0f;
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
        }
    }

    [PunRPC]
    public void MonsterDestory(GameObject monster)
    {
        Debug.Log("ÆÄ±« È£ÃâµÊ");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Destroy(monster);
        }
    }
}