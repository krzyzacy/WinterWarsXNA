using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;


namespace Winter_Wars_XNA_Windows.Winter_Wars_Code.MVC
{
    class Camera
    {
        public Camera(Vector3 pos_) : this(pos_, Vector3.Forward, Vector3.Up) { }
        public Camera(Vector3 pos_, Vector3 facing_, Vector3 up_)
        {
            pos = pos_;
            up = up_;
            facing = facing_;
        }

        Matrix get_matrix()
        {
            return Matrix.CreateLookAt(pos, facing, up);
        }

        public Vector3 pos;
        public Vector3 up; 
        public Vector3 facing;

        // TODO: Make fxns for turning and stuff. We shouldn't have these variables public
            // They ahould only have getters!  Use the fxns to manipulate
    }
}
