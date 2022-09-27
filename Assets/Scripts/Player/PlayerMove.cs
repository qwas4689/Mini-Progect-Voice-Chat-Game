using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class PlayerMove : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Rigidbody _rigidbody;

    private AudioSource playerWalkSound;

    public string Nickname
    {
        get
        {
            return _nicknameText.text;
        }
        set
        {
            {
                _nicknameText.text = value;
            }
        }

    }

    public TextMeshProUGUI _nicknameText;

    private Vector3 moveDir;
    private float moveSpeed = 3.0f;

    private void Awake()
    {
        _nicknameText = GetComponentInChildren<TextMeshProUGUI>();
        if (photonView.IsMine)
        {
            Camera.main.transform.parent = transform;
            Camera.main.transform.localPosition = new Vector3(0f, 5f, 0f);

            playerWalkSound = GetComponent<AudioSource>();
            playerWalkSound.Play();
            playerWalkSound.Pause();
        }
    }

    public void Update()
    {
        if (false == photonView.IsMine)
        {
            return;
        }
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");

        PlayerMovement();
        gameObject.transform.GetChild(0).LookAt(transform.position + moveDir.normalized);
    }

    public void FixedUpdate()
    {
        if (false == photonView.IsMine)
        {
            return;
        }
        _rigidbody.MovePosition(transform.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }

    private void PlayerMovement()
    {
        if (moveDir.x != 0 || moveDir.z != 0)
        {
            playerWalkSound.UnPause();
        }
        else
        {
            playerWalkSound.Pause();
        }
    }
    [PunRPC]
    public void SetNickname(string nickname)
    {
        Nickname = nickname;
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("aa");
        photonView.RPC("SetNickname", newPlayer, Nickname);
    }


    // ���⼭ �˻縦 �ϰ�, OnDamage�� ���⿡�� ȣ��
    // �浹�� �ߴ��� ���ߴ����� ���⿡�� �˻�
    // ��? ����� ȣ��Ʈ�� �˻��ϰ�, �츮�� ��å�� ȣ��Ʈ�� �浹 �˻縦 �����ϴ°ɷ� �������ϱ�!
    // �˻簡 ������ �浹�� �� �ֵ��� ����� ���⿡�� �ѷ���� �Ѵ�.

}
