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

    public float attackDamage = mtl.Damage.DEV_TEST_BULLET_DAMAGE; // Set the attack damage

    public float MaxLifeTime = mtl.Movement.BASE_PROJECTILE_LIFETIME;//MDT_Brandon cleaned up

	private bool cooldown = false;
	private bool isSlowed = false;
	private float lastDelayTime = 2f;
	private float slowDuration = 2f;
    void Awake()
    {//Setting references
        //player = GameObject.FindGameObjectWithTag("Player");
       //healthState = gameObject.GetComponent<HealthState>();//we cant call this now, there is no gameobject!
		//Error: Object reference not set to an instance of an object
       // GetComponent<HealthState>().TakeDamage(attackDamage);
       //attackDamage = GetComponent<mtl.Damage>();
       //why player specifically

    }



    void Start () {
        // if it isnt already destroyed kill object after 2 seconds
        Destroy(gameObject, MaxLifeTime);
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        Destroy(ps, ps.main.duration);

	}

	//this code should work but doesnt as this code never runs 
	//also delay code has to be in Update for it to work
	/*public void Update()
	{
		print ("hey its fred");
		if (isSlowed == true) 
		{
			healthState.speedMultiplier = 0.5f;
			lastDelayTime -= Time.deltaTime;
			print ("im slowed");
			print (lastDelayTime);
			if (lastDelayTime <= 0) 
			{
				isSlowed = false;
				lastDelayTime = slowDuration;
				healthState.speedMultiplier = 3f;
				print ("OH BABY");
			}

		}
	}	*/
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
		//if bullet == iceball call slowEnemyDown function
		if (gameObject.tag == "Iceball") {
			isSlowed = true;
			print (isSlowed);
			//lastDelayTime = 2f;
			healthState.speedMultiplier = 0.5f;


		} 
		else 
		{
			healthState.speedMultiplier = 1f;
		}
        //why player specifically
	}
		
	
    void Damage()
    {
		healthState.TakeDamage(attackDamage);
		// If the player has health to lose...
		/*if (healthState.currentHealth > 0)
        {
            // damage the player
			

        }*/
        //redundant if, it already checks in healthstate update.
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
