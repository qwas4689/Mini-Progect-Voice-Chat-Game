using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private float delay;

    public GhostSpawer ghostSpawer;

    private float elapsedTime;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ghostSpawer.RandomNum();
            isMoving = true;
        }

        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > delay)
            {
                elapsedTime = 0;
                isMoving = false;
                transform.position = Vector3.Lerp(startPosition, endPosition, 1f);
                reach();
            }
            else
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / delay);
            }
        }
    }

    void reach()
    {
        gameObject.SetActive(false);
    }
}
