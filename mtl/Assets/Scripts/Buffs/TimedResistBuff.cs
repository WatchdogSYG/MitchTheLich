using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedResistBuff : Abstract_TimedBuff {

	private ResistBuff rBuff;
	private HealthState hs;

	public TimedResistBuff(float duration, Abstract_ScriptableBuff buff, GameObject o) : base(duration, buff, o) {
		hs = o.GetComponent<HealthState>();
		rBuff = (ResistBuff)buff;
	}

	public override void ActivateBuff() {
		hs.damageTakenMultiplier -= mtl.Spell.MISTIFY_RESIST_MULTIPLIER;
		Debug.Log("Activate - Resist: " + hs.damageTakenMultiplier.ToString("F3"));
	}

	public override void EndBuff() {
		hs.damageTakenMultiplier += mtl.Spell.MISTIFY_RESIST_MULTIPLIER;
		Debug.Log("Activate + Resist: " + hs.damageTakenMultiplier.ToString("F3"));
	}
}
