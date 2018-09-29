using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpeedBuff : Abstract_TimedBuff {

    private SpeedBuff speedBuff;
    private HealthState hs;

    public TimedSpeedBuff(float duration, Abstract_ScriptableBuff buff, GameObject o):base(duration,buff,o){
        hs = o.GetComponent<HealthState>();
        speedBuff = (SpeedBuff)buff;
    }

    public override void ActivateBuff()
    {
        SpeedBuff speedBuff = (SpeedBuff)buff;
        hs.speedMultiplier += mtl.Buff.BLINK_SPEED_MAGNITUDE - 1;
    }

    public override void EndBuff()
    {
        hs.speedMultiplier -= mtl.Buff.BLINK_SPEED_MAGNITUDE - 1;
    }
}
