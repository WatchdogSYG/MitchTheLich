//MDT_Brandon startContrubution
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_FollowTargetLunge : MonoBehaviour {
	GameObject target;//TO ABSTRACT

	readonly int[] aiSequence = new int[5] {	mtl.AIStates.STATE_FOLLOW,
												mtl.AIStates.STATE_LOOK,
												mtl.AIStates.STATE_IDLE,
												mtl.AIStates.STATE_LUNGE_MELEE,
												mtl.AIStates.STATE_IDLE};
	readonly float[] aiTime = new float[5] {-1f,0.5f,0.2f,0.05f,1f};

	int currentStateSequence = 0;

	float readyDistance = 15f;//TO ABSTRACT

	float timer = 0;//timer for switching states

	

	// Use this for initialization
	void Start() {
		//find follow target
		target = GameObject.FindWithTag("Player");float returnTimer = aiTime[0];//how long will we be in this state? this<0 means forever until another trigger
	}

	// Update is called once per frame
	void Update() {
		//check for what state it should be
		switch (aiSequence[currentStateSequence]) {
			case mtl.AIStates.STATE_IDLE:
				Idle();
				break;
			case mtl.AIStates.STATE_LOOK:
				Look(1f);
				break;
			case mtl.AIStates.STATE_FOLLOW:
				Follow(mtl.Movement.PLAYER_BASE_MOVE_SPEED, mtl.Movement.AI_FOLLOW_ANGULAR_SPEED, readyDistance);//TO ABSTRACT
				break;
			case mtl.AIStates.STATE_LUNGE_MELEE:
				LungeMelee(mtl.Movement.BUNNY_LUNGE_DISTANCE);
				break;
			default:
				Debug.Log(gameObject.tag + " is not in a valid AI state");
				break;
	}


		//check whether to change states or not
		//check whether it is a time based ai change
		if (aiTime[currentStateSequence] >= 0) {
			//increment the time
			timer += Time.deltaTime;
			//if enough time has passed, go to the next ai state
			if (timer >= aiTime[currentStateSequence]) {
				currentStateSequence++;
				timer = 0;	
				//if we are at the end of the cycle, repeat the cycle
				if(currentStateSequence == aiSequence.Length){
					currentStateSequence = 0;
				}

				Debug.Log("I am now in state " + currentStateSequence.ToString("F1"));
			}	
		}
	}

	void Idle() {
		
	}
	
	//0 < angularStickyness <= 1 //to implement stickyness, it currently locks on perfectly
	void Look(float angularStickyness) {
		if(0 < angularStickyness && angularStickyness <= 1) {
			gameObject.transform.forward = Vector3.Scale(target.transform.position - gameObject.transform.position, new Vector3(1f,0f,1f));
		} else {
			Debug.Log("Domain Error: the angular stickiness for AIState.STATE_LOOK is out of bounds on the object: " + gameObject.tag);
		}
	}

	void Follow( float moveSpeed, float angularVelocity, float triggerDistance) {
		//rotate towards target
		gameObject.transform.forward = Vector3.RotateTowards(gameObject.transform.forward,
																target.transform.position - gameObject.transform.position,
																angularVelocity * Time.deltaTime,
																0f);
		gameObject.transform.forward = Vector3.Scale(gameObject.transform.forward, new Vector3(1, 0, 1));

		//move at constant speed
		gameObject.transform.position += (moveSpeed * Time.deltaTime) * gameObject.transform.forward;

		//are we too close?
		if (Vector3.Magnitude(target.transform.position - gameObject.transform.position) < readyDistance) {
			currentStateSequence++;
		}
	}
	
	void LungeMelee(float lungeDistance) {
		//lunge a certain distance based on the time v=s/t
		gameObject.transform.position += (2* lungeDistance / aiTime[currentStateSequence]) * Time.deltaTime * Vector3.Normalize(gameObject.transform.forward);
	}
}
//MDT_Brandon endContrubution