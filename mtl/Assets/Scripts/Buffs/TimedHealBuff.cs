using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedHealBuff : Abstract_TimedBuff {

	private HealBuff hBuff;
	private HealthState hs;
	

	public TimedHealBuff(float duration, Abstract_ScriptableBuff buff, GameObject o) : base(duration, buff, o) {
		hs = o.GetComponent<HealthState>();
		hBuff = (HealBuff)buff;
	}

	public override void ActivateBuff() {
		float mana = hs.currentMana;
		float healAmount = mana * 0.5f;
		Debug.Log("Healing " + healAmount.ToString("F0") + " HP over " + mtl.Spell.REST_DURATION.ToString("F1") + " seconds...");
		hs.healthRegenRate = healAmount / mtl.Spell.REST_DURATION;
		hs.isRegenMana = false;
	}

	public override void EndBuff() {
		hs.isRegenMana = true;
		hs.healthRegenRate = 0f;
		Debug.Log("Healing finished.");
	}
}
