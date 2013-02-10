using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using WWxna.Code.Environment;
using WWxna.Code.MVC;


namespace WWxna.Code.Game_Objects
{
    

    class Player : Moveable
    {
        //Going to mostly implement it here and then maybe redo it in AI or H
        //Need to also bring in constructurs to make this as versatile as possible
        

        protected Team myTeam;
        protected bool mini_open;
        protected BoundingSphere body;

        public void Update()
        {
            base.Update();
        }
            
    }

    class H_Player : Player
    {
        Camera camera;

        public H_Player()
        {
            camera = new Camera(Vector3.Zero);
        }

        public Camera get_camera()
        {
            // Set the position of the camera in world space, for our view matrix.
            // This could adjust where the camera should be using base class variables
            //      so we don't have to override base class functions

            return camera;
        }

        public void Update()
        {
            
        }


    }

    class AI_PLayer : Player
    {
    }

}
