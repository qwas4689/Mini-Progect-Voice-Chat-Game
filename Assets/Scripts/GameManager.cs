using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool canPlayerMove = false; 
    public static bool isOpenUI = true;  

    void Update()
    {
        if (isOpenUI)
        {
            canPlayerMove = false;
        }
        else
        {           
            canPlayerMove = true;
        }
    }
}