using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Fire : MonoBehaviour
{

    public float lifeSpan = 2.0f;

    void Update()
    {
        lifeSpan -= Time.deltaTime;
        if(lifeSpan <= 0.0f)
        {
           Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        NinjaController ninja = other.gameObject.GetComponent<NinjaController>();
        if(ninja == true) 
        { 
            ninja.Die();
        } 
    } 
}
