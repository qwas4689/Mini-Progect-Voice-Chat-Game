using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// template <typename T>
public class SingletonBehaviour<T> : MonoBehaviourPun where T : MonoBehaviourPun
    // where �� T�� ���� ������Ʈ ������ �ɾ��ִ°� ���׸��� ����ϴ°��̴�.
    // MonoBehaviour�� ��ӹ޴� ���̿��߸� �Ѵ�.
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }

            return;
            // ���ϼ� ����
        }
        _instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }
}