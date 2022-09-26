using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class UIManager : SingletonBehaviour<UIManager>
{
    public Slider CapturingSlider;
    public TextMeshProUGUI _scoreUI;
    public GameObject ExitPorTal;

    public UnityEvent _playerFindMonster;
    public UnityEvent _playerMissingMonster;
    public UnityEvent _upScore;
    public UnityEvent _hitGhost;

    public int score = 0;

    private void Awake()
    {
        CapturingSlider.gameObject.SetActive(false);
        _playerFindMonster = new UnityEvent();
        _playerMissingMonster = new UnityEvent();
        _upScore = new UnityEvent();
        _hitGhost = new UnityEvent();

        ExitPorTal.SetActive(false);

        setScoreUI();

    }

    void Start()
    {
        _playerFindMonster.AddListener(OnCapturingSlider);
        _playerMissingMonster.AddListener(OffCapturingSlider);
        _upScore.AddListener(AddScore);
        _hitGhost.AddListener(resetScoreAndCapturingSlider);
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
        if (score >= 3)
        {
            ExitPorTal.SetActive(true);
        }
        else
        {
            ExitPorTal.SetActive(false);
        }
    }

    public void resetScoreAndCapturingSlider()
    {
        score = 0;
        _scoreUI.text = $"{score} / 3";
        CapturingSlider.value = 0f;
    }

    public virtual void setScoreUI()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _scoreUI.text = $"{score} / 3";
        }
    }
}
