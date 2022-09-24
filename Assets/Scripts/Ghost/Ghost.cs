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
    public Vector3 EndPosition { get; set; }
    void Start()
    {
        ghostSpawer = gameObject.transform.parent.GetComponent<GhostSpawer>();
        startPosition = transform.position;
    }

    void Update()
    {
            transform.position = Vector3.Lerp(startPosition, EndPosition, elapsedTime / delay);  
    }
}
