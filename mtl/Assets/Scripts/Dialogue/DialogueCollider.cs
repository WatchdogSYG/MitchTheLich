using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollider : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerText1")
        {
            Fungus.Flowchart.BroadcastFungusMessage("fuckFlowersText");
        }
    }
}
