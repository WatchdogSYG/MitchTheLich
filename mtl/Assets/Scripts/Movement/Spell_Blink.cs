using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Blink : MonoBehaviour {

	HealthState hs;

	// Use this for initialization
	void Start () {
		hs = GameObject.FindWithTag("Player").GetComponent<HealthState>();
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetButtonDown("Movement Ability")) && hs.currentMana >= mtl.Spell.BLINK_MANA_COST){
			hs.UseMana(mtl.Spell.BLINK_MANA_COST);
			TimedSpeedBuff tsb = new TimedSpeedBuff(mtl.Movement.BLINK_TIME, ScriptableObject.CreateInstance("SpeedBuff") as Abstract_ScriptableBuff, gameObject);
            gameObject.GetComponent<Buffable>().AddBuff(tsb);
        }
	}
}