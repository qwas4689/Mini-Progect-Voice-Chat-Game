using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterData : MonoBehaviour
{
    public bool IsMonster { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
