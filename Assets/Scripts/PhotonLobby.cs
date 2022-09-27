using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField _nickname;

    [SerializeField]
    private Button _gameStartButton;

    private void deactiveJoinButton()
    {
        _gameStartButton.interactable = false;
    }

    private void activeJoinButton()
    {
        _gameStartButton.interactable = true;
    }

    private void Awake()
    {
        Debug.Log("Start");

        _gameStartButton.onClick.AddListener(OnClickLoginButton);

        // 설정한 정보로 마스터 서버 접속 시도
        PhotonNetwork.ConnectUsingSettings();

        deactiveJoinButton();
    }

    // 마스터 서버 접속 성공 시 자동 실행 // 연결되면
    public override void OnConnectedToMaster()
    {
        // PhotonNetwork.JoinLobby();
        Debug.Log("OnConnectedToMaster");

        activeJoinButton();
    }

    // 마스터 서버 접속 실패 시 자동 실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.ConnectUsingSettings();

        Debug.Log("OnDisconnected");
    }

    private static readonly RoomOptions RandomRoomOptions = new RoomOptions()
    {
        MaxPlayers = 20
    };

    public void OnClickLoginButton()
    {
        if (_nickname.text.Length == 0)
        {
            Debug.Log("닉네임을 입력하세요.");
            return;
        }

        Data data = FindObjectOfType<Data>();
        data.Nickname = _nickname.text;
        Debug.Log($"입력된 닉네임 : {data.Nickname}");
        //PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinOrCreateRoom("Metaverse", RandomRoomOptions, TypedLobby.Default);
    }

    // 룸에 참가 완료된 경우 자동 실행
    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinRoom");
        PhotonNetwork.LoadLevel("MiniGame");
    }
}
