using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;


namespace WWxna.Code.Game_Objects
{
    public class Collidable : Seen_Object
    {
        /// <summary>
        /// Represents the collision body for the object. Currently simple 
        /// bounding box for now. Use with caution
        /// </summary>
        public BoundingBox Body { get; set; }

        public Collidable() : this(Globals.Game_Obj_Origin , Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Collidable(Vector3 center_) : this(center_, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Collidable(Vector3 center_, Vector3 size_) : this(center_, size_, Globals.Game_Obj_Quat) { }
        public Collidable(Vector3 center_, Vector3 size_, Quaternion theta_)
            : base(center_, size_, theta_)
        {
            //Set Collision body stuff up here
            //Eh? if size is ever working properly than this should work
            //Vector3 top_right_corner = new Vector3(center.X - size.X/2, center.Y - size.Y/2, center.Z - size.Z/2);
            //Vector3 bot_left_corner = new Vector3(center.X + size.X / 2, center.Y + size.Y / 2, center.Z + size.Z / 2);
            //Body = new BoundingBox(bot_left_corner, top_right_corner);

            //Very Simple, but too big.
            Body = BoundingBox.CreateFromSphere(new BoundingSphere(center_, size.Length()));

            //Old, just a sphere
            //Body = new BoundingSphere(center, size.Length());
            
        }

        public virtual void Update()
        {
            
        }

		public virtual int get_ID()
		{ return ID(); }

		public static int ID()
		{ return 0; }
    }
}
