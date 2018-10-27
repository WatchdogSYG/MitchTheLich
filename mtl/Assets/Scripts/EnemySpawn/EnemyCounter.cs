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
	void Update () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("BunnyCheck");
        remainingEnemies = enemies.Length;

        if (remainingEnemies == 0)
        {
            Fungus.Flowchart.BroadcastFungusMessage("cleared");
        }
    }
}
