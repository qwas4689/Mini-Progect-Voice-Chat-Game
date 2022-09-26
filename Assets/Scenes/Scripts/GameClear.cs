using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameClear : MonoBehaviour
{
    public GameObject gameClearUI;
    public TextMeshProUGUI gameScore;


    private void Awake()
    {
        gameScore = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
       
    }

    private void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBody")
        {
            if (UIManager.Instance.score >= 3)
            {
                Debug.Log("�۵�");
                gameClearUI.SetActive(true);
            }
        }
    }
}
