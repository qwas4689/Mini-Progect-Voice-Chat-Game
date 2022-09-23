using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject manualUI;
    public GameObject exitButton;


    public void OnClickExitButton()
    {
        exitButton.SetActive(false);
        manualUI.SetActive(false);
        GameManager.isOpenUI = false;
    }
    
    public void OnClickMenu()
    {
        menuUI.SetActive(true);
        GameManager.isOpenUI = true;
    }
}
