using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimation : MonoBehaviour {

    Animator anim;
  
    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}

    private void Update()
    {
        if (Input.GetKeyDown("d")) {
            anim.SetBool("moveForward", true);
        }

        if (Input.GetKeyUp("d"))
        {
            anim.SetBool("moveForward", false);
        }

        if (Input.GetKeyDown("w"))
        {
            anim.SetBool("moveW", true);
        }

        if (Input.GetKeyUp("w"))
        {
            anim.SetBool("moveW", false);
        }

        if (Input.GetKeyDown("a"))
        {
            anim.SetBool("moveA", true);
        }

        if (Input.GetKeyUp("a"))
        {
            anim.SetBool("moveA", false);
        }

        if (Input.GetKeyDown("s"))
        {
            anim.SetBool("moveS", true);
        }

        if (Input.GetKeyUp("s"))
        {
            anim.SetBool("moveS", false);
        }
    }
    
   

}
