using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Author: Owen.Gunter
 Purpose: Gives the player the ability to shoot
 Date: 05/09/2018
 
  */
public class PlayerShooting : MonoBehaviour {

    public Rigidbody fireball;
    
    public Transform firetransform;
    // how fast the bullet goes
    public float launchforce = 30f;


	
	// Update is called once per frame
	void Update () {
		// if press leftclick call Fire function
        if(Input.GetButtonUp("Fire1"))
        {
            //print("i have fired");
            Fire();
        }
	}
    // responsible for creating the bullet object each time player press left click
    // and then launch the object forward
    private void Fire()
    {
        Rigidbody fireballInstance = Instantiate(fireball, firetransform.position, firetransform.rotation) as Rigidbody;

        fireballInstance.velocity = launchforce * firetransform.forward;
    }
}
