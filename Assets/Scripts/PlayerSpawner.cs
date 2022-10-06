using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        Data data = FindObjectOfType<Data>();

        GameObject playerObject = PhotonNetwork.Instantiate("Players", Vector3.zero, Quaternion.identity);
        PlayerMove player = playerObject.GetComponent<PlayerMove>();
        player.photonView.RPC("SetNickname", RpcTarget.All, data.Nickname);
    }
}
