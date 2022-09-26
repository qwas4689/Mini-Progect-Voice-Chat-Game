using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitGhost : MonoBehaviour
{
    [SerializeField]
    private AudioSource hitGhost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
<<<<<<< Updated upstream:Assets/Scenes/Scripts/Player/PlayerHitGhost.cs
            hitGhost.Play();
            UIManager.Instance._hitGhost.Invoke();
=======
            UIManager.Instance.UpdateCaptureScoreText(0);
>>>>>>> Stashed changes:Assets/Scripts/Player/PlayerHitGhost.cs
        }
    }
}
