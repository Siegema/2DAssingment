using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;

    public static void AddScore(int val)
    { 
        score += val;
    }
}
