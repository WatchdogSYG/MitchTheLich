using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRepeat : MonoBehaviour {

	//Author: Owen.Gunter
	//Purpose: To repeatbly spawn an enemy at a location every 2 seconds up to 5 enemies for now
	//Date: 24/09/2018
	//reference to bunny prefab
	public Rigidbody bunny;
	//reference to BunnySpawnRepeat object in Inspector
	public Transform enemyspawner;
	// this delays each spawn by a particular time
	public float spawnDelay = mtl.EnemySpawner.spawnTimer;
	// starts at zero and equals whatever time.time was before
	private float lastSpawnTime;
	// this controls the total amount of enemies that can be spawned from the enemyspawner transform
	public int counter = mtl.EnemySpawner.AmountOfEnemies;

	void Update()
	{
		//Calls the EnemySpawnerR function
		EnemySpawnerR ();

	}
	public void EnemySpawnerR()
	{
		//Time.time means the time in seconds since start of the game
		// if time is greater than the last time it spawned plus whatever the delay is
		// set lastFireTime = to the current time
		// and create a bunny at the location of where the enemyspawner transform is
		if (Time.time > (lastSpawnTime + spawnDelay) && counter < 5) {
			lastSpawnTime = Time.time;
			Instantiate (bunny, enemyspawner.position, enemyspawner.rotation);
			counter++;
			print ("bunny number " + counter + " created ");
		}

	}
}
