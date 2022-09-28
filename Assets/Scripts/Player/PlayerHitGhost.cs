using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitGhost : MonoBehaviour
{
    [SerializeField]
    private AudioSource hitGhost;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            hitGhost.Play();
            UIManager.Instance._hitGhost.Invoke();
        }
    }
}
