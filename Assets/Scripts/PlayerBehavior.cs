using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    public Sprite[] sprites;
    public float playerSpeed;
    private bool disabled; //player disable movement
    public CountdownTime myInstanceOfCountdowntime;

    Rigidbody2D rb;
    SpriteRenderer sr;

	//variables needed for sound effects
	GameObject camera;
	AudioSource audio;
	AudioClips audioClipsList;
	AudioClip clockPickUpSound;

	// Use this for initialization
	public void Start () {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        disabled = false; //not disabled at start of the game

		camera = GameObject.Find ("Main Camera");
		audio = camera.GetComponent<AudioSource> ();
		audioClipsList = camera.GetComponent<AudioClips> ().audioClips;
		clockPickUpSound = audioClipsList [1];
	}

    // Update is called once per frame
    public void Update () {

        if (disabled == false)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-playerSpeed, rb.velocity.y);
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
            }

            else
            {
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, -playerSpeed);
            }

            else if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, playerSpeed);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            }

        }
        //make transition of idle animation to walking animation with boolean 
        if(rb.velocity.magnitude > 0.01f)
        {
            GetComponent<Animator>().SetBool("isWalking", true);

        }

        if(rb.velocity.magnitude <= 0.01f)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }


    }
    public void OnTriggerEnter2D(Collider2D peerCol)
    {
        if (peerCol.gameObject.tag == "Peers")
        {
            disabled = true;
            Invoke("ResetDisabled", 5.0f); //after 5 seconds call ResetDisabled()
            peerCol.gameObject.SendMessage("DisablePeers");
        }

            switch (peerCol.gameObject.tag)
            {
                case "plus3":
                    myInstanceOfCountdowntime.startingTime += 3f;
                    peerCol.gameObject.SetActive(false);
                    break;
            }
    }

    void ResetDisabled()
    {
        disabled = false;
    }

}
