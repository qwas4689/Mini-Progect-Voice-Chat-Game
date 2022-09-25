using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonVoice : MonoBehaviour
{
    private PhotonVoice photonVoice;
    void Start()
    {
        photonVoice = GetComponent<PhotonVoice>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.K))
        {
            
        }
        
    }
}
