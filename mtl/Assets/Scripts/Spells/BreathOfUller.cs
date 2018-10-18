using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathOfUller : Abstract_Spell {

	public float range;

	public BreathOfUller() {
		this.damage = mtl.Damage.DEV_TEST_BULLET_DAMAGE;
		this.range = 20f;
		this.manaCost = 5f;
	}

	public override void Launch(GameObject spawner) {
		//Raycast and check for damage
		RaycastHit hit;
		
		//draw texture
		Debug.DrawRay(spawner.transform.position + new Vector3(0f,mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT,0f) , spawner.transform.forward * range*2);

		if (Physics.Raycast(spawner.transform.position + new Vector3(0f, mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT, 0f), spawner.transform.forward, out hit, range)) {
			print("I'm hitscanning the object called " + hit.collider.gameObject);
			hit.collider.gameObject.GetComponent<HealthState>().TakeDamage(damage * Time.deltaTime);//dt may be exploitable on low fps
			spawner.GetComponentInChildren<LineRenderer>().enabled = true;
		}
	}

	public override void ApplyBuffs(GameObject o) {
		throw new System.NotImplementedException();
	}
}
