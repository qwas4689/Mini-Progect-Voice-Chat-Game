using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class asdasd : MonoBehaviourPun
{

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            PhotonNetwork.Instantiate("Players", Vector3.zero, Quaternion.identity);
        }

    }
}
