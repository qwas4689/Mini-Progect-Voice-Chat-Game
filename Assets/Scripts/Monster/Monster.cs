using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class Monster : MonoBehaviourPun
{
    public UnityEvent OnDie;

    private void Start()
    {
        OnDie = new UnityEvent();
    }

    [PunRPC]
    public void MonsterDestory()
    {
        Debug.Log("�ı� ȣ���");
        OnDie.Invoke();
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
