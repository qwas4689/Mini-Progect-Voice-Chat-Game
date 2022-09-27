using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFRestartGame : MonoBehaviour
{
    private void OnEnable()
    {
        UIManager.Instance.ExitPorTal.SetActive(false);
        //UIManager.Instance.setScoreUI();
        Debug.Log("IFRestartGame OnEnable");
    }
}
