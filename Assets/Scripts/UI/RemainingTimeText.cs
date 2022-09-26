using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using Photon.Pun;

public class RemainingTimeText : MonoBehaviourPun, IPunObservable
{
    public TextMeshProUGUI _timerUI;

    private int minute;
    private int second;
    private float cumulativeTime;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(minute);
            stream.SendNext(second);
        }
        else
        {
            minute = (int)stream.ReceiveNext();
            second = (int)stream.ReceiveNext();
        }
    }

    private void Awake()
    {
        second = 0;
        minute = 2;
    }


    private void Update()
    {
        flowingTime();
        //photonView.RPC("UpdateTimerText", RpcTarget.All, minute, second);
    }

    private void flowingTime()
    {
        if (PhotonNetwork.IsMasterClient)
        {

            cumulativeTime += Time.deltaTime;

            if (cumulativeTime > 1f)
            {
                if (second == 0)
                {
                    second = 59;
                    --minute;
                }
                else
                {
                    --second;
                }
                cumulativeTime = 0f;
            }

            if (second == 0 && minute == 0)
            {
                GameManager.Instance.GameOver();
                Time.timeScale = 0;
            }

        }
    }



    [PunRPC]
    public void UpdateTimerText(int minute, int second)
    {
        _timerUI.text = $"{minute} : {second:D2}";
    }
}
