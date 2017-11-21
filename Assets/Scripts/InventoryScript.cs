using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {
    //creating an inventory for the player
    public GameObject[] inventory = new GameObject[2];
	public GameObject camera;

	//variables for handling sound effects
	AudioSource audio;
	AudioClips audioClipList;
	AudioClip getCupSound;

	void Start (){
		audio = camera.GetComponent<AudioSource> ();
		audioClipList = camera.GetComponent<AudioClips> ();
		getCupSound = audioClipList.audioClips [0];
	}

	//i am a test comment!

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory [i] == null)
            {
                inventory[i] = item;

				//if the item is the red cup, play the pickup sound
				if (item.name == "redcup")
					audio.PlayOneShot (getCupSound);
				
                Debug.Log(item.name + " was added");
                itemAdded = true;
                break;
            }
        }

        //if inventory full
        if (!itemAdded)
        {
            Debug.Log("Inventory is Full!");
        }
    }

    public bool FindItem(GameObject item) //check if we have the item needed to interact with object
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory [i] == item)
            {
                return true;
            }
        }
        //if item not found
        return false;
    }
}
