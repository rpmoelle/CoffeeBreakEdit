using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour {

    public GameObject currentInterObj = null;
    public RedCup currentInterObjScript = null;
    public InventoryScript inventory;

    // Update is called once per frame

    void Update()
    {   //pick up the red cup
        //if (Input.GetButtonDown("Interact") && currentInterObj)
        if (currentInterObj)
        {
            //check to see if object can be stored to inventory
            if (currentInterObjScript.inventory) //check inventory bool
            {
                inventory.AddItem(currentInterObj);
                currentInterObj.SendMessage("DoInteraction");
            }
            

            //check to see if we can get coffee
            if (currentInterObjScript.working)
            {


                if (currentInterObjScript.getCoffee)
                {
                    //check inventory to see if we have cup to get coffee
                    if (inventory.FindItem(currentInterObjScript.itemNeeded))
                    {
                        //we found the item needed
                        currentInterObjScript.getCoffee = false;
                        Debug.Log(currentInterObj.name + " got coffee");
                        SceneManager.LoadScene(3);//you win
                    }
                   
                    else{
                    currentInterObjScript.pourCoffee();
                        
                    }
                }
            }
        }
    }

    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("interObj"))
        {
            Debug.Log(col.name);
            currentInterObj = col.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<RedCup>();
            
            //currentInterObj.transform.parent = transform;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == currentInterObj)
        {
            currentInterObj = null;
        }
    }
    
}
