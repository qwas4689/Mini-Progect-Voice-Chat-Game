using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool canPlayerMove = true; 
    public static bool isOpenUI = false;  

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