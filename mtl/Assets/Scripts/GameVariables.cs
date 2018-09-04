// MDT This script is for placing game-gobal variables for tuning and moularization.
//May want to enable word wrap for long descriptions...

namespace mtl {

	public class Camera {
		public const float ISO_PITCH = 60f;//degrees downwards around the x axis for this isometric camera
		public const float ISO_YAW = 0f;//degrees around the y axis for this isometric camera
		public const float ISO_ROLL = 0f;//degrees around the z axis for this isometric camera
		public const float CAM_DISPLACEMENT = 10f;//metres from focus target (for lighting and near-clip plane modifications only)
		public const float ORTHO_HEIGHT = 15f;//length of the orthographic half-box height
	}


    public class Player {
            public const float PLAYER_BASE_MOVE_SPEED = 15f; //base player move speed. All other movement variables should be a function of this variable.
    }

    public class Projectile {

    }

    public class Damage {

    }

    public class Spawning {

    }
}