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

	public enum Structure_Type_e
	{
		SNOWMAN, FORT, SNOW_FACTORY, HEALING_POOL, TREE, BASE
	};


    public static class Globals
    {
        //Represents standard game object size
        private static Vector3 GO_size = new Vector3(10, 10, 10);
        private static Vector3 GO_origin = Vector3.Zero;
        private static Quaternion GO_quat = new Quaternion(0,0,1,0);

        public const float cam_rotation_spd = 2;

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


		#region Fun Variables
		// The following variables are variables that need to be tweaked to determine
		// gameplay fun-ness. Put anything you can think of here. 
        // We can make a menu that lets players decide what values these should have too.

        public static Vector3 grav_accel = new Vector3(0, -0.005f, 0);


            #region Snowball Stuff
                
            public const float Max_projectile_size = 50;
            public const float snowball_making_rate = 25;
            public const float snow_scooping_rate = 25;
            public const float Launch_Speed = 3;
            public const float min_snowball_damage = 15;
            public const float max_snowball_damage = 45;

            
                       
            #endregion


            #region Player Stuff

            public const float Max_Snow_in_pack = 1000;
            public const float snow_depletion_rate = 0;
            public const float Max_Player_health = 100;
            public static TimeSpan Build_Recharge_Time = new TimeSpan(0, 0, 1);
            public static TimeSpan Respawn_Time = new TimeSpan(0, 0, 6);

            public static Vector3 jump_vec = new Vector3(0, 0.01f, 0);
            
            #endregion


            #region Structure Stuff
				public static float fort_integrity = 250;
				public static float healing_pool_integrity = 150;
				public static float snowman_integrity = 100;
				public static float snow_factory_integrity = 80;

				public static Dictionary<Structure_Type_e, int> structure_cost
					= new Dictionary<Structure_Type_e, int> 
					{
						{Structure_Type_e.FORT, 2400},
						{Structure_Type_e.HEALING_POOL, 800},
						{Structure_Type_e.SNOW_FACTORY, 1600},
						{Structure_Type_e.SNOWMAN, 3200},					
					};

				public static float healing_rate = 30;
		
				public static Vector3 snowman_snowball_size = new Vector3(8,8,8);

				public static int time_as_present = 1500; // millisecs
				public static int time_isolated = 10000; // millisecs isolated from network
			#endregion

		#endregion

	}
}
