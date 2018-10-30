using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_BlackHole : MonoBehaviour {
	HealthState healthState;    // Reference to the entity's health.
	public GameObject PullSphere;

	float attackDamage; // Set the attack damage
	float MaxLifeTime;//MDT_Brandon cleaned up

	void Awake() {
		SoulVortex sv = ScriptableObject.CreateInstance<SoulVortex>();

		attackDamage = sv.damage;
		MaxLifeTime = sv.lifetime;
	}



	void Start() {
		ParticleSystem ps = GetComponent<ParticleSystem>();
		ps.Play();
		Destroy(ps, ps.main.duration);
	}
	
	void OnTriggerEnter(Collider other) {
		print(gameObject.tag + " has collided with " + other.gameObject.tag + ".");
		healthState = other.GetComponent<HealthState>();

		Destroy(gameObject);

		Instantiate(PullSphere, transform.position, transform.rotation);

		if (gameObject.tag == "Iceball") {
			healthState.isSlowed = true;
		}
		else {
			healthState.speedMultiplier = 1f;
		}
	}




}
