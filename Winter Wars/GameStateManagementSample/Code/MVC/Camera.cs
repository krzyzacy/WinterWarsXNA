using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace WWxna.Code.MVC
{
    public class Camera
    {
        public Camera(Vector3 pos_) : this(pos_, Vector3.Forward, Vector3.Up) { }
        public Camera(Vector3 pos_, Vector3 facing_, Vector3 up_)
        {
            pos = pos_;
            up = up_;
            facing = facing_;
        }

        private Vector3 pos;
        private Vector3 up; 
        private Vector3 facing;

        #region Get and Set

        public Vector3 Position
        {
            get
            {
                return new Vector3(pos.X, pos.Y, pos.Z);
            }
            set 
            {
                pos.X = value.X;
                pos.Y = value.Y;
                pos.Z = value.Z;
            }
        }

        public Vector3 Up
        {
            get
            {
                return new Vector3(up.X, up.Y, up.Z);
            }
            set { }
        }

        public Vector3 Facing
        {
            get
            {
                return new Vector3(facing.X, facing.Y, facing.Z);
            }
            set { }
        }

        #endregion 

        // TODO: Make fxns for turning and stuff. We shouldn't have these variables public
            // They ahould only have getters!  Use the fxns to manipulate
        //Hey so I think this set up will work, 
        //but I had to return a new vector? so that it doesnt get the refernce to vec?

        Matrix get_matrix()
        {
            return Matrix.CreateLookAt(pos, facing, up);
        }


        public void Turn_Left_xy(float theta) { }
        public void Move_forward() { }



    }
}
