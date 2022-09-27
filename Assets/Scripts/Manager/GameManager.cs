using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks, IPunObservable
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

    [PunRPC]
    public void GameOver()
    {
        UIManager.Instance.SetActiveGameOverUI(true);
    }

    [PunRPC]
    public void GameClear()
    {
        UIManager.Instance.SetActiveGameClearUI(true);
        Time.timeScale = 0f;
    }
}