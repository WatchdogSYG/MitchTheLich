using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
//Author Timothy Waclawik 
//Used to make actionbar switch between fire and ice spells
public class Actionbar : MonoBehaviour {
    Canvas canvas;


    // Use this for initialization
    void Start () {
        canvas = GetComponent<Canvas>();


    }
	
	// Update is called once per frame
	void Update () {
        //ActionBar UI element that is hidden and switches to fire spell images on actionbar when this button is pressed
        if (Input.GetButtonDown(("Element1")))
        {
            canvas.enabled = !canvas.enabled;
        }

    }
}
