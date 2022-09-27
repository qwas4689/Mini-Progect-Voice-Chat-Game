using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// template <typename T>
public class SingletonBehaviourNickname<T> : MonoBehaviour where T : MonoBehaviour
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
                if (_instance == null)
                {
                    GameObject go = new GameObject($"@{nameof(T)}");
                    _instance = go.AddComponent<T>();
                }
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    protected void Awake()
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