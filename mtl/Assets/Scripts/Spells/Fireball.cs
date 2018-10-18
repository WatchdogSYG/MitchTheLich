using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Abstract_Spell {

	//declare specific properties
	public float launchSpeed;
	private Rigidbody rb;

	//set specific stats
	public Fireball() {
		this.damage = mtl.Damage.DEV_TEST_BULLET_DAMAGE;
		this.manaCost = 0.1f;


		this.launchSpeed = mtl.Movement.BASE_PROJECTILE_SPEED;
	}

	public override void Launch(GameObject spawner) {
		//We need a Ridigbody in the first arg for Instantiate. 
		//We also dont want to use the editor to define a Rigidbody from a GameObject because the class extending Abstract_Spell is not a gameobject. 
		//GameObject cannot be cast to Rigidbody.
		//Therefore we Load a prefab as Object then cast to GameObject.
		//Get the prefab (now GameObject) 's RigidBody component, and then process from there.
		//GetComponent is expensive though.
		GameObject r = Resources.Load("Element1RedBullet") as GameObject;

		rb = r.GetComponent<Rigidbody>();
		Rigidbody projectileInstance;
		projectileInstance = Instantiate(rb, spawner.transform.position + new Vector3(0f,mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT,0f) +(mtl.Camera.SPELL_DEFAULT_CAST_OFFSET_DISTANCE * spawner.transform.forward), spawner.transform.rotation) as Rigidbody;

		projectileInstance.velocity = launchSpeed * spawner.transform.forward;
		Debug.Log("Instantiate Fireball");
	}

	public override void ApplyBuffs(GameObject o) {
		List<Abstract_TimedBuff> buffs = this.BList(o);
		Buffable b = o.GetComponent<Buffable>();

		foreach (Abstract_TimedBuff atb in buffs) {
			b.AddBuff(atb);
			print("Applied Buff: " + atb.ToString() + " to " + o.tag + ".");
		}
	}
}
