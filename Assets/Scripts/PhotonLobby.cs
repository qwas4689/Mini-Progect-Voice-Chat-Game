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

        // ������ ������ ������ ���� ���� �õ�
        PhotonNetwork.ConnectUsingSettings();

        deactiveJoinButton();
    }

    // ������ ���� ���� ���� �� �ڵ� ���� // ����Ǹ�
    public override void OnConnectedToMaster()
    {
        // PhotonNetwork.JoinLobby();
        Debug.Log("OnConnectedToMaster");

        activeJoinButton();
    }

    // ������ ���� ���� ���� �� �ڵ� ����
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
            Debug.Log("�г����� �Է��ϼ���.");
            return;
        }

        Data data = FindObjectOfType<Data>();
        data.Nickname = _nickname.text;
        Debug.Log($"�Էµ� �г��� : {data.Nickname}");
        //PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinOrCreateRoom("Metaverse", RandomRoomOptions, TypedLobby.Default);
    }

    // �뿡 ���� �Ϸ�� ��� �ڵ� ����
    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinRoom");
        PhotonNetwork.LoadLevel("MiniGame");
    }
}
