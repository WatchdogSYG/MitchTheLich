using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    //Author: Owen.Gunter
    //Purpose: to give properties to bullet
    //Date: 06/09/2018

    // Use this for initialization

    public float MaxLifeTime = 2f;
	void Start () {
        // if it isnt already destroyed kill object after 2 seconds
        Destroy(gameObject, MaxLifeTime);
		
	}
	
	
	void OnCollisionEnter (Collision other)
    {
        Destroy(gameObject);
	}
}
