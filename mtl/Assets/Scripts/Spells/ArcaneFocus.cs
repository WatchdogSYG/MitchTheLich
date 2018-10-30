using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneFocus{
	//does not need to inherit Abstract_Spell as of this scope

	public void ApplyBuffs(GameObject o) {
		HealthState hs = o.GetComponent<HealthState>();
		if(hs.currentMana >= mtl.Spell.ARCANEFOCUS_MANACOST) {
			hs.UseMana(mtl.Spell.ARCANEFOCUS_MANACOST);
			TimedManaRegenBuff tmrb = new TimedManaRegenBuff(5f, ScriptableObject.CreateInstance("ManaRegenBuff") as Abstract_ScriptableBuff, o);
			o.GetComponent<Buffable>().AddBuff(tmrb);
		}
	}
}
