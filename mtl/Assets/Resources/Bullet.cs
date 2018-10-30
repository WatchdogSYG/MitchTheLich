using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    //Author: Owen.Gunter
    //Purpose: to give properties to bullet
    //Date: 06/09/2018

   
    //Edit Author - Timothy
    //Purpose: to give damage to the bullet when it hits the player

   // public int attackDamage = 10; //The amount of health damaged

    HealthState healthState;    // Reference to the entity's health.

    float attackDamage; // Set the attack damage
    float MaxLifeTime;//MDT_Brandon cleaned up

    void Awake()
    {//Setting references
	 //player = GameObject.FindGameObjectWithTag("Player");
	 //healthState = gameObject.GetComponent<HealthState>();//we cant call this now, there is no gameobject!
	 //Error: Object reference not set to an instance of an object
	 // GetComponent<HealthState>().TakeDamage(attackDamage);
	 //attackDamage = GetComponent<mtl.Damage>();
	 //why player specifically
		Fireball f = ScriptableObject.CreateInstance<Fireball>();

		attackDamage = f.damage; // Set the attack damage
		MaxLifeTime = f.lifetime;
	}



    void Start () {
        // if it isnt already destroyed kill object after 2 seconds
        //Destroy(gameObject, MaxLifeTime);
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        Destroy(ps, ps.main.duration);
	}


	//modified from OnCollisionEnter(Collision other)
	//to OnTriggerEnter and (Collider other)
	void OnTriggerEnter (Collider other)
    {
		print(gameObject.tag + " has collided with " + other.gameObject.tag + ".");
		healthState = other.GetComponent<HealthState>();

		/*if(other.gameObject.tag == "Player")
		{*/
		Destroy(gameObject);
        Damage(); //Call damage on collision
		ApplyBuff(other.gameObject);
		//if bullet == iceball call make variable in healthState isSlowed equal to true
		if (gameObject.tag == "Iceball") {
			healthState.isSlowed = true;

		} else 
		{
			//if get hit by anything other than iceball set multiplier back to 1
			healthState.speedMultiplier = 1f;
		}
	}
		
	
    void Damage()
    {
		healthState.TakeDamage(attackDamage);
    }

	void ApplyBuff(GameObject o) {
		//check if buffable
		Buffable b = o.GetComponent<Buffable>();
		if (b) {
			Fireball f = ScriptableObject.CreateInstance<Fireball>();
			print(o.tag + " is Buffable, applying buffs.");
			f.ApplyBuffs(o);
		} else {
			print(o.tag + " is immune to buffs!");
		}
	}




}
