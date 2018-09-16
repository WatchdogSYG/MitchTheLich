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
        
    }
    
   

}
