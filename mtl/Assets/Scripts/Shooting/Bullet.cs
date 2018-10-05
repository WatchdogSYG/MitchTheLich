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

    HealthState healthState;    // Reference to the player's health.
    GameObject player;          // Reference to the player GameObject.
    public float attackDamage = mtl.Damage.DEV_TEST_BULLET_DAMAGE; // Set the attack damage
    //mtl.Damage attackDamage;



    public float MaxLifeTime = mtl.Movement.BASE_PROJECTILE_LIFETIME;//MDT_Brandon cleaned up



    void Awake()
    {//Setting references
        player = GameObject.FindGameObjectWithTag("Player");
        healthState = player.GetComponent<HealthState>();//
		//Error: Object reference not set to an instance of an object
       // GetComponent<HealthState>().TakeDamage(attackDamage);
       //attackDamage = GetComponent<mtl.Damage>();

    }



    void Start () {
        // if it isnt already destroyed kill object after 2 seconds
        Destroy(gameObject, MaxLifeTime);
		
	}
	
	
	void OnCollisionEnter (Collision other)
    {
		//other.gameObject.GetComponent<HealthState>().TakeDamage(mtl.Damage.DEV_TEST_BULLET_DAMAGE);
		Destroy(gameObject);
        Damage(); //Call damage on collision

	}

    void Damage()
    {
        // If the player has health to lose...
        if (healthState.currentHealth > 0)
        {
            // damage the player
            healthState.TakeDamage(attackDamage);
        }
    }
}
