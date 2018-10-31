//MDT_Brandon startContribution
//Camera follows the first object with the "Player" tag at a distance of mtl.Camera.CAM_DISPLACEMENT metres away with an orthographic size of ORTHO_HEIGHT. Works with any camera rotation.
//https://www.youtube.com/watch?v=MFQhpwc6cKE smoothed movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mtl;

public class cameraFollow : MonoBehaviour {
	//returns a string displaying the xyz components of a Vector3 (may be moved into a lib later)
	string Vector3Log(Vector3 v, int sigFig) {
		string vString = "(" +
			v.x.ToString("F" + sigFig.ToString()) + "x, " +
			v.y.ToString("F" + sigFig.ToString()) + "y, " +
			v.z.ToString("F" + sigFig.ToString()) + "z)";
		return vString;
	}

	Vector3 worldDefaultUnitVector = new Vector3(0, 0, 1);//a vector with no rotation points in the z direction
	Vector3 playerInitialPos, unitPlayerToCam, manualCameraDisplacement;

	// Use this for initialization
	void Start() {
        //set initial camera rotation and size
        UnityEngine.Camera.main.orthographicSize = mtl.Camera.ORTHO_HEIGHT;
		Quaternion rotation = Quaternion.Euler(mtl.Camera.ISO_PITCH, mtl.Camera.ISO_YAW, mtl.Camera.ISO_ROLL);
		UnityEngine.Camera.main.transform.rotation = rotation;
		//give a unit vector in the direction of the player facing the camera
		unitPlayerToCam = rotation * worldDefaultUnitVector;

		planarTranslate.AlignWithCamera(UnityEngine.Camera.main);
		
		//define where mitch wants to be on screen TOFIX
		manualCameraDisplacement = new Vector3(-(mtl.Camera.MITCH_DEFAULT_XPOS_RATIO - 0.5f) * mtl.Camera.ORTHO_HEIGHT * mtl.Camera.DESIRED_ASPECT_RATIO,
												(mtl.Camera.MITCH_DEFAULT_YPOS_RATIO - 0.5f) * mtl.Camera.ORTHO_HEIGHT,0);
		manualCameraDisplacement = rotation * manualCameraDisplacement;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//find the player's current position and camera offset
		playerInitialPos = GameObject.FindWithTag("Player").transform.position;
		Vector3 totalOffset = (mtl.Camera.CAM_DISPLACEMENT * Vector3.Normalize(-unitPlayerToCam)) + manualCameraDisplacement;
		Vector3 desiredPos = playerInitialPos + totalOffset;
		//remove floating point rounding frame rate discrepancies
		if(Vector3.Magnitude(desiredPos- UnityEngine.Camera.main.transform.position) < 0.01f) {
			UnityEngine.Camera.main.transform.position = desiredPos;
		}
		else {
			//set the camera so that it faces the player at a distance of CAM_DISPLACEMENT (with smoothing)
			UnityEngine.Camera.main.transform.position = Vector3.Lerp(UnityEngine.Camera.main.transform.position, desiredPos, mtl.Camera.CAM_SMOOTH_COEFF * Time.deltaTime);
		}
	}
}
//MDT_Brandon endContribution