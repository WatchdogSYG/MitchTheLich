using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_Spell : ScriptableObject {

	//define parameters that every spell has
	public float lifetime;
	public float fireDelay;

	public float damage;
	public float manaCost;

	public List<Abstract_TimedBuff> BList(GameObject o) {
		List<Abstract_TimedBuff> buffList = new List<Abstract_TimedBuff>();
		buffList.Add(new TimedSpeedBuff(3f, new SpeedBuff(), o));
		return buffList;
	}
	
	//Called when player of AI wants to shoot
	//@params spawner The GameObject the Spell is instantiated at.
	public abstract void Launch(GameObject spawner);

	//Called when mana is to be drained from spell usage
	public abstract void UseMana(GameObject o);

	//Applied to a hit collider.gameObject o.
	public abstract void ApplyBuffs(GameObject o);
}
