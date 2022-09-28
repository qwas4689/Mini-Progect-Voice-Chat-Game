using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Telescope : MonoBehaviourPun
{
    private Vector3 observerCameraPosition;

    [SerializeField]
    private GameObject ObserverWall;

    private void Awake()
    {
        observerCameraPosition = new Vector3(0f, 15f, 0f);
        ObserverWall.SetActive(false);
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
                    ObserverWall.SetActive(true);
                    other.gameObject.transform.GetChild(3).position += observerCameraPosition;

                    PhotonNetwork.Destroy(gameObject);
                }

            }
        }
    }
}
