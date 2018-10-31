//MDT_Brandon startContrubution
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_FollowTargetLunge : MonoBehaviour {
	GameObject target;//TO ABSTRACT

	readonly int[] aiSequence = new int[6] {	mtl.AIStates.STATE_SEARCHING,
												mtl.AIStates.STATE_FOLLOW,
												mtl.AIStates.STATE_LOOK,
												mtl.AIStates.STATE_IDLE,
												mtl.AIStates.STATE_LUNGE_MELEE,
												mtl.AIStates.STATE_IDLE};
	readonly float[] aiTime = new float[6] {-1f,-1f,0.5f,0.2f,0.05f,0.3f};

	int currentStateSequence = 0;

	float readyDistance = 15f;//TO ABSTRACT
	float searchDistance = 50f;
	bool idleTimeToggle = false;

	float timer = 0;//timer for switching states
	
	// Use this for initialization
	void Start() {
		//find follow target
		target = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update() {
		//check for what state it should be
		switch (aiSequence[currentStateSequence]) {
			case mtl.AIStates.STATE_IDLE:
				Idle( idleTimeToggle, searchDistance);
				break;
			case mtl.AIStates.STATE_LOOK:
				Look(1f);
				break;
			case mtl.AIStates.STATE_FOLLOW:
				Follow(12f, mtl.Movement.AI_FOLLOW_ANGULAR_SPEED, readyDistance);//TO ABSTRACT
				break;
			case mtl.AIStates.STATE_LUNGE_MELEE:
				LungeMelee(mtl.Movement.BUNNY_LUNGE_DISTANCE);
				break;
			case mtl.AIStates.STATE_SEARCHING:
				SearchForPlayer();//currently player is the only target needed to be searched for
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
			}	
		}
	}

	void Idle(bool useTime, float triggerDistance) {
		
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
		gameObject.transform.position += (moveSpeed * gameObject.GetComponent<HealthState>().speedMultiplier * Time.deltaTime) * gameObject.transform.forward;

		//are we too close?
		if ( CheckDistance(gameObject,target) < triggerDistance) {
			currentStateSequence++;
		}
	}
	
	void LungeMelee(float lungeDistance) {
		//lunge a certain distance based on the time v=s/t
		gameObject.transform.position += (2* lungeDistance / aiTime[currentStateSequence]) * Time.deltaTime * Vector3.Normalize(gameObject.transform.forward);
	}

	void SearchForPlayer() {
		float dx = Vector3.Magnitude(target.transform.position - gameObject.transform.position);
		if (CheckDistance(gameObject,target) < searchDistance) {
			currentStateSequence++;
		}
		
	}

	//returns the magnitude of the displacement from t1 to t2
	float CheckDistance(GameObject o1, GameObject o2) {
		return Vector3.Magnitude(o2.transform.position - o1.transform.position);
	}
}
//MDT_Brandon endContrubution