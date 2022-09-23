using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviourPun
{
    [SerializeField]
    private Rigidbody rigidbody;

    private Vector3 moveDir;
    private float moveSpeed = 3.0f;
    // public int HP { get; private set; } = 100;

    public void Update()
    {
        if (false == photonView.IsMine)
        {
            return;
        }
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");

        gameObject.transform.GetChild(1).LookAt(transform.position + moveDir.normalized);
    }

    public void FixedUpdate()
    {
        if (false == photonView.IsMine)
        {
            return;
        }
        rigidbody.MovePosition(transform.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }

    
        // ���⼭ �˻縦 �ϰ�, OnDamage�� ���⿡�� ȣ��
        // �浹�� �ߴ��� ���ߴ����� ���⿡�� �˻�
        // ��? ����� ȣ��Ʈ�� �˻��ϰ�, �츮�� ��å�� ȣ��Ʈ�� �浹 �˻縦 �����ϴ°ɷ� �������ϱ�!
        // �˻簡 ������ �浹�� �� �ֵ��� ����� ���⿡�� �ѷ���� �Ѵ�.
 
}
