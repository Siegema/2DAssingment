using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMngr : MonoBehaviour
{
    public static float time;
    
    // Start is called before the first frame update
    void Start()
    { 
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    { 
        time += Time.deltaTime;
    }
}
