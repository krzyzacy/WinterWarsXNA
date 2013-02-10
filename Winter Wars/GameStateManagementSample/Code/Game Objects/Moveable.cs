﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using WWxna.Code.MVC;

namespace WWxna.Code.Game_Objects
{
    


    class Moveable : Collidable
    {
        public Vector3 grav_accel = new Vector3(0,0,10);

        protected Vector3 velocity;

        public Moveable() : this(Globals.Game_Obj_Origin , Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Moveable(Vector3 center_) : this(center_, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Moveable(Vector3 center_, Vector3 size_) : this(center_, size_, Globals.Game_Obj_Quat) { }
        public Moveable(Vector3 center_, Vector3 size_, Quaternion theta_)
            : base(center_, size_, theta_)
        {
            velocity = new Vector3(0, 0, 0);
        }


        public void Update()
        {
            base.Update();

            gravity();
            center += velocity * Standard_Model.Instance.Time_Step;

            //** Need to add stuff to check if off map and such
            
        }

        public void gravity()
        {
            if(!is_on_ground())
                velocity += grav_accel * Standard_Model.Instance.Time_Step;
           // else
           //     on_ground()
        }

        public void set_velocity(Vector3 vel)
        {
            velocity = vel;
        }

        public void accelerate(Vector3 accel)
        {
            velocity += accel * Standard_Model.Instance.Time_Step;
        }
    }
}
