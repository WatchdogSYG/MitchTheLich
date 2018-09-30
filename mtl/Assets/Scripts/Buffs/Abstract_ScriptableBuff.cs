//MDT_Brandon startContribution
//based off of tutorial https://www.jonathanyu.xyz/2016/12/30/buff-system-with-scriptable-objects-for-unity/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_ScriptableBuff : ScriptableObject {

    public float duration;//every buff has a time limit

    public abstract Abstract_TimedBuff InitialiseBuff(GameObject o);//initialise a TimedBuff obj on a GameObject
}
//MDT_Brandon endContribution