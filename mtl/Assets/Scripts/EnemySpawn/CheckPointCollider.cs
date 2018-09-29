using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollider : MonoBehaviour {

	//Author: Owen.Gunter
	//Purpose: To spawn an enemy in the game world via a collider
	//Date: 24/09/2018
	// reference to EnemySpawn script
	public EnemySpawn es;
	// this variable is used to make sure that
	// the trigger event only occurs once
	public int counter = 0;


	void OnTriggerEnter(Collider other)
	{
		//if tag on the game object = "player
		if (other.gameObject.tag == "Player") 
		{
			//increment counter
			counter++;

			// if counter = 1
			// call the EnemySpawner function from EnemySpawn script
			if (counter == 1) 
			{
				es.EnemySpawner ();
				print ("CheckPoint1 Cleared");
				print ("1 Bunny should've spawned");
			}
		


		}
	}




}
