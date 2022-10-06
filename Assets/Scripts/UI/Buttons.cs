using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // 목표 UI
    [SerializeField]
    private GameObject _goalUI;

    // 메뉴 UI
    [SerializeField]
    private GameObject _manualUI;

    // UI상호작용 사운드
    [SerializeField]
    private AudioSource _exitButtonSound;

    // 메뉴 GameObject
    [SerializeField]
    private GameObject _menuUI;


    public void OnClickReStartButton()
    {
        Time.timeScale = 1f;
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Lobby");
    }

    public void OnClickExitGoalUIButton()
    {
        _exitButtonSound.Play();
        _goalUI.SetActive(false);
    }

    public void OnClickExitManualUIButton()
    {
        _exitButtonSound.Play();
        _manualUI.SetActive(false);
    }

    public void OnClickExitMenuUIButton()
    {
        _exitButtonSound.Play();
        _menuUI.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnClickMenuButton()
    {
        _exitButtonSound.Play();
        _menuUI.SetActive(true);
    }
}
