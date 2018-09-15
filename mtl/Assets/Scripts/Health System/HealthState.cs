//MDT_Brandon startContribution
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthState : MonoBehaviour {

	public float currentHealth;
	public float speedMultiplier = 1;

	// Use this for initialization
	void Start () {
		//what object is this? set health to appropriate value as defined in mtl class
		currentHealth = mtl.Health.AssignState(gameObject.tag);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			Death();
		}

		



		if (currentHealth <= 0) {
			Death();
		}
	}

	public void TakeDamage(float damage) {
		currentHealth -= damage;
		Debug.Log(gameObject.tag + " has taken " + damage.ToString("F0") + " damage! It now has " + currentHealth.ToString("F0") + "HP.");
		return;
	}

	void Death() {
		Debug.Log("oh noes");
		return;
	}
}
//MDT_Brandon startContribution