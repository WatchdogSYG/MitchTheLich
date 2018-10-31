using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedManaRegenBuff : Abstract_TimedBuff {

	private ManaRegenBuff mrBuff;
	private HealthState hs;

	private float currentDelay;

	public TimedManaRegenBuff(float duration, Abstract_ScriptableBuff buff, GameObject o) : base(duration, buff, o) {
		hs = o.GetComponent<HealthState>();
		mrBuff = (ManaRegenBuff)buff;
	}

	public override void ActivateBuff() {
		currentDelay = hs.manaRegenDelay;
		hs.manaRegenDelay = 0f;
		hs.manaRegenMultiplier += mtl.Buff.MANA_REGEN_RATE_BUFF_MULTIPLIER - 1;
	}

	public override void EndBuff() {
		hs.manaRegenDelay = currentDelay;
		hs.manaRegenMultiplier -= mtl.Buff.MANA_REGEN_RATE_BUFF_MULTIPLIER - 1;
	}
}
