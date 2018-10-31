using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBuff : Abstract_ScriptableBuff {

	public override Abstract_TimedBuff InitialiseBuff(GameObject o) {
		return new TimedHealBuff(duration, this, o);
	}
}
