using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButtons : MonoBehaviour {

	// Use this for initialization
	public void Play ()
    {
		SceneManager.LoadScene(1);//change to scene 1 (game scene)
	}
	
    public  void HowToPlay()
    {
        SceneManager.LoadScene(2); //change to scene 2 (tutorial)
    }
}
