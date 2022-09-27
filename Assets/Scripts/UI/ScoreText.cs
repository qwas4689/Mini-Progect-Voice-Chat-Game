using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private void OnEnable()
    {
        UIManager.Instance._scoreUI = GetComponent<TextMeshProUGUI>();
        UIManager.Instance.setScoreUI();
    }
}
