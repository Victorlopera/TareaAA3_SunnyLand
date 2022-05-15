using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudioController : MonoBehaviour
{
    AudioSource[] allAudioSources;
    AudioSource impactSource;
    AudioSource rumblingSource;
    
    bool isMoving = false;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        allAudioSources = GetComponents<AudioSource>();
        impactSource = allAudioSources[0];
        rumblingSource = allAudioSources[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
    float v = rb.velocity.magnitude;
    if (v > 1 && !isMoving) {
    print("the box is moving");
        rumblingSource.Play();
        isMoving = true;

    } else if (v < 1 && isMoving) {
        rumblingSource.Stop();
        isMoving = false;
    }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        impactSource.Play();
        print("the box has fallen");
    }
}
