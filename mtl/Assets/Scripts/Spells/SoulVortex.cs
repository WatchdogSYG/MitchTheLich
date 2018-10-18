using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulVortex : Abstract_Spell {

	Rigidbody rb;
	public float launchSpeed;

	public SoulVortex() {
		this.damage = 70f;
		this.manaCost = 50f;
		this.launchSpeed = 5f;
	}

	public override void Launch(GameObject spawner) {
		//We need a Ridigbody in the first arg for Instantiate. 
		//We also dont want to use the editor to define a Rigidbody from a GameObject because the class extending Abstract_Spell is not a gameobject. 
		//GameObject cannot be cast to Rigidbody.
		//Therefore we Load a prefab as Object then cast to GameObject.
		//Get the prefab (now GameObject) 's RigidBody component, and then process from there.
		//GetComponent is expensive though.
		GameObject r = Resources.Load("Element2BlueBullet") as GameObject;

		rb = r.GetComponent<Rigidbody>();
		Rigidbody projectileInstance;
		projectileInstance = Instantiate(rb, spawner.transform.position + new Vector3(0f, mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT, 0f) + (mtl.Camera.SPELL_DEFAULT_CAST_OFFSET_DISTANCE * spawner.transform.forward), spawner.transform.rotation) as Rigidbody;

		projectileInstance.velocity = launchSpeed * spawner.transform.forward;
		Debug.Log("Instantiate SoulVortex");
	}

	public override void UseMana(GameObject o) {
		o.GetComponent<HealthState>().UseMana(manaCost);
	}

	public override void ApplyBuffs(GameObject o) {
		Debug.Log("No Buffs Implemented!");
	}
}
