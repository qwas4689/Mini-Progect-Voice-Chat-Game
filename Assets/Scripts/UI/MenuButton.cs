using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private AudioSource exitButtonSound;

    public void OnClickMenuButton()
    {
        exitButtonSound.Play();
        menuUI.SetActive(true);
    }
}
