using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovement : MonoBehaviour {
    Animator anim;
    Vector3 lastPosition = Vector3.zero;
    //float move = mtl.Movement.AI_FOLLOW_ANGULAR_SPEED;
    float move = 0f;
    // Use this for initialization
    void Start () {
        //error: the name anim does not exist in the current context
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        move = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;

        anim.SetFloat("Speed", move);
        
	}
}
