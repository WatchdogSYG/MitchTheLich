using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour {

	//private float lastFireTime;//there is no need for a fire delay on an AI, we will balance it per AI
	HealthState healthState;
	int element = mtl.Spell.ELEMENT_NULL;//UNUSED

	//the spell's data we use (for mouse0 and mouse1)
	mtl.Spell.CastProperties properties0;

	//enemies only need one aray to store all their spells as their input is not bound to a finite number of buttons
	Abstract_Spell[] SpellIndex;

	// Use this for initialization
	void Awake () {
		SpellIndex = new Abstract_Spell[3] { ScriptableObject.CreateInstance<Fireball>(), ScriptableObject.CreateInstance<BreathOfUller>(), ScriptableObject.CreateInstance<SoulVortex>() };//elements on Mouse0
	}

	void Start() {
		healthState = gameObject.GetComponent<HealthState>();
	}

	// Update is called once per frame
	void Update () {
		Debug.DrawRay(gameObject.transform.position + new Vector3(0f, mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT, 0f), gameObject.transform.forward * 20f, new Color(0f, 0f, 255f));
	}

	public void CastSpell(int SpellID) {
		if (healthState.currentMana >= SpellIndex[SpellID].manaCost) {
			SpellIndex[SpellID].Launch(gameObject);
			SpellIndex[SpellID].UseMana(gameObject);
		}
	}
}
