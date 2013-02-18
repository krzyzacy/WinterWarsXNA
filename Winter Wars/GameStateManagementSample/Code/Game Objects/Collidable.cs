using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;


namespace WWxna.Code.Game_Objects
{
    public class Collidable : Seen_Object
    {
        protected BoundingSphere body;

        //Hold Up. So the whole point here is to allow a basic set of inputs, without magic numbers
        //but also allow minimal inputs
        //So make some constants in Seen Object
        // Plug them in to dans contructor,
        // THen remake the constructur set for moveable and other stuff


           
        public Collidable() : this(Globals.Game_Obj_Origin , Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Collidable(Vector3 center_) : this(center_, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Collidable(Vector3 center_, Vector3 size_) : this(center_, size_, Globals.Game_Obj_Quat) { }
        public Collidable(Vector3 center_, Vector3 size_, Quaternion theta_)
            : base(center_, size_, theta_)
        {
            //Set Collision body stuff up here
            body = new BoundingSphere(center, size.Length());
            //Temporary for now
        }

        public virtual void Update()
        {
            
        }

        //We can't do friends so that needs to change

    }
}
