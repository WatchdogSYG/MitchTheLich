using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour {

    // Use this for initialization
    int remainingEnemies = 0;

    void Start () {
        int remainingEnemies = 20;
    }
	
	// Update is called once per frame
    // When Bunnycheck has no objects attached to the tag, call the fungus message. 
    // When bunnies are spawned, they are added to the enemies array. Constantly checks to see if the array is empty. 
	void Update () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("BunnyCheck");
        remainingEnemies = enemies.Length;

        if (remainingEnemies == 0)
        {
            Fungus.Flowchart.BroadcastFungusMessage("cleared");
        }
    }
}
