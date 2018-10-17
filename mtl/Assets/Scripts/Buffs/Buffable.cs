using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffable : MonoBehaviour {

    //a list of all the current buffs on the GameObject
    public List<Abstract_TimedBuff> CurrentBuffs = new List<Abstract_TimedBuff>();

	// Update is called once per frame
	void Update () {
        //check for pausing here
        //...


		foreach(Abstract_TimedBuff b in CurrentBuffs){
            //increment time
            b.BuffTick(Time.deltaTime);
            //check for completion and remove if neccesary
            if (b.IsFinished)
            {
                CurrentBuffs.Remove(b);
				print("Buff " + b + " removed.");
            }
        }
    }

    public void AddBuff(Abstract_TimedBuff buff){
        CurrentBuffs.Add(buff);
        buff.ActivateBuff();
    }
}
