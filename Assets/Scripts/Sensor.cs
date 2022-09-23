using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{
    public Slider slider;

    public float socre { get; private set; }

    private float inputF = 0f;
    private float float0f = 0f;

    void Awake()
    {
        socre = 0;    
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
                    slider.gameObject.SetActive(false);
                    socre += 0.5f;
                    Destroy(other.gameObject);
                }
            }
            else
            {
                inputF = float0f;
                slider.value = float0f;
            }
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
}
