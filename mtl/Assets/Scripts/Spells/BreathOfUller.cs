using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathOfUller : Abstract_Spell {

	public float range;
	public float manaPerSecond;
	public float tickRate;

    private LineDrawer LineDraw;
    private GameObject LineDr;

	public BreathOfUller() {
		this.damage = mtl.Damage.DEV_TEST_BULLET_DAMAGE;
		this.range = 20f;

		this.manaPerSecond = 30f;
		this.tickRate = mtl.Spell.BEAM_TICK_RATE;
		this.manaCost = manaPerSecond / tickRate;
		this.fireDelay = 0f;
    }

	public override void Launch(GameObject spawner) {
		//Raycast and check for damage
		RaycastHit hit;
        LineDr = GameObject.Find("MitchLineDrawer");
        LineDraw = LineDr.GetComponent<LineDrawer>();
        //draw texture
        Debug.DrawRay(spawner.transform.position + new Vector3(0f,mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT,0f) , spawner.transform.forward * range*2);

		if (Physics.Raycast(spawner.transform.position + new Vector3(0f, 2f, 0f), spawner.transform.forward, out hit, range)) {
			Debug.Log("I'm hitscanning the object called " + hit.collider.gameObject);
            LineDraw.DrawLine(hit.point);
            hit.collider.gameObject.GetComponent<HealthState>().TakeDamage(damage * Time.deltaTime * 50f);//dt may be exploitable on low fps
        }
	}

	public override void UseMana(GameObject o) {
		o.GetComponent<HealthState>().UseMana(manaCost*tickRate*Time.deltaTime);
	}

	public override void ApplyBuffs(GameObject o) {
		throw new System.NotImplementedException();
	}
}
