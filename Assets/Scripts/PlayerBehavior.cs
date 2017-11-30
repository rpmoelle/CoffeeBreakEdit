using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    public Sprite[] sprites;
    public float playerSpeed;
    private bool disabled; //player disable movement
    public CountdownTime myInstanceOfCountdowntime;
    public ParticleSystem stars_ps;
    public ParticleSystem boink_ps;
    //public bool canMove;

    Animator characterAnimator;
    Rigidbody2D rb;
    SpriteRenderer sr;

	// Use this for initialization
	public void Start () {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        disabled = false; //not disabled at start of the game
        //canMove = true;
	}

    // Update is called once per frame
    public void Update () {

        if (disabled == false)
        {

			if (Input.GetKey (KeyCode.A)) {
				rb.velocity = new Vector2 (-playerSpeed, rb.velocity.y);
				GetComponent<Animator> ().SetBool ("isRunning", true);
				GetComponent<Animator> ().SetBool ("isWalking", false);
				sr.flipX = true;

			} else if (Input.GetKey (KeyCode.D)) {
				rb.velocity = new Vector2 (playerSpeed, rb.velocity.y);
				GetComponent<Animator> ().SetBool ("isRunning", true);
				GetComponent<Animator> ().SetBool ("isWalking", false);

				sr.flipX = false;

			} else if (Input.GetKey (KeyCode.S)) {
				GetComponent<Animator> ().SetBool ("isRunning", false);
				GetComponent<Animator> ().SetBool ("isWalking", true);

			} else if (Input.GetKey (KeyCode.W)) {
				GetComponent<Animator> ().SetBool ("isRunning", false);
				GetComponent<Animator> ().SetBool ("isWalking", true);
			}

            else
            {
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
				GetComponent<Animator>().SetBool ("isRunning", false);
				GetComponent<Animator>().SetBool ("isWalking", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(rb.velocity.x, -playerSpeed);
				/*GetComponent<Animator>().SetBool ("isWalking", true);
				GetComponent<Animator>().SetBool ("isRunning", false); */

            }

            else if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x, playerSpeed);
				/*GetComponent<Animator>().SetBool ("isWalking", true);
				GetComponent<Animator>().SetBool ("isRunning", false); */
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
				/*GetComponent<Animator>().SetBool ("isWalking", false);
				GetComponent<Animator>().SetBool ("isRunning", false); */
            }

        }
        //make transition of idle animation to walking animation with boolean 
        /*if(rb.velocity.magnitude > 0.01f)
        {
            GetComponent<Animator>().SetBool("isWalking", true);

        }

        if(rb.velocity.magnitude <= 0.01f)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }*/


    }

    public void OnTriggerEnter2D(Collider2D peerCol)
    {
        if (peerCol.gameObject.tag == "Peers")
        {
            disabled = true;

			if (disabled == true) {
				GetComponent<Animator> ().SetBool ("isDizzy", true);
				GetComponent<Animator> ().SetBool ("isWalking", false);
				GetComponent<Animator> ().SetBool ("isRunning", false);
			}

            Invoke("ResetDisabled", 2.0f); //after 5 seconds call ResetDisabled()
            peerCol.gameObject.SendMessage("DisablePeers");
            //play the particle bursts
            stars_ps.Play();
            boink_ps.Play();

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
		GetComponent<Animator> ().SetBool ("isDizzy", false);
        //turn off the particle bursts
        stars_ps.Stop();
       boink_ps.Stop();
    }

}
