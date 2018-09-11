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


    public class Player {
            public const float PLAYER_BASE_MOVE_SPEED = 12f; //base player move speed. All other movement variables should be a function of this variable.
    }

    public class Projectile {

    }

    public class Damage {

    }

    public class Spawning {

    }
}