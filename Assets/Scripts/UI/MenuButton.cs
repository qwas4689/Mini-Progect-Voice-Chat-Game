using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    private GameObject menuUI;

    public void OnClickMenuButton()
    {
        menuUI.SetActive(true);
    }
}
