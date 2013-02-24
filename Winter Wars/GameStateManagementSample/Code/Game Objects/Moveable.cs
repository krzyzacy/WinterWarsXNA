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
        public Vector3 grav_accel = new Vector3(0,-0.09f,0);

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
            center += velocity * GM_Proxy.Instance.Time_Step.Milliseconds;

            
            //** Need to add stuff to check if off map and such
            
        }

        public void gravity()
        {
			if (!is_on_ground())
				velocity += grav_accel * GM_Proxy.Instance.Time_Step.Milliseconds;
			else
				on_ground();
        }

        public void accelerate(Vector3 accel)
        {
            velocity += accel * GM_Proxy.Instance.Time_Step.Milliseconds;
        }

		public virtual void on_ground()
		{
			if(velocity.Y < 0)
				velocity.Y = 0;

			// %%%% must add the world calculations to this later as well
            /* hard coded */
			center.Y = 400.0f;
		}

    }
}
