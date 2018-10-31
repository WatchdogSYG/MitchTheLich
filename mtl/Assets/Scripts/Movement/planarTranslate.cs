// MDT_Brandon startContribution based off of https://www.youtube.com/watch?v=XhliRnzJe5g
// On any key input, moves object relative to camera in the xz plane. Instant movement wih x rotation.

//KNOWN BUGS: slowly slidees to the right sometimes on odd intit conditions, not reproducible yet.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mtl;


public class planarTranslate : MonoBehaviour {

    static Vector3 playerForward, playerRight;
	float desiredSpeed;

	// Use this for initialization
	void Start () {
		//aligns control axes with camera axes
		AlignWithCamera(UnityEngine.Camera.main);
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
		desiredSpeed = mtl.Movement.PLAYER_BASE_MOVE_SPEED * gameObject.GetComponent<HealthState>().speedMultiplier;
		move(desiredSpeed);
	}

	//assigns motion to object
	private void move(float speed) {
        //define direction for currently pressed key
       // Vector3 currentDirection = new Vector3(Input.GetAxis("xKey"),0,Input.GetAxis("zKey"));//UNUSED from tutorial

        Vector3 rightMovement = speed * playerRight * Time.deltaTime * (Input.GetAxis("xKey")-Input.GetAxis("xNKey"));//v(u_r)dt dot (+-x_dir);
        Vector3 forwardMovement = speed * playerForward * Time.deltaTime * (Input.GetAxis("zKey") - Input.GetAxis("zNKey"));//v(u_f)dt dot (+-z_dir);

        //Vector3 resultantDir = Vector3.Normalize(rightMovement + forwardMovement);//also UNUSED from tutorial

        //change transform in world space to calculated vectors
        transform.position += forwardMovement;
        transform.position += rightMovement;
        return;
    }

	//will also be called once Camera is instantiated, technically removed a race condition
	public static void AlignWithCamera(UnityEngine.Camera c) {
		playerForward = c.transform.forward;//must explicitly use UnityEngine.* (vs/unity bug?)
		playerForward.y = 0;
		playerForward = Vector3.Normalize(playerForward);//transform to unit vector for next transform
		playerRight = Quaternion.Euler(0, 90, 0) * playerForward;//note zxy order
	}
}
// MDT_Brandon endContribution