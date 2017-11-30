
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeerBehavior : MonoBehaviour {

    private bool disabled;
    public float walkSpeed;
    public bool verticalWalk;

	//variables for handling small talk sounds
	public AudioClip[] audioClips;
	public AudioSource audioSource;

	// Use this for initialization
	public void Start () {
        disabled = false;

		//grabbing the various small talk sounds and audio source
		audioClips = GameObject.Find ("Enemy Peers").GetComponent<AudioClips> ().audioClips;
		audioSource = GameObject.Find ("Enemy Peers").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	public void Update () {
        //making the enemy move left to right or up and down

        if (disabled == false)
        {
            if (verticalWalk == true) //if walking vertical is true do this 
            {
                transform.Translate(new Vector3(0, walkSpeed, 0) * Time.deltaTime);
            }
            else //if not then walk horizontally
            {
                transform.Translate(new Vector3(walkSpeed, 0, 0) * Time.deltaTime);
            }
        }
    }

    public void DisablePeers()
    { //this gets called by the player
        disabled = true;
        Invoke("ResetDisabled", 5.0f); //after 5 seconds call ResetDisabled()
    }

    void ResetDisabled()
    {
        disabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the enemy collide with game objects taged Immovables then mirror movement
        if (collision.gameObject.tag == "Immovables")
        {
            walkSpeed *= -1;
        }

		//if the enemy collides with the player, play random small talk
		if(collision.gameObject.tag == "Player"){
			int clipNumber = Random.Range (0, 4);
			audioSource.clip = audioClips [clipNumber];
			audioSource.Play ();
		}
        
    }

	private void OnCollisionExit2D(Collision2D coll){
		//if the enemy stops colliding with the player, end small talk
		if(coll.gameObject.tag == "Player"){
			audioSource.Stop ();
		}
	}
}
