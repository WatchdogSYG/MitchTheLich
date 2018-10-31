using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullTowards : MonoBehaviour {

	SoulVortex sv;

	// Use this for initialization
	void Start () {
		sv = ScriptableObject.CreateInstance<SoulVortex>();
		Destroy(gameObject, sv.pullDuration);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(Collider other) {
		sv.Pull(other.gameObject, gameObject, sv.pullVelocity);
	}
}
