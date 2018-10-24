using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		gameObject.GetComponent<Rigidbody>().velocity -= Physics.gravity * Time.deltaTime;
	}
}
