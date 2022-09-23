using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    public Slider slider;

    public float score { get; private set; }
    public bool eventOperation { get; set; }

    private float inputF = 0f;
    private float float0f = 0f;

    public UnityEvent upSocreEvent;

    void Awake()
    {
        score = 0;
        upSocreEvent = new UnityEvent();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MonsterSensor")
        {
            slider.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                inputF += Time.deltaTime;
                slider.value += inputF * 0.006f;

                if (inputF > 3f)
                {
                    Destroy(other.gameObject);
                    upScore();
                    inputF = 0f;
                }
            }
            else
            {
                inputF = float0f;
                slider.value = float0f;
            }
        }
        else
        {
            slider.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MonsterSensor")
        {
            inputF = float0f;
            slider.value = float0f;
            slider.gameObject.SetActive(false);
        }
    }

    public void upScore()
    {
        eventOperation = true;
        ++score;
        Debug.Log(score);
    }
}
