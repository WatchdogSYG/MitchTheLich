// MDT This script is for placing game-gobal variables for tuning and moularization.
//May want to enable word wrap for long descriptions...
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mtl {

	public class Camera {
		public const float ISO_PITCH = 60f;//degrees downwards around the x axis for this isometric camera
		public const float ISO_YAW = 0f;//degrees around the y axis for this isometric camera
		public const float ISO_ROLL = 0f;//degrees around the z axis for this isometric camera
		public const float CAM_DISPLACEMENT = 250f;//metres from focus target (for lighting and near-clip plane modifications only)
		public const float ORTHO_HEIGHT = 16f;//length of the orthographic half-box height

		//the ratio of the screen dimension describing where we want to place Mitch
		public const float MITCH_DEFAULT_YPOS_RATIO = 0.5f;//proportion of ortho half box we want mitch to move down from centre
		public const float MITCH_DEFAULT_XPOS_RATIO = -0.2f;//proportion of ortho half box we want mitch to move left from centre

		//desired aspect ratio
		public const float DESIRED_ASPECT_RATIO = 16f / 9f;
	}

    public class Health {
		/*string[] healthTag = ["Player","Bunny","Dummy"];
		float[] healthValue = [mtl.Health.PLAYER_DEFAULT_HEALTH, 30f, mtl.Health.DEV_TEST_DUMMY_HEALTH];*/

		public const float DEV_TEST_DUMMY_HEALTH = 1000f;
		public const float PLAYER_DEFAULT_HEALTH = 100f;

		public static float AssignState(string tag) {
			
			//temporary kv for health, extend to json for entity atributes
			List<KeyValuePair<string, float>> healthKV = new List<KeyValuePair<string, float>>();
			healthKV.Add(new KeyValuePair<string, float>("Player", PLAYER_DEFAULT_HEALTH));
			healthKV.Add(new KeyValuePair<string, float>("Bunny", 10f));
			healthKV.Add(new KeyValuePair<string, float>("Dummy", DEV_TEST_DUMMY_HEALTH));

			float hey= -1f;

			foreach (KeyValuePair<string, float> kv in healthKV) {
				if (tag == kv.Key) {
					Debug.Log(kv.Key + " has " + kv.Value.ToString("F0") + "HP");
					hey = kv.Value;
				} 
			}

			return hey;
		}
    }

	public class Damage {
		public const float DEV_TEST_BULLET_DAMAGE = 10f;
	}

	public class Movement {
		public const float PLAYER_BASE_MOVE_SPEED = 12f; //base player move speed. All other movement variables should be a function of this variable.

		public const float BASE_PROJECTILE_SPEED = 30f;//base projectile speed (a "medium" speed projectile)
		public const float BASE_PROJECTILE_LIFETIME = 2f;//self explanatory

		public const float MOVEMENT_EASE_IO = 7;

		public static int chooseAIByTag(string tag) {

			return 0;
		}

		public float easeFunction(float coeff, float t, float desiredSpeed) {
			//v=50e^(coeff(t-1))
			float v = 50 * Mathf.Exp(coeff * (t - 1));
			return v;
		}
	}

    public class Spell {

    }

    public class Buff {

    }

    public class Familiar {

    }
}