using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	HealthState healthState;    // Reference to the player's health.
	GameObject player;          // Reference to the player GameObject.
	public float attackDamage = mtl.Damage.DEV_TEST_BULLET_DAMAGE; // Set the attack damage
	private bool whoIsHit = false;

	void Awake()
	{//Setting references
		player = GameObject.FindGameObjectWithTag("Player");
		healthState = player.GetComponent<HealthState>();//
		//Error: Object reference not set to an instance of an object
		// GetComponent<HealthState>().TakeDamage(attackDamage);
		//attackDamage = GetComponent<mtl.Damage>();
		//why player specifically

	}

	void OnTriggerEnter (Collider other)
	{

		//other.gameObject.GetComponent<HealthState>().TakeDamage(mtl.Damage.DEV_TEST_BULLET_DAMAGE);
		if(other.gameObject.tag == "Player")
		{
			//Destroy(gameObject);
			DamagePlayer(); //Call damage on collision
		}
		//why player specifically
	}

	void DamagePlayer()
	{
		// If the player has health to lose...
		if (healthState.currentHealth > 0)
		{
			// damage the player
			healthState.TakeDamage(attackDamage, whoIsHit);

		}
		//redundant if, it already checks in healthstate update.
	}



}
