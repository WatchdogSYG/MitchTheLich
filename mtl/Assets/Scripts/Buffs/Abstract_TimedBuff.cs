using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_TimedBuff{

    protected float duration;
    protected Abstract_ScriptableBuff buff;
    protected GameObject o;

    public bool IsFinished { get { return duration <= 0 ? true : false; } }

    //contruct from args
	public Abstract_TimedBuff(float duration, Abstract_ScriptableBuff buff, GameObject o){
        this.duration = duration;
        this.buff = buff;
        this.o = o;
    }

    //call this in update loop
    public void BuffTick(float dt)
    {
        duration -= dt;
        if (duration <= 0)
        {
            EndBuff();
        }
    }

    public abstract void ActivateBuff();
    public abstract void EndBuff();
}
