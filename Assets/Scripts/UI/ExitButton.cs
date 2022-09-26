using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private AudioSource exitButtonSound;

    void Start()
    {

    }

    public void OnClickExitButton()
    {
        exitButtonSound.Play();
        parent.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
