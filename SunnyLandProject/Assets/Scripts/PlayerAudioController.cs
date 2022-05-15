using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    AudioSource[] allAudioSources;
    AudioSource walkingSource;
    AudioSource jumpingSource;
    AudioSource landingSource;
    AudioSource crouchSource;
    AudioSource cherrySource;

    // keep track of the jumping state ... 
    bool isJumping = false;
    // make sure to keep track of the movement as well !
    bool isPlaying = false;
    float jumpingSourcePitch =1.0f;
    float landingSourcePitch = 1.0f;

    Rigidbody2D rb; // note the "2D" prefix 

    
    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    allAudioSources = GetComponents<AudioSource>();

    walkingSource = allAudioSources[0];
    jumpingSource = allAudioSources[1];
    landingSource = allAudioSources[2];
    crouchSource = allAudioSources[3];
    cherrySource = allAudioSources[4];

	// get the references to your audio sources here !        
    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate()
    {
    float v = rb.velocity.magnitude;
    if (v > 1 && !isPlaying && !isJumping) {
    print("the fox is walking");
        walkingSource.Play();
        isPlaying = true;
        isJumping = false;
    } else if (v < 1 && isPlaying) {
        walkingSource.Stop();
        isPlaying = false;
    } else if (isJumping) {
        walkingSource.Stop();
        isJumping = true;
    }
	// Use the ridgidbody instance to find out if the fox is
	// moving, and play the respective sound !
	// Make sure to trigger the movement sound only when
	// the movement begins ...

	// Use a magnitude threshold of 1 to detect whether the
	// fox is moving or not !
	// i.e.
	// if ( ??? > 1 && ???) {
	//    play sound here !
	// } else if ( ??? < 1 &&) {
	//   stop sound here !
	// }	
    }
    
    // trigger your landing sound here !
    public void OnLanding() {
        int randomnumber = Random.Range(0, 100);
        float randomModifier = Random.Range(0.1f, 1.9f);
        float finalPitch = landingSourcePitch *randomModifier;

        if (randomnumber < 50)
        {
            landingSource.pitch = finalPitch;
        }

        isJumping = false;
        print("the fox has landed");
        landingSource.Play();
        walkingSource.Stop();
	// to keep things cleaner, you might want to
	// play this sound only when the fox actually jumoed ...
    }

    // trigger your crouching sound here
    public void OnCrouching() {
        print("the fox is crouching");
        crouchSource.Play();
    }
 
    // trigger your jumping sound here !
    public void OnJump() {
        isJumping = true;
        print("the fox has jumped");
        int randomnumber = Random.Range(0,100);
        float randomModifier = Random.Range(0.1f, 1.9f);
        float finalPitch = jumpingSourcePitch * randomModifier;

        if (randomnumber < 50)
        {
            jumpingSource.pitch = finalPitch;
        }
        isJumping = true;
        jumpingSource.Play();
        walkingSource.Stop();
    }

    // trigger your cherry collection sound here !
    public void OnCherryCollect() {
        print("the fox has collected a cherry");
        cherrySource.Play();
    }
}
