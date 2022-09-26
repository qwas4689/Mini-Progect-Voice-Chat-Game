using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviourNickname<GameManager>
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