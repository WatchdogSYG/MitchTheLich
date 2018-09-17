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

	Edited: MDT_Owen 17/09/18: Added two rigidbodys with different colours that represent different bullets
	//also this script can now fire any prefab as long as its defined in mitch_spellcaster
	//you should be able to custimose a particular bullet without effecting the other
  */
public class ProjectileLauncher : MonoBehaviour {

	//two rigidbodys which are in prefabs

	public Rigidbody Element1RedBullet;
	public Rigidbody Element2BlueBullet;

	//this is where the bullet spawns
	public Transform projectileSpawner;
	// how fast the bullet goes
	public float launchSpeed = mtl.Movement.BASE_PROJECTILE_SPEED;

	//private boolean variables which basically acts like a switch
	//Example:
	//if 1 is pressed run this code and disable element 2 code
	//if 2 is pressed run this code and disable element 1 code
	private bool Element1IsReady = false;
	private bool Element2IsReady = false;


	// Update is called once per frame
	void Update() {
		gameObject.transform.forward = (CursorTargeting.mouseWorldPoint - gameObject.transform.position) + new Vector3 (1, 0, 1);
		Debug.DrawRay (gameObject.transform.position, gameObject.transform.forward * 20f);
		// if press 1 set boolean variable to true and other false
		if (Input.GetButtonUp ("Element1")) 
		{
			// 1 is now active and 2 is not
			Element1IsReady = true;
			Element2IsReady = false;
			//debug
			print ("element1 is ready" + Element1IsReady);
		}

		//if press 2 set boolean variable to true and other false
		if (Input.GetButtonUp ("Element2")) 
		{
			// 2 is active and 1 is not
			Element2IsReady = true;
			Element1IsReady = false;
			//debug
			print ("element2 is ready" + Element2IsReady);
		}

		//if leftclick and 1 was pressed run this Element1Fire code
		if (Input.GetButtonUp ("Primary Fire") && Element1IsReady == true) {
			print ("i have fired");
			Element1Fire ();
		}
		//if leftclick and 2 was pressed run this Element2Fire code
		if (Input.GetButtonUp ("Primary Fire") && Element2IsReady == true) {
			print ("i have fired");
			Element2Fire ();
		}

	}
	// responsible for creating the bullet object each time player press left click
	// and then launch the object forward
	private void Element1Fire() {
		Rigidbody projectileInstance = Instantiate(Element1RedBullet, projectileSpawner.position, projectileSpawner.rotation) as Rigidbody;

		projectileInstance.velocity = launchSpeed * projectileSpawner.forward;
	}

	// and then launch the object forward
	//Both of these are the same except now it launches a different bullet
	//you can change either ones propeties as you wish
	private void Element2Fire() {
		Rigidbody projectileInstance = Instantiate(Element2BlueBullet, projectileSpawner.position, projectileSpawner.rotation) as Rigidbody;

		projectileInstance.velocity = launchSpeed * projectileSpawner.forward;
	}
}
