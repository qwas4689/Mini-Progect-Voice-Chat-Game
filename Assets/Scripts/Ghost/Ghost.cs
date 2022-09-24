using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public static GhostSpawer Spawner { get; set; } = null;

    private float elapsedTime;
    private Vector3 startPosition;
    private Vector3 endPosition;
    void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position + transform.forward * Spawner.mapSize;
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / Spawner.delay);  
    }
}
