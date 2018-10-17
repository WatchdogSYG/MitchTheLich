using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_Spell : MonoBehaviour {

	//define parameters that every spell has
	public float lifetime;
	public float fireDelay;

	public float damage;
	public float manaCost;

	public List<Abstract_TimedBuff> BuffsApplied(GameObject o) {
		List<Abstract_TimedBuff> buffList = new List<Abstract_TimedBuff>();
		buffList.Add(new TimedSpeedBuff(3f, new SpeedBuff(), o));
		return buffList;
	}

	public abstract void Launch(GameObject spawner);
	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
}
