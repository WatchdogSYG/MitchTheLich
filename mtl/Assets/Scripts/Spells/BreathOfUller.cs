using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathOfUller : Abstract_Spell {

	public float damage;
	public float range;

	public BreathOfUller() {
		this.damage = mtl.Damage.DEV_TEST_BULLET_DAMAGE;
		this.range = 20f;
	}

	public override void Launch(GameObject spawner) {
		//Raycast and check for damage
		RaycastHit hit;

		if (Physics.Raycast(spawner.transform.position, spawner.transform.forward, out hit, range)) {
			//hit.collider.gameObject.GetComponent<HealthState>().TakeDamage(damage * Time.deltaTime);
		}
		
		//draw texture

	}

	public override void ApplyBuffs(GameObject o) {
		throw new System.NotImplementedException();
	}
}
