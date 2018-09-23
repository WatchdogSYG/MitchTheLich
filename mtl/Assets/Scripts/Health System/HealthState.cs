//MDT_Brandon startContribution
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthState : MonoBehaviour {

	public float currentHealth;
	public float currentMana;
	public float maxHealth;
	public float maxMana;

	public float speedMultiplier = 1f;
	public float manaRegenRate = mtl.Buff.DEFAULT_MANA_REGEN;
	public float manaRegenMultiplier = 1f;

	//unused concept buffs
	/*
	public float damageDealtMultiplier = 1f;
	public float damageTakenMultiplier = 1f;
	public float healthRegenRate = 0f;
	public float lifeStealMagnitude = 0f;
	public bool redirectSpell = false;
	public bool spreadOnContact = false;
	*/

	// Use this for initialization
	void Start () {
		//what object is this? set stats to appropriate values as defined in mtl class
		maxHealth = mtl.Health.AssignHealth(gameObject.tag);
		maxMana = mtl.Buff.AssignMana(gameObject.tag);

		currentHealth = maxHealth;
		currentMana = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//refresh stats
		if (currentMana < maxMana) {
			UseMana(-manaRegenRate * manaRegenMultiplier * Time.deltaTime);
		}
		else {
			currentMana = maxMana;
		}
	}

	public void TakeDamage(float damage) {
		currentHealth -= damage;
		//this debug gets annoying if it regens per frame
		//Debug.Log(gameObject.tag + " has taken " + damage.ToString("F0") + " damage! It now has " + currentHealth.ToString("F0") + "HP.");
		
		//an entity can only die if it takes damage, therefore check for death here
		if (currentHealth <= 0) {
			Death();
		}
		return;
	}

	public void UseMana(float mana) {
		currentMana -= mana;
		//this debug gets annoying if it regens per frame
		//Debug.Log(gameObject.tag + " has used " + mana.ToString("F0") + " mana! It now has " + currentMana.ToString("F0") + "MP.");
		
		//an entity can only die if it takes damage, therefore check for death here
		if (currentHealth <= 0) {
			Death();
		}
		return;
	}

	void Death() {
		Debug.Log("oh noes");
		return;
	}
}
//MDT_Brandon startContribution