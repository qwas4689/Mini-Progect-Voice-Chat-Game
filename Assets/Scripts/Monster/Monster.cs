using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Monster : MonoBehaviourPun
{
    [PunRPC]
    public void MonsterDestory()
    {
        Debug.Log("ÆÄ±« È£ÃâµÊ");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
