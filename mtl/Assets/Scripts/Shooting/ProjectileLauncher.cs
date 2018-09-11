using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Author: Owen.Gunter
 Purpose: Gives the player the ability to shoot
 Date: 05/09/2018
 
	Edited: MDT_Brandon 11/09/18: renamed variables to make them physically meaningful, removed hard coding of variables.
	TODO: make this script fire any prefab, 
	remove hard dependency on the Primary Fire button so other things can be done with it,
	make the speed of the projectile dependent on the prefab
  */
public class ProjectileLauncher : MonoBehaviour {

	public Rigidbody projectile;

	public Transform projectileSpawner;
	// how fast the bullet goes
	public float launchSpeed = mtl.Projectile.BASE_PROJECTILE_SPEED;



	// Update is called once per frame
	void Update() {
		// if press leftclick call Fire function
		if (Input.GetButtonUp("Primary Fire")) {
			//print("i have fired");
			Fire();
		}
	}
	// responsible for creating the bullet object each time player press left click
	// and then launch the object forward
	private void Fire() {
		Rigidbody projectileInstance = Instantiate(projectile, projectileSpawner.position, projectileSpawner.rotation) as Rigidbody;

		projectileInstance.velocity = launchSpeed * projectileSpawner.forward;
	}
}
