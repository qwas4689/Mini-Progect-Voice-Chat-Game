using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Monster : MonoBehaviourPun
{
    [PunRPC]
    public void MonsterDestory()
    {
        Debug.Log("�ı� ȣ���");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
