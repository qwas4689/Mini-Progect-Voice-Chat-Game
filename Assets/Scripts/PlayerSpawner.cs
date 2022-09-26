using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPun
{
    void Awake()
    {
        PhotonNetwork.Instantiate("Players", Vector3.zero, Quaternion.identity);
    }
}
