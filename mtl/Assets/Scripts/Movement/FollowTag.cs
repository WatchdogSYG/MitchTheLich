//MDT_Brandon startContribution
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTag : MonoBehaviour {

	GameObject lookTarget;
	string currentTarget = "Player";//TO ABSTRACT
	// Use this for initialization
	void Start () {
		lookTarget = findTarget(currentTarget);
	}
	
	// Update is called once per frame
	void Update () {
		//update position and movement
		lookTarget.transform.forward = Vector3.Normalize(lookTarget.transform.position - gameObject.transform.position);

	}

	GameObject findTarget(string tag) {
		//find what to follow
		GameObject target = GameObject.FindWithTag(tag);
		return target;
	}
}
//MDT_Brandon endContribution