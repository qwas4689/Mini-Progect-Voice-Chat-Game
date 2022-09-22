using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Enemy : MonoBehaviourPun
{
    [SerializeField]
    private Rigidbody rigidbody;
    public int HP { get; private set; } = 100;
    void Start()
    {

    }

    void Update()
    {

    }

    // 피해를 입은 시점에 호출되는 함수
    [PunRPC]
    public virtual void OnDamage(int damage)
    {
        HP -= damage;
        rigidbody.velocity += Vector3.up * 5;
    }
}
