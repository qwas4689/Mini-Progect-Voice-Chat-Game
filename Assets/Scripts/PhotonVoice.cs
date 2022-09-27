using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice;
using Photon.Voice.Unity;

public class PhotonVoice : MonoBehaviour
{
    [SerializeField]
    private Recorder photonVoice;
    void Start()
    {
        photonVoice.TransmitEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            photonVoice.TransmitEnabled = true;
        }
        if(Input.GetKeyUp(KeyCode.K))   
        {
            photonVoice.TransmitEnabled = false;
        }
        
    }
}
