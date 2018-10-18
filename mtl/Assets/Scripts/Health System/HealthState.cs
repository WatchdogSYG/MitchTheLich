//MDT_Brandon startContribution
//MDT_Timothy Added References and code to UI Health and mana sliders and image //No value given to damage or Take Damage causing NullReference Exceptions I think
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthState : MonoBehaviour {
	
	public float currentHealth;
	public float currentMana;
	public float maxHealth;
	public float maxMana;
	public bool isRegenMana;
	public float lastManaUseTime;
	public float manaRegenDelay;

	public float speedMultiplier = 1f;
	public float manaRegenRate = mtl.Buff.DEFAULT_MANA_REGEN;
	public float manaRegenMultiplier = 1f;

    //UIFX
    public Slider HealthSlider; // Referenceing UI Slider
    public Slider ManaSlider; //Reference UI ManaSlider
    public Image damageImage;   // Reference to an image to flash on the screen on being hurt.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to flash.
    bool damaged;   //  when the player gets damaged.
	
    //unused concept buffs
    /*
	public float damageDealtMultiplier = 1f;
	public float damageTakenMultiplier = 1f;
	public float healthRegenRate = 0f;
	public float lifeStealMagnitude = 0f;
	public bool redirectSpell = false;
	public bool spreadOnContact = false;
	*/

    // Use this for initialization
    void Start () {
		//what object is this? set stats to appropriate values as defined in mtl class

		maxHealth = mtl.Health.AssignHealth(gameObject.tag);
		maxMana = mtl.Buff.AssignMana(gameObject.tag);
		currentHealth = maxHealth;
		lastManaUseTime = -mtl.Spell.BASE_MANA_REGEN_DELAY;//able to use spells immediately
		manaRegenDelay = mtl.Spell.BASE_MANA_REGEN_DELAY;
		isRegenMana = true;
	}
	
	// Update is called once per frame
	void Update () {
		//refresh stats
		//check if delay has passed then regen mana
		if((Time.time-lastManaUseTime) >= manaRegenDelay) {
			isRegenMana = true;
		} else {
			isRegenMana = false;
		}

		if (isRegenMana) {
			if (currentMana < maxMana) {
				//everyone has constant mana regen
				UseMana(-manaRegenRate * manaRegenMultiplier * Time.deltaTime);
			}
			else {
				currentMana = maxMana;
			}
		}     
    }


    /*public void DamageFlash()
    {
        //Bullets need to do actual damage otherwise Null errors occure because damage is not being done - I need to be able to reference enemy attacks that will cause damage to player
        if (damaged)
        {
            damageImage.color = flashColour; // Flash red screen on taking damage
        }
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        //Reset the damaged flag.
        damaged = false;
    }*/

	public void TakeDamage(float damage) {
        //DamageFlash();
        // Set the damaged flag so the screen will flash.
        damaged = true;

       
        //this debug gets annoying if it regens per frame... it doesnt call this per frame tho
        currentHealth -= damage;
		Debug.Log(gameObject.tag + " has taken " + damage.ToString("F0") + " damage! It now has " + currentHealth.ToString("F0") + "HP.");
		
        //an entity can only die if it takes damage, therefore check for death here
        if (currentHealth <= 0) {
			Death();
		}
		return;
	}

	public void UseMana(float mana) {
		//use mana
		currentMana -= mana;

		//this debug gets annoying if it regens per frame
		//Debug.Log(gameObject.tag + " has used " + mana.ToString("F0") + " mana! It now has " + currentMana.ToString("F0") + "MP.");

		//start the regen delay only if we used mana
		if (mana > 0) {
			lastManaUseTime = Time.time;
			print(lastManaUseTime.ToString("F3") + "s");
			print("Mana Not Regenerating...");
		}


		//update UI
		//CAUSING ERRORS - FIXED
		ManaSlider.value = currentMana;
	}

	void Death() {
		Debug.Log(gameObject.tag + " has died.");
		//ragdoll the thing
		Destroy(gameObject);
		return;
	}
}
//MDT_Brandon endContribution
                               