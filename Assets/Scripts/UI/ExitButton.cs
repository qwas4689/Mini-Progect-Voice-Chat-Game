using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    void Start()
    {
       // parent = transform.parent.gameObject;
    }

    public void OnClickExitButton()
    {
        parent.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
