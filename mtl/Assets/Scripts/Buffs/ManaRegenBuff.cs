using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRegenBuff : Abstract_ScriptableBuff {

	float manaRegenMultiplier;

	public override Abstract_TimedBuff InitialiseBuff(GameObject o) {
		return new TimedManaRegenBuff(duration, this, o);
	}
}
