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

    private void Awake()
    {
        Debug.Log("Start");
        // ���ӿ� �ʿ��� ����(���� ����) ����
        PhotonNetwork.GameVersion = "1.0";

        _gameStartButton.onClick.AddListener(ClickLoginButton);

        // ������ ������ ������ ���� ���� �õ�
        // PhotonNetwork.ConnectUsingSettings();
    }

    // ������ ���� ���� ���� �� �ڵ� ����
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("OnConnectedToMaster");
    }


    int tryConnectCount = 0;
    // ������ ���� ���� ���� �� �ڵ� ����
    public override void OnDisconnected(DisconnectCause cause)
    {
        ++tryConnectCount;
        if (tryConnectCount > 5)
        {
            Debug.Log("������ ������ �־� ������ �� �����ϴ�.");
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        Debug.Log("OnDisconnected");
    }

    // �κ� �����ϸ� ȣ��Ǵ� �Լ�
    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        Connect();
    }

    // �� ���� �õ�
    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("��");
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            Debug.Log("�ȴ�");
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // �� ������ ������ ��� �ڵ� ����
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }

    // �뿡 ���� �Ϸ�� ��� �ڵ� ����
    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinRoom");
        PhotonNetwork.LoadLevel("MiniGameTest");
    }

    private static readonly RoomOptions RandomRoomOptions = new RoomOptions()
    {
        MaxPlayers = 20
    };

    public void ClickLoginButton()
    {
        if (_nickname.text.Length == 0)
        {
            return;
        }
        else if (_nickname.text.Length != 0)
        {
            Data data = FindObjectOfType<Data>();
            data.Nickname = _nickname.text;
            Debug.Log($"�Էµ� �г��� : {data.Nickname}");
            PhotonNetwork.ConnectUsingSettings();
            //PhotonNetwork.JoinOrCreateRoom("Metaverse", RandomRoomOptions, TypedLobby.Default);
        }
    }


    //public override void OnCreatedRoom()
    //{
    //    Debug.Log("OnCreatedRoom");
    //    PhotonNetwork.LoadLevel("MiniGame");
    //}

    //public override void OnCreateRoomFailed(short returnCode, string message)
    //{
    //    Debug.Log("FailedCreateRoom");
    //    Debug.Log($"Message : {message}");
    //}
}
