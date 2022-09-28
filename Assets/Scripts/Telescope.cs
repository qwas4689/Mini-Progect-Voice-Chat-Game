using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Telescope : MonoBehaviourPun
{
    private Vector3 observerCameraPosition;

    private void Awake()
    {
        observerCameraPosition = new Vector3(0f, 15f, 0f);
    }

    private void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (photonView.IsMine)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    other.gameObject.transform.GetChild(3).position = observerCameraPosition;
                    other.gameObject.GetComponent<PlayerMove>().enabled = false;
                    other.gameObject.GetComponent<Collider>().enabled = false;
                    PhotonNetwork.Destroy(gameObject);
                }

            }
        }
    }
}
