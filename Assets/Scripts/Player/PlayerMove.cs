using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviourPun
{
    [SerializeField]
    private Rigidbody _rigidbody;

    private AudioSource playerWalkSound;

    private Vector3 moveDir;
    private float moveSpeed = 3.0f;
    // public int HP { get; private set; } = 100;

    private void Awake()
    {
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
    // 여기서 검사를 하고, OnDamage를 여기에서 호출
    // 충돌을 했는지 안했는지를 여기에서 검사
    // 왜? 여기는 호스트만 검사하고, 우리의 정책은 호스트가 충돌 검사를 판정하는걸로 정했으니까!
    // 검사가 끝나고 충돌을 한 애들의 결과는 여기에서 뿌려줘야 한다.

}
