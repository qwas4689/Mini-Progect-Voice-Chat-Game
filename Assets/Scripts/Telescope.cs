using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telescope : MonoBehaviour
{
    private Vector3 observerCameraPosition;

    void Awake()
    {
        observerCameraPosition = new Vector3(0f, 15f, 0f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                other.gameObject.transform.GetChild(0).position = observerCameraPosition;
                other.gameObject.GetComponent<PlayerMove>().enabled = false;
                Destroy(gameObject);
            }
        }
    }
}
