using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Blink : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Movement Ability")){
			print("Blinking");
            TimedSpeedBuff tsb = new TimedSpeedBuff(mtl.Movement.BLINK_TIME, ScriptableObject.CreateInstance("SpeedBuff") as Abstract_ScriptableBuff, gameObject);
            gameObject.GetComponent<Buffable>().AddBuff(tsb);
        }
	}
}