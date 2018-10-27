using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPCR : MonoBehaviour
{


    public GameObject SPAWNER;
    
    public Transform ESR1;
    public Transform ESR2;
    public Transform ESR3;
    public Transform ESR4;
    public Transform ESR5;
    public Transform ESR6;
    public Transform ESR7;
    public Transform ESR8;




    // this variable is used to make sure that
    // the trigger event only occurs once
    public int counter = 0;


    void OnTriggerEnter(Collider other)
    {
        //if tag on the game object = "player
        if (other.gameObject.tag == "Player")
        {
            Instantiate(SPAWNER, ESR1.position, ESR1.rotation);
            Instantiate(SPAWNER, ESR2.position, ESR2.rotation);
            Instantiate(SPAWNER, ESR3.position, ESR3.rotation);
            Instantiate(SPAWNER, ESR4.position, ESR4.rotation);
            Instantiate(SPAWNER, ESR5.position, ESR5.rotation);
            Instantiate(SPAWNER, ESR6.position, ESR6.rotation);
            Instantiate(SPAWNER, ESR7.position, ESR7.rotation);
            Instantiate(SPAWNER, ESR8.position, ESR8.rotation);



        }
    }




}
