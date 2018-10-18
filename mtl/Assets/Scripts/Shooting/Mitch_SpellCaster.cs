using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Author: Owen.Gunter
 Purpose: Gives the player the ability to shoot
 Date: 05/09/2018
 
	Edited: MDT_Brandon 11/09/18: renamed variables to make them physically meaningful, removed hard coding of variables.
	TODO: make this script fire any prefab, 
	remove hard dependency on the Primary Fire button so other things can be done with it,
	make the speed of the projectile dependent on the prefab

	Edited: MDT_Owen 17/09/18: Added two rigidbodys with different colours that represent different bullets
	//also this script can now fire any prefab as long as its defined in mitch_spellcaster
	//you should be able to custimose a particular bullet without effecting the other

    Edited: MDT_Timothy 28?09/2018: Edited to add mana use

	Edited: MDT_Brandon Sprints 5 and 6: Abstracted spells into classes, implemented spell switching and equpping to M0 and M1. Fixed geometry.
  */
public class Mitch_SpellCaster : MonoBehaviour {

	//this is where the bullet spawns
	/*public Transform projectileSpawner;//redundant now*/
	/*
	// how fast the bullet goes
	public float launchSpeed = mtl.Movement.BASE_PROJECTILE_SPEED;
	//variable for delay between shots
	public float shotDelay = mtl.Spell.DelayBetweenShots1;
	*/

	/*//private boolean variables which basically acts like a switch
	//Example:
	//if 1 is pressed run this code and disable element 2 code
	//if 2 is pressed run this code and disable element 1 code
	private bool Element1IsReady = true;
	private bool Element2IsReady = false;
	private bool Element3IsReady = false;*/

	//MDT_Brandon instead have an array so we can pass an index through a function
	int element = mtl.Spell.ELEMENT_FIRE;

	//starts at zero and equals what ever Time.time was before
	private float lastFireTime;
    HealthState healthState;

	//the spell's data we use (for mouse0 and mouse1)
	mtl.Spell.CastProperties properties0;
	mtl.Spell.CastProperties properties1;

	const int SPELLSLOTS = 2;//primary, secondary fire

	/* a 2D array requires AbstractSpell to not be abstract, cannot create new Abstract[]
	public Abstract_Spell[][] SpellIndex = new Abstract_Spell[2][]{
		new Abstract_Spell[3] { new Fireball(), new Fireball(), new Fireball() },
		new Abstract_Spell[3] { new Flamethrower(), new Fireball(), new Fireball() }
		};*/

	//the possible bound spells to m0/m1
	Abstract_Spell[] SpellIndex0;
	Abstract_Spell[] SpellIndex1;


	void Awake() {
		//healthState = player.GetComponent<HealthState>(); ;
		/*projectileSpawner = gameObject.transform;//redundant now*/
		//Object reference not set to an instance of an object
		//GetComponent<HealthState>().UseMana(Attackmana);
		SpellIndex0 = new Abstract_Spell[3] { ScriptableObject.CreateInstance<Fireball>(),			ScriptableObject.CreateInstance <BreathOfUller>(),	ScriptableObject.CreateInstance<SoulVortex>() };//elements on Mouse0
		SpellIndex1 = new Abstract_Spell[3] { ScriptableObject.CreateInstance <Flamethrower>(),	ScriptableObject.CreateInstance<Fireball>(),		ScriptableObject.CreateInstance<Fireball>() };//elements on Mouse1

		Debug.Log("Set Spell Slots M0: " + SpellIndex0[0].ToString() + " | " + SpellIndex0[1].ToString() + " | " + SpellIndex0[2].ToString());
		Debug.Log("Set Spell Slots M1: " + SpellIndex1[0].ToString() + " | " + SpellIndex1[1].ToString() + " | " + SpellIndex1[2].ToString());
		ChangeSpell(element);
    }

	void Start() {
		healthState = gameObject.GetComponent<HealthState>();
	}


	// Update is called once per frame
	void Update() {
		//make the gameObject face in a direction (redundant since its conrolled by the player or AI
		//gameObject.transform.forward = (CursorTargeting.mouseWorldPoint - gameObject.transform.position) + new Vector3(1, 0, 1);
		//Debug.Log(gameObject.transform.position.ToString() + "|" + gameObject.transform.forward.ToString());
		Debug.DrawRay(gameObject.transform.position + new Vector3(0f,mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT,0f), gameObject.transform.forward * 20f, new Color(0f,0f,255f));

		//if the player wants to change elements, set spells then check for shoot intent
		//else check for if the player wants to shoot

		//Switch Elements or Hotbars depending on which key is pressed
		int elementChange = SelectElement();
		if (elementChange >= 0) {//the player wants to change, cannot change to null element
			//first change the element
			element = elementChange;

			//then change the equipped spells for every spellslot
			ChangeSpell(element);
		}

		//if leftclick is pressed run this code
		//MDT_Brandon removed element argument, its handled above
		if (Input.GetButton("Primary Fire")) {
			if ((healthState.currentMana >= SpellIndex0[element].manaCost) && (Time.time > (lastFireTime + SpellIndex0[element].fireDelay))){
				lastFireTime = Time.time;
				SpellIndex0[element].Launch(gameObject);
                SpellIndex0[element].UseMana(gameObject);//MDT_Brandon renamed to explicitly state using mana
				print ("I have Primary Fired an Element " + element + " spell called " + SpellIndex0[element].ToString() + " costing " + SpellIndex0[element].manaCost + " mana.");
            }
            
        }

		//if rightclick is pressed run this code
		if (Input.GetButton("Secondary Fire")) {
			if ((healthState.currentMana >= SpellIndex1[element].manaCost) && (Time.time > (lastFireTime + SpellIndex1[element].fireDelay))) {
				lastFireTime = Time.time;
				SpellIndex1[element].Launch(gameObject);
				SpellIndex1[element].UseMana(gameObject);//MDT_Brandon renamed to explicitly state using mana
				print("I have Secondary Fired an Element " + element + " spell called " + SpellIndex1[element].ToString() + " costing " + SpellIndex1[element].manaCost + " mana.");
			}
		}
	}
	
    private int SelectElement() {
		//check for which element the player wants to change to and return it
		if (Input.GetButtonDown("Element1")) {//MDT_Brandon changed to buttondown event
			//debug
			print("Element 0 is ready");
			return 0;
		}

		if (Input.GetButtonDown("Element2")) {//MDT_Brandon changed to buttondown event
			//debug
			print("Element 1 is ready");
			return 1;
		}

		if (Input.GetButton("Element3")) {//MDT_Brandon changed to buttondown event
			//debug
			print("Element 2 is ready");
			return 2;
		}

		//if the player doesnt press a change key, keep the element the same by returning a negative int
		return -1;
	}

	private void ChangeSpell(int e) {
		//unfortunately we have to hard code this twice
		properties0.mana = SpellIndex0[element].manaCost;
		properties1.mana = SpellIndex1[element].manaCost;

		properties0.fireDelay = SpellIndex0[element].fireDelay;
		properties1.fireDelay = SpellIndex1[element].fireDelay;
	}

		/*UNUSED
		// responsible for creating the bullet object each time player press left click
		// and then launch the object forward
		private void Element1Fire() {

			Rigidbody projectileInstance = Instantiate(Element1RedBullet, projectileSpawner.position, projectileSpawner.rotation) as Rigidbody;

			projectileInstance.velocity = launchSpeed * projectileSpawner.forward;

		}

		// and then launch the object forward
		//Both of these are the same except now it launches a different bullet
		//you can change either ones propeties as you wish
		private void Element2Fire() {
			Rigidbody projectileInstance = Instantiate(Element2BlueBullet, projectileSpawner.position, projectileSpawner.rotation) as Rigidbody;

			projectileInstance.velocity = launchSpeed * projectileSpawner.forward;
		}

		private void Element3Fire() {
			Rigidbody projectileInstance = Instantiate(Element3FlameThrower, projectileSpawner.position, projectileSpawner.rotation) as Rigidbody;

			projectileInstance.velocity = launchSpeed * projectileSpawner.forward;
		}*/
	}