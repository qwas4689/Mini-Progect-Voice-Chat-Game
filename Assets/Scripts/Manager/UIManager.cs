using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class UIManager : MonoBehaviourPun
{
    //public GameObject CapturingSlider;
    public TextMeshProUGUI _scoreUI { get; set; }

    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }

            return _instance;
        }
    }


    public GameObject ExitPorTal;
    public GameObject gameOverUI;
    public GameObject gameClearUI;

    public UnityEvent _playerFindMonster;
    public UnityEvent _playerMissingMonster;
    public UnityEvent _upScore;
    public UnityEvent _hitGhost;

    public int score;

    private void Awake()
    {
        //CapturingSlider.gameObject.SetActive(false);
        _playerFindMonster = new UnityEvent();
        _playerMissingMonster = new UnityEvent();
        _upScore = new UnityEvent();
        _hitGhost = new UnityEvent();


        ExitPorTal.SetActive(false);


        setScoreUI();
    }

    void Start()
    {
        score = 0;
        //_playerFindMonster.AddListener(OnCapturingSlider);
        //_playerMissingMonster.AddListener(OffCapturingSlider);
        _upScore.AddListener(AddScore);
        _hitGhost.AddListener(resetScoreAndCapturingSlider);
    }

    [PunRPC]
    public void AddScore()
    {
        ++score;
        Debug.Log("점수얻음");
        photonView.RPC("UpdateCaptureScoreText", RpcTarget.All, score);

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
    }

    public virtual void setScoreUI()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _scoreUI.text = $"{score} / 3";
        }
    }

    [PunRPC]
    public void UpdateCaptureScoreText(int newScore)
    {
        _scoreUI.text = $"{newScore} / 3";
    }

    [PunRPC]
    public void SetActiveGameClearUI(bool active)
    {
        gameClearUI.SetActive(active);
    }

    [PunRPC]
    public void SetActiveGameOverUI(bool active)
    {
        gameOverUI.SetActive(active);
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");        
    }
}
