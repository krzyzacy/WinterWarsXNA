using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;


namespace WWxna.Code
{
    /// <summary>
    /// This class contains the global constants and variables
    /// for the whole project
    /// </summary>


    public static class Globals
    {
        //Represents standard game object size
        private static Vector3 GO_size = new Vector3(1, 1, 1);
        private static Vector3 GO_origin = Vector3.Zero;
        private static Quaternion GO_quat = new Quaternion(0,0,1,0);

        public static float cam_rotation_spd = 2;

        //All of these return new instances with values in the variables above
        #region Global_Gets
        //The intention is to use them in constructors. 
        //If we want to use them differnetly later, it should be pretty easy to modify
        //but be aware that they return a reference to a new object

        public static Vector3 Game_Obj_Size
        {
            get
            {
                return new Vector3(GO_size.X, GO_size.Y, GO_size.Z);
            }
        }

        public static Vector3 Game_Obj_Origin
        {
            get
            {
                return new Vector3(GO_origin.X, GO_origin.Y, GO_origin.Z);
            }
        }

        public static Quaternion Game_Obj_Quat
        {
            get
            {
                return new Quaternion(GO_quat.X, GO_quat.Y, GO_quat.Z, GO_quat.W);
            }
        }


        #endregion



		#region Fun_Variables
		// The following variables are variables that need to be tweaked to determine
		// gameplay fun-ness. Put anything you can think of here. 
		// We can make a menu that lets players decide what values these should have too.

			#region structure_stuff
				public static float fort_integrity = 250;
				public static float healing_pool_integrity = 150;
				public static float snowman_integrity = 100;
				public static float snow_factory_integrity = 80;

				public static float healing_rate = 30;
		
				public static Vector3 snowman_snowball_size = new Vector3(8,8,8);
			#endregion

		#endregion
	}
}
