using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
		//Author: Owen.Gunter
	    /*Purpose: gives the player the ability to shoot
        Date: 05/09/2018
      
     	Edited: MDT_Owen 17/09/18: Added two rigidbodys with different colours that represent different bullets
     	//also this script can now fire any prefab as long as its defined in mitch_spellcaster
     	//you should be able to custimose a particular bullet without effecting the other
         Edited: MDT_Timothy 28?09/2018: Edited to add mana use
       */
     	//three rigidbodys which are in prefabs

     	public Rigidbody Element1RedBullet;
     	public Rigidbody Element2BlueBullet;
     	public Rigidbody Element3FlameThrower;

     	//this is where the bullet spawns
     	public Transform projectileSpawner;
     	// how fast the bullet goes
	public float launchSpeed = mtl.Spell.BaseProjectileSpeed;
	public float launchSpeed2 = mtl.Spell.IceProjectileSpeed;
	public float launchSpeed3 = mtl.Spell.FlameThrowerProjectileSpeed;
     	//variables for delay between shots
     	public float shotDelay = mtl.Spell.BaseShotDelay;
		public float shotDelay2 = mtl.Spell.IceShotDelay;
		public float shotDelay3 = mtl.Spell.FlameThrowerShotDelay;


     	//private boolean variables which basically acts like a switch
     	//Example:
     	//if 1 is pressed run this code and disable element 2 code
     	//if 2 is pressed run this code and disable element 1 code
     	private bool Element1IsReady = true;
     	private bool Element2IsReady = false;
     	private bool Element3IsReady = false;

     	//starts at zero and equals what ever Time.time was before
     	private float lastFireTime;

         GameObject player;
         HealthState healthState;
         public float Attackmana = mtl.Buff.PLAYER_DEFAULT_MANA; //set the mana used

         void Awake()
         {

             player = GameObject.FindGameObjectWithTag("Player");
             healthState = player.GetComponent<HealthState>(); ; 
     		//Object reference not set to an instance of an object
             //GetComponent<HealthState>().UseMana(Attackmana);
         }



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
     			Element3IsReady = false;
				launchSpeed = mtl.Spell.BaseProjectileSpeed;
				shotDelay = mtl.Spell.BaseShotDelay;
     			//debug
     			print ("element1 is ready" + Element1IsReady);
     		}

     		//if press 2 set boolean variable to true and other false
     		if (Input.GetButtonUp ("Element2")) 
     		{
     			// 2 is active and 1 is not
     			Element3IsReady = false;
     			Element2IsReady = true;
     			Element1IsReady = false;
			launchSpeed = mtl.Spell.IceProjectileSpeed;
				shotDelay2 = mtl.Spell.IceShotDelay;
     			//debug
     			print ("element2 is ready" + Element2IsReady);
     		}

     		if (Input.GetButtonUp ("Element3")) 
     		{
     			// 2 is active and 1 is not
     			Element3IsReady = true;
     			Element2IsReady = false;
     			Element1IsReady = false;
				launchSpeed = mtl.Spell.FlameThrowerProjectileSpeed;
				shotDelay3 = mtl.Spell.FlameThrowerShotDelay;
     			//debug
     			print ("element3 is ready" + Element3IsReady);
     		}


     		//if leftclick and 1 was pressed run this Element1Fire code
     		if (Input.GetButtonUp ("Primary Fire") && Element1IsReady == true) {
     			print ("i have fired");
     			if (healthState.currentMana > 10 && (Time.time > (lastFireTime + shotDelay)))
                 {
     					lastFireTime = Time.time;
                     Element1Fire();
                     Mana();
                 }
                 
             }
     		//if leftclick and 2 was pressed run this Element2Fire code
     		if (Input.GetButtonUp ("Primary Fire") && Element2IsReady == true) {
     			print ("i have fired");
     			if (healthState.currentMana > 10 && (Time.time > (lastFireTime + shotDelay2)))
                 {
     				lastFireTime = Time.time;
                     Element2Fire();
                     Mana();
                 }
                 
     		}

     		//if leftclick and 3 was pressed run this Element3Fire code
     		if (Input.GetButton ("Primary Fire") && Element3IsReady == true) {
     			print ("i have fired");
			if (healthState.currentMana > 10 && (Time.time > (lastFireTime + shotDelay3)))
     			{
					lastFireTime = Time.time;
     				Element3Fire();
     				Mana();
     			}

     		}

     	}
     	// responsible for creating the bullet object each time player press left click
     	// and then launch the object forward
     	private void Element1Fire() {
     		
     	    Rigidbody projectileInstance = Instantiate(Element1RedBullet, projectileSpawner.position, projectileSpawner.rotation) as Rigidbody;

     		projectileInstance.velocity = launchSpeed * projectileSpawner.forward;

		print ("ha");
     	}

     	// and then launch the object forward
     	//Both of these are the same except now it launches a different bullet
     	//you can change either ones propeties as you wish
     	private void Element2Fire() {
		
     		Rigidbody projectileInstance = Instantiate(Element2BlueBullet, projectileSpawner.position, projectileSpawner.rotation) as Rigidbody;

     		projectileInstance.velocity = launchSpeed2 * projectileSpawner.forward;



     	}

     	private void Element3Fire() {
     		Rigidbody projectileInstance = Instantiate(Element3FlameThrower, projectileSpawner.position, projectileSpawner.rotation) as Rigidbody;

     		projectileInstance.velocity = launchSpeed3 * projectileSpawner.forward;
     	}



         void Mana()
          {
              if (healthState.currentMana > 0)
              {
                  healthState.UseMana(Attackmana);
              }
          }
     }
