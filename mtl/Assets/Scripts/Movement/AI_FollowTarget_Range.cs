//MDT_Brandon startContrubution
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_FollowTarget_Range : MonoBehaviour {

	float moveSpeed_M = mtl.Movement.PLAYER_BASE_MOVE_SPEED * 0.01f;//TO ABSTRACT
	GameObject target_M;//TO ABSTRACT
    GameObject enemy;
    float distance;

    float angularVelocity_M = mtl.Movement.AI_FOLLOW_ANGULAR_SPEED;

	// Use this for initialization
	void Start () {
		//find follow target
		target_M = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        
    }
	
	// Update is called once per frame
	void Update () {
        //rotate towards target
        distance = Vector3.Distance(target_M.transform.position, enemy.transform.position);
        if (distance < 50f)
        {
            gameObject.transform.forward = Vector3.RotateTowards(gameObject.transform.forward,
                                                                    target_M.transform.position - gameObject.transform.position,
                                                                    angularVelocity_M * Time.deltaTime,
                                                                    0f);
            //move at constant speed
            gameObject.transform.position += moveSpeed_M * gameObject.transform.forward;
        }
	}
}
//MDT_Brandon endContrubution