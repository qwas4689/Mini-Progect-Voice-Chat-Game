using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TelescopeSpawner : MonoBehaviourPun
{

    void Start()
    {
        PhotonNetwork.Instantiate("Telescope", new Vector3(0.5f, 0.5f, -0.5f), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
