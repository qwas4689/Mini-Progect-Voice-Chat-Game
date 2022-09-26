using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

<<<<<<< Updated upstream:Assets/Scenes/Scripts/Manager/GameManager.cs
public class GameManager : SingletonBehaviourNickname<GameManager>
=======
public class GameManager : MonoBehaviourPunCallbacks, IPunObservable
>>>>>>> Stashed changes:Assets/Scripts/GameManager.cs
{
    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    private static GameManager m_instance;

    public int captureScore = 0;
    public bool IsGameover { get; private set; }



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(captureScore);
        }
        else
        {
            captureScore = (int)stream.ReceiveNext();
            UIManager.Instance.UpdateCaptureScoreText(captureScore);
        }
    }
    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }
    public void AddScore(int newScore)
    {
        if(!IsGameover)
        {
            captureScore += newScore;
            UIManager.Instance.UpdateCaptureScoreText(captureScore);
        }
    }


    public void GameOver()
    {
        IsGameover = true;
        UIManager.Instance.SetActiveGameOverUI(true);
    }
    
    public void GameClear()
    {
        UIManager.Instance.SetActiveGameClearUI(true);
    }
}