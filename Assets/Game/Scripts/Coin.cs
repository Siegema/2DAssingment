using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        NinjaController ninja = other.gameObject.GetComponent<NinjaController>();
        if(ninja == true)
        {
            Score.AddScore(value);
            Destroy(this.gameObject);
        }
    }
}
