using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollider : MonoBehaviour {



    private void OnTriggerEnter(Collider other)
    {
      
        
        Fungus.Flowchart.BroadcastFungusMessage("fuckFlowersText");
        Debug.Log("its working");
        
    }
}
