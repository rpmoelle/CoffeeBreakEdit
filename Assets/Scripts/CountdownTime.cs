using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTime : MonoBehaviour {
    //making a countdown timer
    public float startingTime;
    private Text theText;
    //Control the bar
    public Image coffeeBar;
    public Image coffeeBar_BG;

    //stole this from online
    public float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }

    void Start()
    {

        theText = GetComponent<Text>();
        
    }

    void Update()
    {

        startingTime -= Time.deltaTime; //counts down from the starting time
        theText.text = "" + Mathf.Round (startingTime); //Using Matf rounds the numbers counting down
        if (startingTime < 0)
        {
            startingTime = 0;
            SceneManager.LoadScene("GameOver");
        }

        //Lower the coffee bar by rescaling vertically and mapping to remaining time
        float mappedTimeVal = scale(0f,60f,0f, .9f,startingTime);
        coffeeBar.transform.localScale = new Vector3(mappedTimeVal, coffeeBar.transform.localScale.y, coffeeBar.transform.localScale.z);
       // coffeeBar.transform.position = new Vector3(coffeeBar.transform.position.x, coffeeBar.transform.position.y - .08f, coffeeBar.transform.position.z);
       if(startingTime < 30)
        {
            //
            Debug.Log("Hello? 30");
        }
        if (startingTime < 15)
        {
            //coffeeBar_BG.color = Color.red;
            coffeeBar_BG.color = new Color(coffeeBar_BG.color.r, coffeeBar_BG.color.g - .005f, coffeeBar_BG.color.b - .005f);
        }


    }
}