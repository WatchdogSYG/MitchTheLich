// MDT This script is for placing game-gobal variables for tuning and moularization.
//May want to enable word wrap for long descriptions...
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

		public float AssignState(string tag) {
			float h;

			switch (tag) {
				case "Player":
					h = mtl.Health.PLAYER_DEFAULT_HEALTH;
					break;
				case "Bunny":
					h = 30f;
					break;
				case "Dummy":
					h = mtl.Health.DEV_TEST_DUMMY_HEALTH;
					break;
				default:
					h = 0;
					break;
			}
			return h;
		}

		public const float DEV_TEST_DUMMY_HEALTH = 1000f;
		public const float PLAYER_DEFAULT_HEALTH = 100f;

    }

	public class Damage {
		public const float DEV_TEST_BULLET_DAMAGE = 10f;
	}

	public class Movement {
		public const float PLAYER_BASE_MOVE_SPEED = 12f; //base player move speed. All other movement variables should be a function of this variable.

		public const float BASE_PROJECTILE_SPEED = 30f;//base projectile speed (a "medium" speed projectile)
		public const float BASE_PROJECTILE_LIFETIME = 2f;//self explanatory
	}

    public class Spell {

    }

    public class Buff {

    }

    public class Familiar {

    }
}