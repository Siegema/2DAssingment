using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMngr : MonoBehaviour
{
    public Text coinText;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        coinText.text = Score.score.ToString();
        timeText.text = TimeMngr.time.ToString();
    }
}
