using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimation : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("gameHasStarted", true);
	}

    private void Update()
    {
        CallingAnimations();
    }

    void CallingAnimations()
    {
        if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
        {          
            anim.SetBool("movementWithHorizontal", true);
        }
        //if (Input.GetKeyUp("a") || Input.GetKeyDown("d"))
        //{
        //    anim.SetBool("", true); //Make another transition bool into idle and it will call the idle animation when the player stops pressing the key.
        //}
    }

}
