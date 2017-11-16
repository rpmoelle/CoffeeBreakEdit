using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {
    //creating an inventory for the player
    public GameObject[] inventory = new GameObject[2];

    public void AddItem(GameObject item)
    {

        bool itemAdded = false;

        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory [i] == null)
            {
                inventory[i] = item;
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
