using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	//Author Owen.Gunter
	//Purpose: To give bunny the abitlity to deal damage to player
	//Date: 01/11/2018

	HealthState healthState;    // Reference to the player's health.
	GameObject player;          // Reference to the player GameObject.
	public float attackDamage = mtl.Damage.DEV_TEST_BULLET_DAMAGE; // Set the attack damage for Bunny

	void Awake()
	{//Setting references
		player = GameObject.FindGameObjectWithTag("Player");
		healthState = player.GetComponent<HealthState>();//
	}

	void OnTriggerEnter (Collider other)
	{


		if(other.gameObject.tag == "Player")
		{
			//Call DamagePlayer on collision
			DamagePlayer(); 
		}

	}

	void DamagePlayer()
	{
		// If the player has health to lose...
		if (healthState.currentHealth > 0)
		{
			// damage the player
			healthState.TakeDamage(attackDamage);

		}
	
	}



}
