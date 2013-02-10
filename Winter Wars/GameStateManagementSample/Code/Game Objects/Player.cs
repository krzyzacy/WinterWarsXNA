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


        public Player() : this(Globals.Game_Obj_Origin , Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Player(Vector3 center_) : this(center_, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Player(Vector3 center_, Vector3 size_) : this(center_, size_, Globals.Game_Obj_Quat) { }
        public Player(Vector3 center_, Vector3 size_, Quaternion theta_)
            : base(center_, size_, theta_)
        {
            

        }


        public virtual void Update()
        {
            base.Update();
        }
            
    }

    class H_Player : Player
    {
        public Camera camera;
        protected Mediator_Player_Controls PC_mediator;

        private H_Player() { } //No default constructor

        public H_Player(Controls control_) : this(control_, Globals.Game_Obj_Origin , Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public H_Player(Controls control_, Vector3 center_) : this(control_, center_, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public H_Player(Controls control_, Vector3 center_, Vector3 size_) : this(control_, center_, size_, Globals.Game_Obj_Quat) { }
        public H_Player(Controls control_, Vector3 center_, Vector3 size_, Quaternion theta_)
            : base(center_, size_, theta_)
        {
            camera = new Camera(Vector3.Zero);

        }

        public Camera Camera
        {
            // Set the position of the camera in world space, for our view matrix.
            // This could adjust where the camera should be using base class variables
            //      so we don't have to override base class functions

            get
            {
                return camera;
            }
            
            set {}
        }

        public override void Update()
        {
            PC_mediator.Control_the_player();

            base.Update();
        }


    }

    class AI_PLayer : Player
    {
    }

}
