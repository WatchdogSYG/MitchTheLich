using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Abstract_Spell {

	//declare specific properties
	public float launchSpeed;
	public float coneAngle;
	private Rigidbody rb;

	//this is not quite a beam so firedelay isnt 0; it just may be fster than the user's framerate;
	public float manaPerSecond;
	public float damagePerSecond = 30f;
	public float tickRate;

	//set specific stats
	public Flamethrower() {
		this.damage = damagePerSecond / tickRate;

		this.manaPerSecond = 60f;
		this.tickRate = 15f;
		this.manaCost = manaPerSecond / tickRate;
		this.fireDelay = 1f / tickRate;


		this.launchSpeed = mtl.Movement.BASE_PROJECTILE_SPEED;
		this.coneAngle = 10f;
	}

	public override void Launch(GameObject spawner) {
		Transform t = spawner.transform;
		GameObject r = Resources.Load("Element1RedBullet") as GameObject;
		float angleRandomiser = 2f * coneAngle * (Random.value - 0.5f);

		rb = r.GetComponent<Rigidbody>();
		Rigidbody projectileInstance;
		projectileInstance = Instantiate(	rb, 
												t.position + 
												new Vector3(0f, mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT, 0f) +	
												(mtl.Camera.SPELL_DEFAULT_CAST_OFFSET_DISTANCE * t.forward), 
											t.rotation
											) as Rigidbody;

		projectileInstance.velocity = launchSpeed * (Quaternion.Euler(0f,angleRandomiser,0f) * t.forward);
		Debug.Log("Instantiate Flamethrower Particle");
	}

	public override void UseMana(GameObject o) {
		o.GetComponent<HealthState>().UseMana(manaCost);
	}

	public override void ApplyBuffs(GameObject o) {
		List<Abstract_TimedBuff> buffs = this.BList(o);
		Buffable b = o.GetComponent<Buffable>();

		foreach (Abstract_TimedBuff atb in buffs) {
			b.AddBuff(atb);
			Debug.Log("Applied Buff: " + atb.ToString() + " to " + o.tag + ".");
		}
	}
}
