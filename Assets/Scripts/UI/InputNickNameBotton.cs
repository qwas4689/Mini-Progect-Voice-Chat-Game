using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNickNameBotton : MonoBehaviour
{
    [SerializeField]
    private GameObject inputNickNameBotton;

    [SerializeField]
    private AudioSource clickInputNickNameBotton;



    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickInputNickNameBotton()
    {
        clickInputNickNameBotton.Play();
        inputNickNameBotton.SetActive(true);
    }
}
