using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using Microsoft.Xna.Framework;

using WWxna.Code.Environment;
using WWxna.Code.MVC;


namespace WWxna.Code.Game_Objects
{
    

    public class Player : Moveable
    {
        //Going to mostly implement it here and then maybe redo it in AI or H
        //Need to also bring in constructurs to make this as versatile as possible
        private Team myTeam;
        protected bool mini_open;
        protected BoundingSphere body;


        public Player() : this(Globals.Game_Obj_Origin , Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Player(Vector3 center_) : this(center_, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Player(Vector3 center_, Vector3 size_) : this(center_, size_, Globals.Game_Obj_Quat) { }
        public Player(Vector3 center_, Vector3 size_, Quaternion theta_)
            : base(center_, size_, theta_)
        {
            

        }


        public override void Update()
        {
            //Debug.Print("CenterZ: " + center.Z);
            base.Update();
        }

		public override int get_ID()
		{ return ID(); }

		public static new int ID()
		{ return 1; }
        
    }

    public class H_Player : Player
    {
        private CameraComponent camera;
        protected Mediator_Player_Controls PC_mediator;

        private H_Player() { } //No default constructor

        public H_Player(Game game_, Controls control_) : this(game_, control_, Globals.Game_Obj_Origin, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public H_Player(Game game_, Controls control_, Vector3 center_) : this(game_, control_, center_, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public H_Player(Game game_, Controls control_, Vector3 center_, Vector3 size_) : this(game_, control_, center_, size_, Globals.Game_Obj_Quat) { }
        public H_Player(Game game_, Controls control_, Vector3 center_, Vector3 size_, Quaternion theta_)
            : base(center_, size_, theta_)
        {
            //So since everything is a reference if we set the camera's position to
            //the same reference as Seen Object's Center should update in sync
            //If not, we need to update the camera during update
            
            //OLD
            //camera = new Camera(center, Vector3.Up, Vector3.Backward);

            camera = new CameraComponent(game_);
            PC_mediator = new Mediator_Player_Controls(control_, this);

            camera.Perspective(90, 4 / 3, 2f, 3000);

        }

        public CameraComponent Camera_p
        {
            // Set the position of the camera in world space, for our view matrix.
            // This could adjust where the camera should be using base class variables
            //      so we don't have to override base class functions

            //Sooo what exactly does the camera position mean
            get
            {
                return camera;
            }
            set {}
        }

        public override void Update()
        {
            //Update the Camera before this
            PC_mediator.Control_the_player();
            
            //OLD
            //P_Camera.Position = center;
            
            //Debug.Print("Camera Pos:" + Camera_p.Position.Z);

            base.Update();

            Camera_p.Position = center;

        }


    }

    class AI_PLayer : Player
    {
    }

}
