using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	//Author: Owen.Gunter
	//Purpose: To spawn an enemy in the game world via a collider
	//Date: 24/09/2018
	//reference to bunny prefab
	public Rigidbody bunny;
	//reference to BunnySpawnCheckPoint object in Inspector
	public Transform enemyspawner;



	public void EnemySpawner()
	{
		//when this function is called from CheckPointCollider
		//spawn a bunny where the transform is
		Instantiate (bunny, enemyspawner.position, enemyspawner.rotation);


	}
}
