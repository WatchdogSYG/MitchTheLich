using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Author: Owen.Gunter
    //Purpose: To eventually make spells bound to these keys instead and to give extra functionality such as double tap (press key twice to make something happen once)
    //HoldDelay which is holding key down for a period time to make something happen once
    //Getbutton = holding button down
    //GetbuttonDown = when key is pressed
    //GetbuttonUp = when key is released from the press
    
	//this will become true if lastDelayTime > delay 1 this for the HoldDelay() functions
	private bool cooldownq = false;
	private bool cooldowne = false;
	private bool cooldownf = false;
	private bool cooldownls = false;
	//this variable becomes larger when button is being held down this is for the HoldDelay() functions
	private float lastDelayTimeq = 0f;
	private float lastDelayTimee = 0f;
	private float lastDelayTimef = 0f;
	private float lastDelayTimels = 0f;
	//q,e,f,lshift can share this
	private float delay1 = 2f;

	//delay for doubletap functions
	private float delayq = 0.5f;
	private float delaye = 0.5f;
	private float delayf = 0.5f;
	private float delayls = 0.5f;

	//count the times button has been pressed
	private int counterq = 0;
	private int countere = 0;
	private int counterf = 0;
	private int counterls = 0;

	public GameObject EPress_Shield;

	GameObject o;
	// Update is called once per frame

	void Start()
	{
		o = GameObject.FindWithTag("Player");
	}

	void Update()
	{
		QHoldDelay();
		QDoubleTap();
		QButton();

		EHoldDelay();
		EDoubleTap();
		EButton();

		FHoldDelay();
		FDoubleTap();
		FButton();

		LShiftHoldDelay();
		LShiftDoubleTap();
		LShiftButton();

	}
	//holdown button, button pressed, button released
	void QButton()
	{

		//if hold q down print this
		if (Input.GetButton("Buff")) 
		{
			print ("I'm Holding Down Q");
		}
		//if q is pressed print this
		if (Input.GetButtonDown("Buff"))
		{
			print ("I've pressed Q");
		}
		//if q is released from the press print this
		if (Input.GetButtonUp("Buff")) 
		{
			print("I've released Q");
		
		}

	}
		
	// after 2 seconds of holding q down print message
	void QHoldDelay()
	{
		//if hold q down and cooldown is true 
		//do: 0 = 0 + whatever time is now
		if (Input.GetButton ("Buff") && !cooldownq) {
			lastDelayTimeq += Time.deltaTime;
		} 

		// if above isnt true delaytime = 0 and cooldown = false
		else 
		{
			lastDelayTimeq = 0;
			cooldownq = false;
		}
		//if delaytime is greater than delay(which is 2 seconds)
		//print message, cooldown is set to true and delaytime back to zero
		if (lastDelayTimeq > delay1) 
		{
			print ("Q has been held down for 2 seconds");
			cooldownq = true;
			lastDelayTimeq = 0;
		}

	}

	// if you press q twice within 0.5 seconds(delayq) print message
	void QDoubleTap()
	{
		
		if (Input.GetButtonDown ("Buff")) {
			//if button has been pressed twice within the delay and value of counter q is still one even if you press q twice
			//as the below else condition will only ever run once for each event
			if (delayq > 0 && counterq == 1) {
				//has double tapped
				print ("q has been double tapped within delay");

			} else {
				//when button is pressed once
				//add one to counter
				//set delay to = 0.5
				delayq = 0.5f;
				//the counter q variable is only ever going to = 0 or 1
				counterq += 1;

			}

		}

		// if delay q > 0 which will be true before the event takes place
		// update the delay value
		if (delayq > 0) {
			//for doubletap to be succesfful we want something like this
			//delay = 0.5 here as we are asssuming the button has been pressed otherwise it would be less than that making it always false unless you press q again
			//0.5 = 0.5 - 1 * 0.4  = 0.1  : true therefore run the above print message as long as you've pressed q before and the delay value still makes this true as delayq is constanly changing
			delayq -= 1 * Time.deltaTime;
		} 

		else 
		{
			//if delayq > 0 is not true set conterq to 0
			//so that player needs to press q twice within 0.5 seconds
			//to do a doubletap
			counterq = 0;
		}


	}

	//exact same as q except it has its own variables and the name of the button and print message is different
	void EHoldDelay()
	{


		if (Input.GetButton ("Shield") && !cooldowne) {
			lastDelayTimee += Time.deltaTime;
		} 
		else 
		{
			lastDelayTimee = 0;
			cooldowne = false;
		}
		if (lastDelayTimee > delay1) 
		{
			print ("e has been held down for 2 seconds");
			cooldowne = true;
			lastDelayTimee = 0;
		}



	}
	//exact same as q except it has its own variables and the name of the button and print message is different
	void EDoubleTap()
	{
		//counter = 0;

		if (Input.GetButtonDown ("Shield")) {

			if (delaye > 0 && countere == 1) {
				print ("e has been double tapped within delay");

			} else {
				delaye = 0.5f;
				countere += 1;

			}

		}

		if (delaye > 0) {

			delaye -= 1 * Time.deltaTime;
		} else {

			countere = 0;
		}


	}

	void EButton()
	{

		//if hold e down print this
		if (Input.GetButton("Shield")) 
		{
			print ("I'm Holding Down E");

		}
		//if e is pressed print this
		if (Input.GetButtonDown("Shield")) 
		{
			print ("I've pressed E");

		}
		//if e is released from the press print this
		if (Input.GetButtonUp("Shield")) 
		{
			print ("I've released E");
			Instantiate(EPress_Shield, CursorTargeting.mouseWorldPoint , gameObject.transform.rotation);
		}


	}

	//exact same as q except it has its own variables and the name of the button and print message is different
	void FHoldDelay()
	{

		if (Input.GetButton ("Familiar") && !cooldownf) {
			lastDelayTimef += Time.deltaTime;
		} 
		else 
		{
			lastDelayTimef = 0;
			cooldownf = false;
		}
		if (lastDelayTimef > delay1) 
		{
			print ("f has been held down for 2 seconds");
			cooldownf = true;
			lastDelayTimef = 0;
		}

	}
	//exact same as q except it has its own variables and the name of the button and print message is different
	void FDoubleTap()
	{
		//counter = 0;

		if (Input.GetButtonDown ("Familiar")) {

			if (delayf > 0 && counterf == 1) {
				print ("f has been double tapped within delay");

			} else {
				delayf = 0.5f;
				counterf += 1;

			}

		}

		if (delayf > 0) {

			delayf -= 1 * Time.deltaTime;
		} else {

			counterf = 0;
		}


	}

	void FButton()
	{

		//if hold f down print this
		if (Input.GetButton("Familiar")) 
		{
			print ("I'm Holding Down F");

		}
		//if f is pressed print this
		if (Input.GetButtonDown("Familiar")) 
		{
			print ("I've pressed F");
			HealthState hs = o.gameObject.GetComponent<HealthState>();
			TimedHealBuff heal = new TimedHealBuff(mtl.Spell.REST_DURATION, ScriptableObject.CreateInstance("HealBuff") as Abstract_ScriptableBuff, gameObject);
			gameObject.GetComponent<Buffable>().AddBuff(heal);
			hs.UseMana(hs.currentMana);
		}
		//if f is released from the press print this
		if (Input.GetButtonUp("Familiar")) 
		{
			print ("I've released F");

		}
			
	}

	//exact same as q except it has its own variables and the name of the button and print message is different
	void LShiftHoldDelay()
	{


		if (Input.GetButton ("Switch Hotbar") && !cooldownls) {
			lastDelayTimels += Time.deltaTime;
		} 
		else 
		{
			lastDelayTimels = 0;
			cooldownls = false;
		}
		if (lastDelayTimels > delay1) 
		{
			print ("Lshift has been held down for 2 seconds");
			cooldownls = true;
			lastDelayTimels = 0;
		}



	}
	//exact same as q except it has its own variables and the name of the button and print message is different
	void LShiftDoubleTap()
	{
		//counter = 0;

		if (Input.GetButtonDown ("Switch Hotbar")) {

			if (delayls > 0 && counterls == 1) {
				print ("Lshift has been double tapped within delay");

			} else {
				delayls = 0.5f;
				counterls += 1;

			}

		}

		if (delayls > 0) {

			delayls -= 1 * Time.deltaTime;
		} else {

			counterls = 0;
		}


	}

	//i didnt ask for a switch hotbar functionality, this is scope creep. Replace this with a resist buff.
	void LShiftButton()
	{
		//if hold Left shift down print this
		if (Input.GetButton("Switch Hotbar")) 
		{
			print ("I'm Holding Down Left Shift");

		}
		//if Left shift is pressed print this
		if (Input.GetButtonDown("Switch Hotbar")) 
		{
			print("I've pressed Left Shift");
			HealthState hs = o.gameObject.GetComponent<HealthState>();
			if (hs.currentMana >= mtl.Spell.MISTIFY_MANA_COST) {
				hs.UseMana(mtl.Spell.MISTIFY_MANA_COST);
				TimedResistBuff resist = new TimedResistBuff(mtl.Spell.MISTIFY_TIME, ScriptableObject.CreateInstance("ResistBuff") as Abstract_ScriptableBuff, gameObject);
				gameObject.GetComponent<Buffable>().AddBuff(resist);
			}
			

		}
		//if Left shift is released from the press print this
		if (Input.GetButtonUp("Switch Hotbar")) 
		{
			print ("I've released Left Shift");

		}


	}



}
