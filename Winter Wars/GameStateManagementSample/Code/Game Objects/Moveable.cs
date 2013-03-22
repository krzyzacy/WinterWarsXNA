using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using System.Diagnostics;

using WWxna.Code.MVC;

namespace WWxna.Code.Game_Objects
{
    


    public class Moveable : Collidable
    {

        private Vector3 velocity;
        public Vector3 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity.X = value.X;
                velocity.Y = value.Y;
                velocity.Z = value.Z;
            }
        }

        public Moveable() : this(Globals.Game_Obj_Origin , Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Moveable(Vector3 center_) : this(center_, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Moveable(Vector3 center_, Vector3 size_) : this(center_, size_, Globals.Game_Obj_Quat) { }
        public Moveable(Vector3 center_, Vector3 size_, Quaternion theta_)
            : base(center_, size_, theta_)
        {
            velocity = new Vector3(0, 0, 0);
        }


        public override void Update()
        {
            base.Update();

            gravity();

            Vector3 center_backup = center;
            Vector3 velo_x = new Vector3(Velocity.X, 0, 0);
            Vector3 velo_y = new Vector3(0, Velocity.Y, 0);
            Vector3 velo_z = new Vector3(0, 0, Velocity.Z);

            if (GM_Proxy.Instance.get_World().get_Tile(center + velocity * GM_Proxy.Instance.Time_Step.Milliseconds).get_tile_name() != "Boundary")
                center += velocity * GM_Proxy.Instance.Time_Step.Milliseconds;
            else
            {
                if(GM_Proxy.Instance.get_World().get_Tile(center + velo_x * GM_Proxy.Instance.Time_Step.Milliseconds).get_tile_name() != "Boundary")
                    center += velo_x * GM_Proxy.Instance.Time_Step.Milliseconds;
                if(GM_Proxy.Instance.get_World().get_Tile(center + velo_z * GM_Proxy.Instance.Time_Step.Milliseconds).get_tile_name() != "Boundary")
                    center += velo_z * GM_Proxy.Instance.Time_Step.Milliseconds;

                center += velo_y * GM_Proxy.Instance.Time_Step.Milliseconds;
            }
               

            
            //** Need to add stuff to check if off map and such
            
        }

        public virtual void gravity()
        {
			if (!is_on_ground())
				velocity += Globals.grav_accel * GM_Proxy.Instance.Time_Step.Milliseconds;
			else
				on_ground();
        }

        public void accelerate(Vector3 accel)
        {
            velocity += accel * GM_Proxy.Instance.Time_Step.Milliseconds;
        }

        /// <summary>
        /// sets the object on the ground and ends velocity
        /// </summary>
		public virtual void on_ground()
		{
			if(velocity.Y < 0)
				velocity.Y = 0;

            center.Y = GM_Proxy.Instance.get_World().get_Tile(Position).get_height();
		}

    }
}
