using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Enemy : MonoBehaviourPun
{
    [SerializeField]
    private Rigidbody _rigidbody;
    public int HP { get; private set; } = 100;
    void Start()
    {

    }

    void Update()
    {

    }

    // ���ظ� ���� ������ ȣ��Ǵ� �Լ�
    [PunRPC]
    public virtual void OnDamage(int damage)
    {
        HP -= damage;
        _rigidbody.velocity += Vector3.up * 5;
    }
}