// MDT This script is for placing game-gobal variables for tuning and moularization.
//May want to enable word wrap for long descriptions...
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mtl {

	public class Camera {
		public const float ISO_PITCH = 45f;//degrees downwards around the x axis for this isometric camera
		public const float ISO_YAW = 15f;//degrees around the y axis for this isometric camera
		public const float ISO_ROLL = 0f;//degrees around the z axis for this isometric camera
		public const float CAM_DISPLACEMENT = 200f;//metres from focus target (for lighting and near-clip plane modifications only)
		public const float ORTHO_HEIGHT = 25f;//length of the orthographic half-box height

		//the ratio of the screen dimension describing where we want to place Mitch
		public const float MITCH_DEFAULT_YPOS_RATIO = 0.5f;//proportion of ortho half box we want mitch to move down from centre
		public const float MITCH_DEFAULT_XPOS_RATIO = -0.1f;//proportion of ortho half box we want mitch to move left from centre

		//desired aspect ratio
		public const float DESIRED_ASPECT_RATIO = 16f / 9f;

		public const float CAM_SMOOTH_COEFF = 2f;//interpolation free parameter smoothing coefficient

		//spallcast world offsets
		public const float SPELL_DEFAULT_CAST_OFFSET_DISTANCE = 5f;//how far from the centre of the hitbox along transform.forward do we want to fire spells?
		public const float SPELL_DEFAULT_CAST_HEIGHT = 2f;//how high off the groud does an entity shoot?
	}

    public class Health {
		public const float DEV_TEST_DUMMY_HEALTH = 1000f;
		public const float BOSS_DEFAULT_HEALTH = 500f;
		public const float PLAYER_DEFAULT_HEALTH = 100f;
		public const float ENEMY_DEFAULT_HEALTH = 30f;
		public const float BIGBUNNY_DEFAULT_HEALTH = 90f;
		public const float SHIELD_DEFAULT_HEALTH = 50f;
		public const float DRAGON_DEFAULT_HEALTH = 150f;
        public static float AssignHealth(string tag) {
			
			//temporary kv for health, extend to json for entity atributes
			List<KeyValuePair<string, float>> healthKV = new List<KeyValuePair<string, float>>();
			healthKV.Add(new KeyValuePair<string, float>("Player", PLAYER_DEFAULT_HEALTH));
			healthKV.Add(new KeyValuePair<string, float>("Bunny", 10f));
            healthKV.Add(new KeyValuePair<string, float>("BunnyCheck", 10f));
            healthKV.Add(new KeyValuePair<string, float>("Boss", BOSS_DEFAULT_HEALTH));
            healthKV.Add(new KeyValuePair<string, float>("Dummy", DEV_TEST_DUMMY_HEALTH));
			healthKV.Add(new KeyValuePair<string, float>("Enemy", ENEMY_DEFAULT_HEALTH));
			healthKV.Add(new KeyValuePair<string, float>("Shield", SHIELD_DEFAULT_HEALTH));
			healthKV.Add(new KeyValuePair<string, float>("BigBunny", BIGBUNNY_DEFAULT_HEALTH));
			healthKV.Add(new KeyValuePair<string, float>("Dragon", DRAGON_DEFAULT_HEALTH));
			float h= -1f;
			float h0 = 696969f;//fallback for untagged (a entity must have health)

			foreach (KeyValuePair<string, float> kv in healthKV) {
				if (tag == kv.Key) {
					Debug.Log(kv.Key + " has " + kv.Value.ToString("F0") + "HP");
					h = kv.Value;
				} 
			}

			//if no kv pair is found
			if (h < 0) {
				Debug.Log("The entity tag does not appear in the Key-Value List, set MAX_MANA to " + h0);
				return h0;
			}

			return h;
		}
    }

	public class Damage{
		public const float DEV_TEST_BULLET_DAMAGE = 10f;
        //public int attackDamage = 10; //Tim Edit - Trying to call from GameVariables to bullet damage is difficult
    }

	public class Movement {
		//Player and Enemy Movements
		public const float PLAYER_BASE_MOVE_SPEED = 18f; //base player move speed. All other movement variables should be a function of this variable.
		public const float MOVEMENT_SMOOTH_COEFF = 5f;//interpolation free parameter smoothing coefficient for movement
		
		//AI Movements
		public const float AI_FOLLOW_ANGULAR_SPEED = 1 * (2 * Mathf.PI);//rad per s

		public const float BUNNY_LUNGE_DISTANCE = 10f;
		public const float BUNNY_LUNGE_TIME = 0.05f;

		public static string AssignAI(string tag) {

			//temporary kv for ai, extend to json for entity atributes
			List<KeyValuePair<string, string>> AIKV = new List<KeyValuePair<string, string>>();
			AIKV.Add(new KeyValuePair<string, string>("Bunny", "Follow"));
			AIKV.Add(new KeyValuePair<string, string>("Dummy", "Follow"));

			string ai = null;

			foreach (KeyValuePair<string, string> kv in AIKV) {
				if (tag == kv.Key) {
					Debug.Log(kv.Key + " has been assigned the " + kv.Value + " AI type.");
					ai = kv.Value;
				}
			}

			//if no kv pair is found
			if (ai == null) {
				Debug.Log("The entity tag does not appear in the Key-Value List, it has no AI assigned to it");
				return ai;
			}
			return ai;
		}

		//Projectile Movements and Spell Movements
		public const float BASE_PROJECTILE_SPEED = 30f;//base projectile speed (a "medium" speed projectile)
		public const float BASE_PROJECTILE_SPEED2 = 60f;//base projectile speed (a "medium" speed projectile)
		public const float BASE_PROJECTILE_LIFETIME = 2f;//self explanatory

        //v=s/t
		public const float BLINK_DISTANCE = 8f;
		public const float BLINK_TIME = 0.025f;

		//unused smoothing function
		public float easeFunction(float coeff, float t, float desiredSpeed) {
			//v=50e^(coeff(t-1))
			float v = 50 * Mathf.Exp(coeff * (t - 1));
			return v;
		}
	}

	public class Spell {
		public const float BASE_MANA_REGEN_DELAY = 0.5f;

		public const int ELEMENT_NULL = 100;//this is for entities that dont have elements defined eg. Bunny Melee
		public const int ELEMENT_FIRE = 0;
		public const int ELEMENT_ICE = 1;
		public const int ELEMENT_SHADOW = 2;

		//particluar spell class variables
		public const float BEAM_TICK_RATE = 60f;
		public const float BLINK_MANA_COST = 35f;

		public const float ARCANEFOCUS_MANACOST = 60f;
		public const float MISTIFY_RESIST_MULTIPLIER = 0.5f;
		public const float MISTIFY_TIME = 2f;
		public const float MISTIFY_MANA_COST = 20f;

		public const float REST_DURATION = 4f;

		public const float BaseShotDelay = 0.9f;
		public const float IceShotDelay = 0.4f;
		public const float FlameThrowerShotDelay = 0.1f;

		public const float BaseProjectileSpeed = 30f;
		public const float IceProjectileSpeed = 60f;
		public const float FlameThrowerProjectileSpeed = 30f;

		//no dev checking on this one
		//the properties of spells that the Mitch_SpellCaster has to know about
		public struct CastProperties {
			public float mana;
			public float fireDelay;
		};
	}

    public class Buff {
		public const float PLAYER_DEFAULT_MANA = 100f;
		public const float DEFAULT_MANA_REGEN = 30f;
		public const float WIZARD1_MANA = 50f;
		public const float DRAGON_MANA = 50f;
        public const float BLINK_SPEED_MAGNITUDE = (mtl.Movement.BLINK_DISTANCE / mtl.Movement.BLINK_TIME) / mtl.Movement.PLAYER_BASE_MOVE_SPEED;

		public const float MANA_REGEN_RATE_BUFF_MULTIPLIER = 1.2f;


		public static float AssignMana(string tag) {

			//temporary kv for mana, extend to json for entity atributes
			List<KeyValuePair<string, float>> manaKV = new List<KeyValuePair<string, float>>();
			manaKV.Add(new KeyValuePair<string, float>("Player", PLAYER_DEFAULT_MANA));
			manaKV.Add(new KeyValuePair<string, float>("Wizard1", WIZARD1_MANA));
			manaKV.Add(new KeyValuePair<string, float>("Dummy", WIZARD1_MANA));
			manaKV.Add(new KeyValuePair<string, float>("Boss", WIZARD1_MANA));
			manaKV.Add(new KeyValuePair<string, float>("Dragon", DRAGON_MANA));
			float m = -1f;
			float m0 = 0f;//if its untagged, it doesnt have any mana

			foreach (KeyValuePair<string, float> kv in manaKV) {
				if (tag == kv.Key) {
					m = kv.Value;
				}
			}

			//if no kv pair is found
			if (m < 0) {
				Debug.Log("The entity tag does not appear in the Key-Value List, set MAX_MANA to" + m0);
				return m0;
			}
			return m;
		}
	}

	//please deprecate this asap
	public class EnemyShooting {
		//this variable makes it so their is a 1 second delay inbetween shots
		public const float DelayBetweenShots = 1f;
		//this variable is the maximum distance that the enemy can fire
		public const int MaxDistance = 40;

	}

	public class EnemySpawner {
		// this variable will delay each enemy spawned by 2 seconds
		public const float spawnTimer = 2f;
		// this variable controls how many enemies spawn from a particular spawn point
		public const int AmountOfEnemies = 5;
        public int killCounter = 0;
	}

	public class AIStates {
		public const int STATE_IDLE = 0;//statenumber when objcet does not move
		public const int STATE_LOOK = 1;//statenumber for when object is stationary and looks at a target
		public const int STATE_FOLLOW = 2;//statenumber when an object follows a target
		public const int STATE_LUNGE_MELEE = 3;//statenumber when an object moves through a target quickly and does damage
		public const int STATE_SHOOTING = 4;//statenumber when an object has a shoot intent
		public const int STATE_SEARCHING = 5;//statenumber when an object is looking for a target with some criteria and not doing anything else
	}

    public class Familiar {

    }
}