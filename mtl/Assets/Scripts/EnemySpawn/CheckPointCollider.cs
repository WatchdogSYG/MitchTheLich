using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollider : MonoBehaviour {

    //Author: Owen.Gunter
    //Changes: Seth.Touchette -- included repeater
    //Purpose: To spawn an enemy in the game world via a collider
    //Date: 24/09/2018
    //Date: 18/10/2018 
    // reference to EnemySpawn script
    public GameObject bunny;
    GameObject bunnyClone;
    public Transform enemyspawner1;
    public Transform enemyspawner2;
    public Transform enemyspawner3;
    public Transform enemyspawner4;
    public Transform enemyspawner5;



    // this variable is used to make sure that
    // the trigger event only occurs once
    public int counter = 0;


	void OnTriggerEnter(Collider other)
	{
		//if tag on the game object = "player
		if (other.gameObject.tag == "Player") 
		{
            Instantiate(bunny, enemyspawner1.position, enemyspawner1.rotation);
            Instantiate(bunny, enemyspawner2.position, enemyspawner2.rotation);
            Instantiate(bunny, enemyspawner3.position, enemyspawner3.rotation);
            Instantiate(bunny, enemyspawner4.position, enemyspawner4.rotation);
            Instantiate(bunny, enemyspawner5.position, enemyspawner5.rotation);


        }
	}




}
