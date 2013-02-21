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

        //This class is implemented as a way to give us some proogram wide variables to use
        // such as a basic size of construct

    }
}
