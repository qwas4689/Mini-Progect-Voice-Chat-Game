using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI _scoreUI;

    private Sensor sensor;

    // Start is called before the first frame update
    void Awake()
    {
        sensor = GetComponent<Sensor>();
        _scoreUI.text = $"0 / 3";
    }

    void Start()
    {
        sensor.upScoreEvent.AddListener(updateScoreUI);
    }

    public void updateScoreUI(float score)
    {
        _scoreUI.text = $"{score} / 3";
    }
}
