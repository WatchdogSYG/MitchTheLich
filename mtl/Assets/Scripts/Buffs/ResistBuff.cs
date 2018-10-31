using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistBuff : Abstract_ScriptableBuff {

	float damageMultiplier;

	public override Abstract_TimedBuff InitialiseBuff(GameObject o) {
		return new TimedResistBuff(duration, this, o);
	}
}
