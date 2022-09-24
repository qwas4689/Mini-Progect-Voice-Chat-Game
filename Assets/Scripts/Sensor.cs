using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    public UnityEvent<float> upScoreEvent;
    public Slider slider;

    public bool eventOperation { get; set; }

    private float inputF = 0f;
    private const float initNumber = 0f;
    private float score;

    public float Score
    {
        get
        {
            return score;
        }
        private set
        {
            score = value;
            upScoreEvent.Invoke(score);
        }
    }

    void Awake()
    {
        Score = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Monster")
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
                inputF = initNumber;
                slider.value = initNumber;
            }
        }
        else
        {
            slider.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            inputF = initNumber;
            slider.value = initNumber;
            slider.gameObject.SetActive(false);
        }
    }

    public void upScore()
    {
        ++Score;
    }
}
