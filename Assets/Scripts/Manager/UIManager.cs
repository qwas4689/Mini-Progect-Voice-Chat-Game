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

        ExitPorTal.SetActive(false);

        _scoreUI.text = $"{score} / 3";

    }

    // Start is called before the first frame update
    void Start()
    {
        _playerFindMonster.AddListener(OnCapturingSlider);
        _playerMissingMonster.AddListener(OffCapturingSlider);
        _upScore.AddListener(AddScore);
        _hitGhost.AddListener(resetScore);
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
        Debug.Log("점수얻음");
        if (score >= 3)
        {
            ExitPorTal.SetActive(true);
            Debug.Log("점수 3점넘음");
        }
        else
        {
            ExitPorTal.SetActive(false);
            Debug.Log("점수아직 3점안됨");
        }
    }
    public void resetScore()
    {
        score = 0;
        _scoreUI.text = $"{score} / 3";
    }
}
