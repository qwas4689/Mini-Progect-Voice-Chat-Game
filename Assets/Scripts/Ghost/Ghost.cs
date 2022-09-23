using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private float delay;

    private GhostSpawer ghostSpawer;

    private float elapsedTime;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    void Start()
    {
        ghostSpawer = gameObject.transform.parent.GetComponent<GhostSpawer>();
        startPosition = transform.position;
        endPosition = transform.position;

        if (ghostSpawer.randNum == 0)
            endPosition.x = transform.position.x - 20f;
        else if (ghostSpawer.randNum == 1)
            endPosition.z = transform.position.z + 20f;
        else if (ghostSpawer.randNum == 2)
            endPosition.x = transform.position.x + 20f;
        else
            endPosition.z = transform.position.z - 20f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("input ����");
            isMoving = true;
        }

        if (isMoving)
        {
            Debug.Log($"��� {elapsedTime}");
            elapsedTime += Time.deltaTime;
            if (elapsedTime > delay)
            {
                Debug.Log("������");
                elapsedTime = 0;
                isMoving = false;
                transform.position = Vector3.Lerp(startPosition, endPosition, 1f);
            }
            else
            {
                Debug.Log("�޸�����");
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / delay);
            }
        }
    }
}
