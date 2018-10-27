using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollider : MonoBehaviour {

    //bunny health variable. BE1 and BE2

     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trigger1")
        {
           
            Fungus.Flowchart.BroadcastFungusMessage("FlowersText");
            Debug.Log("its working");
           
        }

        if(other.gameObject.name == "Trigger2")
        {

            Fungus.Flowchart.BroadcastFungusMessage("Attack");
            Debug.Log("its working");

        }

        if(other.gameObject.name == "Trigger3")
        {
            Fungus.Flowchart.BroadcastFungusMessage("Spells");
            Debug.Log("its working");

        }

        /*if (bunny health = 0)
        {
        
           Fungus.Flowchart.BroadcastFungusMessage("Bunny");
            Debug.Log("its working");
        
        }
        */
    }
}
