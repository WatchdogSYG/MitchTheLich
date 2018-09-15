//MDT_Brandon startContrubution
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_FollowTarget : MonoBehaviour {

	float moveSpeed = mtl.Movement.PLAYER_BASE_MOVE_SPEED * 0.01f;//TO ABSTRACT
	GameObject target;//TO ABSTRACT
	float angularVelocity = mtl.Movement.AI_FOLLOW_ANGULAR_SPEED;

	// Use this for initialization
	void Start () {
		//find follow target
		target = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//rotate towards target
		
		gameObject.transform.forward = Vector3.RotateTowards(	gameObject.transform.forward,
																target.transform.position-gameObject.transform.position,
																angularVelocity*Time.deltaTime,
																0f);
		//move at constant speed
		gameObject.transform.position += moveSpeed * gameObject.transform.forward;
	}
}
//MDT_Brandon endContrubution