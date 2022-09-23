using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    public int Damage = 10;
    // public int HP { get; private set; } = 100;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("CheckCollision", RpcTarget.MasterClient);
    }

}
