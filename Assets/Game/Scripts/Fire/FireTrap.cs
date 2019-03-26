using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FireTrap : MonoBehaviour
{
    public GameObject fireTrap; 

    public AudioClip trapActivationSFX;

    public Transform[] fireSpawnPos;
    
    public float timer = 2.0f;
    private float originalTimer;
    private bool isTriggered = false;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        originalTimer = timer;
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            UpdateTimer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<NinjaController>() == true)
        {
            timer = originalTimer;
            isTriggered = true;
            audioSource.PlayOneShot(trapActivationSFX);
        }
    }

    private void UpdateTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            foreach (Transform pos in fireSpawnPos)
            {
                GameObject fire = Instantiate(fireTrap, pos);
                fire.transform.localPosition = Vector3.zero;
            }
            isTriggered = false;
        }
    }
}
