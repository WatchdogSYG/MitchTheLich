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

    public float launchforce = 30f;


	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonUp("Fire1"))
        {
            //print("i have fired");
            Fire();
        }
	}

    private void Fire()
    {
        Rigidbody fireballInstance = Instantiate(fireball, firetransform.position, firetransform.rotation) as Rigidbody;

        fireballInstance.velocity = launchforce * firetransform.forward;
    }
}
