using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    //Author: Owen.Gunter
    //Purpose: to give properties to bullet
    //Date: 06/09/2018

    HealthState healthState;    // Reference to the entity's health.

    public float attackDamage; // Set the attack damage
    float MaxLifeTime;

    void Start () {
        // if it isnt already destroyed kill object after 2 seconds
		//Destroy(gameObject,MaxLifeTime);
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





}
