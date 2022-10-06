using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice;
using Photon.Voice.Unity;
using UnityEngine.UI;

public class PhotonVoice : MonoBehaviour
{
    [SerializeField]
    private Recorder photonVoice;
    [SerializeField]
    private GameObject speakerImage;

    void Start()
    {
        photonVoice.TransmitEnabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            photonVoice.TransmitEnabled = true;
            speakerImage.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.K))
        {
            photonVoice.TransmitEnabled = false;
            speakerImage.SetActive(false);
        }

    }
}
