using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

	//Author Owen.Gunter
	//Purpose: To give the enemy the ability to look at the player and shoot at a particular distance
	//Date: 19/09/2018

	//rigidbody for enemy bullet
	public Rigidbody EnemBullet;
	// transform for projectileSpawner which is Enemy_Spellcaster(1) in scene Attached to EnemyPlaceHolder
	public Transform projectileSpawner;
	// how fast the projectile goes
	public float launchSpeed = mtl.Movement.BASE_PROJECTILE_SPEED;
	// How long it takes for the next shot to fire
	public float delay = mtl.EnemyShooting.DelayBetweenShots;
	//this is the maximum distance from the enemy to the player that the enemy will be able to shoot
	public int maxAttackDistance = mtl.EnemyShooting.MaxDistance;

	//target is the player
	public Transform target;

	// starts at zero and equals whatever Time.time was before
	private float lastFireTime;
	void Start()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	void Update()
	{
		//if target is not null which will always be true
		//Look at the target which is the player
		if (target != null) 
		{
			transform.LookAt (target);
		}
		//this gets the distance from the enemy to the player at every frame
		float distance = Vector3.Distance (target.position, transform.position);
		//print (distance);
		//print (maxAttackDistance);
	
		//Time.time means the time in seconds since start of the game
		//if the current distance is less than the maxAttackDistance and...
		// if time is greater than the last time it fired plus whatever the delay is
		// set lastFireTime = to the current time
		// and call Fire function
		if ((distance <= maxAttackDistance) && Time.time > (lastFireTime + delay)) {
			
			//print (Time.time);
		//	print (lastFireTime);
			lastFireTime = Time.time;
			Fire ();
		}
			
	}

	//same Fire() function as in Mitch_SpellCaster but with EnemyBullet
	private void Fire()
	{
		Rigidbody projectileInstance = Instantiate(EnemBullet, projectileSpawner.position, projectileSpawner.rotation) as Rigidbody;

		projectileInstance.velocity = launchSpeed * projectileSpawner.forward;

	}
		
}
