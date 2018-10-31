using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulVortex : Abstract_Spell {
	//declare specific properties
	public float launchSpeed;
	private Rigidbody rb;

	public float parabolicLaunchAngle;

	public float pullVelocity;
	public float pullDuration;

	//set specific stats
	public SoulVortex() {
		this.damage = 10f;
		this.manaCost = 45f;
		this.fireDelay = 0.9f;

		this.lifetime = 10f;//the lifetime is also the travel time of the projectile (HARDCODED)

		this.parabolicLaunchAngle = Mathf.PI / 4f;//radians
												  //launchspeed is calculated at launch

		pullVelocity = 15f;
		pullDuration = 4.5f;
	}


	//projectiles will travel at a fixed launch angle with no drag. The horizontal speed will depend on the distance to target, hence the flight time.
	public override void Launch(GameObject spawner) {
		//We need a Ridigbody in the first arg for Instantiate. 
		//We also dont want to use the editor to define a Rigidbody from a GameObject because the class extending Abstract_Spell is not a gameobject. 
		//GameObject cannot be cast to Rigidbody.
		//Therefore we Load a prefab as Object then cast to GameObject.
		//Get the prefab (now GameObject) 's RigidBody component, and then process from there.
		//GetComponent is expensive though.
		GameObject r = Resources.Load("BlackHole") as GameObject;

		rb = r.GetComponent<Rigidbody>();
		Rigidbody projectileInstance;

		Vector3 castOffset = new Vector3(0f, mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT, 0f) + (mtl.Camera.SPELL_DEFAULT_CAST_OFFSET_DISTANCE * spawner.transform.forward);
		Vector3 castLocation = spawner.transform.position + castOffset;

		float dx = Vector3.Magnitude(CursorTargeting.mouseWorldPoint - spawner.transform.position + castOffset);

		projectileInstance = Instantiate(rb, castLocation, spawner.transform.rotation) as Rigidbody;

		//launchSpeed = ((-Physics.gravity.y * dx) / (2f * linearProjectileFlightConstant * Mathf.Sin(parabolicLaunchAngle)))-(mtl.Camera.SPELL_DEFAULT_CAST_OFFSET_DISTANCE/(dx * Mathf.Sin(parabolicLaunchAngle)));
		//launchSpeed = Mathf.Sqrt(Mathf.Pow((-Physics.gravity.y*dx/(linearProjectileFlightConstant*2)-(mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT*dx/linearProjectileFlightConstant)), 2f))+linearProjectileFlightConstant;
		//launchSpeed = ((-Physics.gravity.y * Mathf.Pow((dx / linearProjectileFlightConstant),2f))-mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT+dx) / ((dx*(Mathf.Sin(parabolicLaunchAngle)+Mathf.Cos(parabolicLaunchAngle)))/linearProjectileFlightConstant);
		launchSpeed = Vector3.Magnitude(new Vector3(1.5f*dx/5f,(0.5f*-Physics.gravity.y/lifetime)-(mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT/lifetime)));

		//launchSpeed = (dx / lifetime) / (Mathf.Cos(parabolicLaunchAngle));
		//ok i tried, but this launchspeed is hardcoded (*1.5f) to hit near the cursor.

		projectileInstance.velocity = launchSpeed * (spawner.transform.forward + (new Vector3(0f,1f,0f) * Mathf.Tan(parabolicLaunchAngle)));
		projectileInstance.useGravity = true;
	}

	public override void UseMana(GameObject o) {
		o.GetComponent<HealthState>().UseMana(manaCost);
	}

	public override void ApplyBuffs(GameObject o) {
		List<Abstract_TimedBuff> buffs = this.BList(o);
		Buffable b = o.GetComponent<Buffable>();

		foreach (Abstract_TimedBuff atb in buffs) {
			//b.AddBuff(atb);//not yet
			Debug.Log("Applied Buff: " + atb.ToString() + " to " + o.tag + ".");
		}
	}

	public void Pull(GameObject o, GameObject v, float speed) {
		Debug.Log("Pull " + o.tag + " towards SoulVortex with speed: " + speed.ToString("F3"));
		Vector3 pullDir = Vector3.ProjectOnPlane(v.transform.position - o.transform.position,new Vector3(0f,1f,0f));
		o.transform.position += speed * Vector3.Normalize(pullDir) * Time.deltaTime;
	}
}

