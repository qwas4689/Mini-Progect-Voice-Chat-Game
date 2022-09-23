using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI _scoreUI;

    Sensor sensor;

    // Start is called before the first frame update
    void Awake()
    {
        sensor = GetComponent<Sensor>(); 
    }

    // Update is called once per frame
    void Update()
    {
        updateScoreUI(sensor.socre);
    }

    private void updateScoreUI(float score)
    {
        _scoreUI.text = $"{score} / 3";
    }
}
