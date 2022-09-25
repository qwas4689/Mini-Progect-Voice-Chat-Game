using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonBehaviour<UIManager>
{
    public Slider CapturingSlider;
    public TextMeshProUGUI _scoreUI;

    public UnityEvent _playerFindMonster;
    public UnityEvent _playerMissingMonster;
    public UnityEvent _upScore;

    private int score = 0;

    private void Awake()
    {
        CapturingSlider.gameObject.SetActive(false);
        _playerFindMonster = new UnityEvent();
        _playerMissingMonster = new UnityEvent();
        _upScore = new UnityEvent();

        _scoreUI.text = $"{score} / 3";

    }

    // Start is called before the first frame update
    void Start()
    {
        _playerFindMonster.AddListener(OnCapturingSlider);
        _playerMissingMonster.AddListener(OffCapturingSlider);
        _upScore.AddListener(AddScore);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCapturingSlider()
    {
        CapturingSlider.gameObject.SetActive(true);
    }

    private void OffCapturingSlider()
    {
        CapturingSlider.gameObject.SetActive(false);
    }

    public void AddScore()
    {
        ++score;
        _scoreUI.text = $"{score} / 3";
    }
}
