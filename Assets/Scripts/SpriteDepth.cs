using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDepth : MonoBehaviour {
    SpriteRenderer ren;
    public SpriteRenderer shadow;
	// Use this for initialization
	void Start () {
        ren = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //change the sprite depth based on it height on the screen

        ren.sortingOrder = (int)(transform.position.y*-100f);
        shadow.sortingOrder = ren.sortingOrder - 200;

	}
}
