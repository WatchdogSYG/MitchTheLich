using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    //Author: Owen.Gunter
    //Purpose: to give properties to bullet
    //Date: 06/09/2018

    // Use this for initialization

    public float MaxLifeTime = mtl.Movement.BASE_PROJECTILE_LIFETIME;//MDT_Brandon cleaned up
	void Start () {
        // if it isnt already destroyed kill object after 2 seconds
        Destroy(gameObject, MaxLifeTime);
		
	}
	
	
	void OnCollisionEnter (Collision other)
    {
		other.gameObject.GetComponent<HealthState>().TakeDamage(mtl.Damage.DEV_TEST_BULLET_DAMAGE);
		Destroy(gameObject);
	}
}
