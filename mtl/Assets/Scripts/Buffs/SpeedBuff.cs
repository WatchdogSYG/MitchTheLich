using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/SpeedBuff")]
public class SpeedBuff : Abstract_ScriptableBuff {

    public float SpeedMultiplier;

    public override Abstract_TimedBuff InitialiseBuff(GameObject o){
        return new TimedSpeedBuff(duration, this, o);
    }
}
