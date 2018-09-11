using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthState : MonoBehaviour {

	float currentHealth;

	// Use this for initialization
	void Start () {
		//what object is this?
		//to abstract
		currentHealth = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth <= 0) {
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
