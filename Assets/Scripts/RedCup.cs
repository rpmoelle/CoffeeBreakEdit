using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCup : MonoBehaviour {

    public bool inventory; //if true this object can be stored in inventory
    public bool getCoffee; //if true can get coffee
    public bool working;
    public GameObject itemNeeded; //item needed inorder to interact with coffee machine
    public Animator anim;

    public void DoInteraction()
    { 
        //pick up and put in inventory
        gameObject.SetActive(false);
    }

    public void pourCoffee()
    {
        anim.SetBool("pour", true);
    }

  //  void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.transform.tag == "Player")
     //   {
     //       transform.parent = col.transform;
    //    }
   // }


}
