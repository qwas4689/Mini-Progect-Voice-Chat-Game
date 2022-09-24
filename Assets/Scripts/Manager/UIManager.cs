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


    private void Awake()
    {
        CapturingSlider.gameObject.SetActive(false);
        _playerFindMonster = new UnityEvent();
        _playerMissingMonster = new UnityEvent();

        _scoreUI.text = $"0 / 3";

    }

    // Start is called before the first frame update
    void Start()
    {
        _playerFindMonster.AddListener(OnCapturingSlider);
        _playerMissingMonster.AddListener(OffCapturingSlider);

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

    public void updateScoreUI(float score)
    {
        _scoreUI.text = $"{score} / 3";
    }
}
