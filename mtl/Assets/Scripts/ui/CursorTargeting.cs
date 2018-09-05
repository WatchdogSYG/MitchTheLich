//MDT_Brandon startContribution
//casts a ray between the mouse cursor on the near clip plane and the first instance of a collider
//Known Bugs:	Line 33 always throws 2 NullObjectReference exceptions but there is full functinality?
//				Sort of a bug: When there is no hit collider, the raylength is 0
//TODO:			Fix bugs, layerMask, case if mousepoint is off the playable area but we still want rotation
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTargeting : MonoBehaviour {

	public static Vector3 mouseWorldPoint;//use this in other scripts

	Camera cam;
	Vector2 mousePos;

	void OnGUI() {
		Event e = Event.current;//mouse input events;
		cam = UnityEngine.Camera.main;//ray from near clip plane (d=0);
		//get mouse position relative to display bouds
		mousePos = new Vector2(e.mousePosition.x, cam.pixelHeight - e.mousePosition.y);
	}
	


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {		  
		RaycastHit hit;

		//check if the mouse is within the viewport (we dont want a player to target things off screen)
		bool withinViewport = false;
		if ((mousePos.x <= cam.pixelWidth) && (mousePos.y <= cam.pixelHeight)) {
			withinViewport = true;
		}

		//check if we are within viewport and the raycast is hitting a collider and collect RaycastHit information
		if((Physics.Raycast(cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0)), cam.transform.forward, out hit, Mathf.Infinity)) && withinViewport) {
			//Debug draw a magenta line to the collision point
			Debug.DrawRay(	cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0)),
							cam.transform.forward * hit.distance,
							Color.magenta,
							0.1f);
		}

		//find the point the ray stops at
		mouseWorldPoint = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, hit.distance));
	}
}
//MDT_Brandon startContribution