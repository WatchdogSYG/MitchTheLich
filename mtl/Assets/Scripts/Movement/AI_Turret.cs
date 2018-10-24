using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Turret : MonoBehaviour {
	GameObject target;//TO ABSTRACT
	SpellCaster sc;

	readonly int[] aiSequence = new int[1] {    mtl.AIStates.STATE_SHOOTING};
	readonly float[] aiTime = new float[1] { -1f};

	int currentStateSequence = 0;

	float readyDistance = 15f;//TO ABSTRACT
	float angularStickyness = 1f;

	float timer = 0;//timer for switching states

	[SerializeField]
	float fireDelay = 1.1f;//we want an AI firedelay to be a property of the AI, not the spell

	private float lastFireTime;
	
	// Use this for initialization
	void Start() {
		target = GameObject.FindWithTag("Player");
		sc = gameObject.GetComponent<SpellCaster>();
		lastFireTime = -fireDelay;
	}
	
	// Update is called once per frame
	void Update() {
		//look at player constantly (this is what defines a turret in this game)

		if (0 < angularStickyness && angularStickyness <= 1) {
			gameObject.transform.forward = Vector3.Scale(target.transform.position - gameObject.transform.position, new Vector3(1f, 0f, 1f));
		}
		else {
			Debug.Log("Domain Error: the angular stickiness for AIState.STATE_LOOK is out of bounds on the object: " + gameObject.tag);
		}

		if ((Time.time - lastFireTime) > fireDelay) {
			Shoot(0);
		}
	}

	void Shoot(int SpellID) {
		sc.CastSpell(SpellID);
	}
}
