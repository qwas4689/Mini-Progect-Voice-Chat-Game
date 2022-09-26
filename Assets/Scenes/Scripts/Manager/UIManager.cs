using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class UIManager :  MonoBehaviourPun
{
<<<<<<< Updated upstream:Assets/Scenes/Scripts/Manager/UIManager.cs
    public Slider CapturingSlider;
    public TextMeshProUGUI _scoreUI;
    public GameObject ExitPorTal;

    public UnityEvent _playerFindMonster;
    public UnityEvent _playerMissingMonster;
    public UnityEvent _upScore;
    public UnityEvent _hitGhost;

    public int score = 0;

    private void Awake()
=======
    public static UIManager Instance
>>>>>>> Stashed changes:Assets/Scripts/Manager/UIManager.cs
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
                
            }
            return m_instance;
        }
    }

<<<<<<< Updated upstream:Assets/Scenes/Scripts/Manager/UIManager.cs
        setScoreUI();
=======
    private static UIManager m_instance;
>>>>>>> Stashed changes:Assets/Scripts/Manager/UIManager.cs

    public TextMeshProUGUI captureScoreText;
    public TextMeshProUGUI timerText;
    public GameObject gameoverUI;

<<<<<<< Updated upstream:Assets/Scenes/Scripts/Manager/UIManager.cs
    void Start()
=======
    [PunRPC]
    public void UpdateCaptureScoreText(int newScore)
>>>>>>> Stashed changes:Assets/Scripts/Manager/UIManager.cs
    {
        captureScoreText.text = $"{newScore} / 3";
    }

<<<<<<< Updated upstream:Assets/Scenes/Scripts/Manager/UIManager.cs
    private void OnCapturingSlider()
=======
    [PunRPC]
    public void UpdateTimerText(int minute, int second)
    {
        timerText.text = $"{minute} : {second:D2}";
    }

    [PunRPC]
    public void SetActiveGameClearUI(bool active)
>>>>>>> Stashed changes:Assets/Scripts/Manager/UIManager.cs
    {
        gameObject.SetActive(active);
    }

    [PunRPC]
    public void SetActiveGameOverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }

<<<<<<< Updated upstream:Assets/Scenes/Scripts/Manager/UIManager.cs
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
=======
    



    //public Slider CapturingSlider;
    //public GameObject ExitPorTal;

    //public UnityEvent _playerFindMonster;
    //public UnityEvent _playerMissingMonster;
    //public UnityEvent _upScore;
    //public UnityEvent _hitGhost;
    


    //public int score = 0;

    //private void Awake()
    //{
    //    CapturingSlider.gameObject.SetActive(false);
    //    _playerFindMonster = new UnityEvent();
    //    _playerMissingMonster = new UnityEvent();
    //    _upScore = new UnityEvent();
    //    _hitGhost = new UnityEvent();

    //    ExitPorTal.SetActive(false);

    //    _scoreUI.text = $"{score} / 3";

    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    _playerFindMonster.AddListener(OnCapturingSlider);
    //    _playerMissingMonster.AddListener(OffCapturingSlider);
    //    _upScore.AddListener(AddScore);
    //    _hitGhost.AddListener(resetScoreAndCapturingSlider);
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //private void OnCapturingSlider()
    //{
    //    CapturingSlider.gameObject.SetActive(true);
    //}

    //private void OffCapturingSlider()
    //{
    //    CapturingSlider.gameObject.SetActive(false);
    //}

    //public void AddScore()
    //{
    //    ++score;
    //    _scoreUI.text = $"{score} / 3";
    //    Debug.Log("점수얻음");
    //    if (score >= 3)
    //    {
    //        ExitPorTal.SetActive(true);
    //        Debug.Log("점수 3점넘음");
    //    }
    //    else
    //    {
    //        ExitPorTal.SetActive(false);
    //        Debug.Log("점수아직 3점안됨");
    //    }
    //}
    //public void resetScoreAndCapturingSlider()
    //{
    //    score = 0;
    //    _scoreUI.text = $"{score} / 3";
    //    CapturingSlider.value = 0f;
    //}
>>>>>>> Stashed changes:Assets/Scripts/Manager/UIManager.cs
}
