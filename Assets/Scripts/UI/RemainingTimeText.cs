using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class RemainingTimeText : MonoBehaviour
{
    public TextMeshProUGUI _timerUI;

    private int minute;
    private int second;
    private float cumulativeTime;

    private void Start()
    {
        second = 0;
        minute = 2;
    }

    private void Update()
    {
        _timerUI.text = $"{minute} : {second:D2}";
        flowingTime();
    }

    private void flowingTime()
    {
        cumulativeTime += Time.deltaTime;

        if (cumulativeTime > 1f)
        {
            if (second == 0)
            {
                second = 59;
                --minute;
            }
            else
            {
                --second;
            }
            cumulativeTime = 0f;

            if (second == 0 && minute == 0)
            {
                Time.timeScale = 0;
            }
        }
    }
}
