using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Blink : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("Blink")){
			gameObject.GetComponent<HealthState>().isBlinking = true;
		}
	}
}
