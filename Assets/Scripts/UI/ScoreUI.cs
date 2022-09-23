using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI _scoreUI;

    Sensor sensor;

    // Start is called before the first frame update
    void Awake()
    {
        sensor = GetComponent<Sensor>();
        _scoreUI.text = $"0 / 3";
    }

    void Start()
    {
        sensor.upSocreEvent.AddListener(sensor.upScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (sensor.eventOperation)
        {
            updateScoreUI(sensor.score);
            sensor.eventOperation = false;
            
        }

    }

    private void updateScoreUI(float score)
    {
        _scoreUI.text = $"{score} / 3";
    }


}
