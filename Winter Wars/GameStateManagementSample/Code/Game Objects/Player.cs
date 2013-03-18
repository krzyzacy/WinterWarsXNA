using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using Microsoft.Xna.Framework;

using WWxna.Code.Environment;
using WWxna.Code.MVC;
using WWxna.Code.Game_Objects.Structures;

namespace WWxna.Code.Game_Objects
{
    
    public class Player : Moveable
    {
        public Player() : this(Globals.Game_Obj_Origin, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Player(Vector3 center_) : this(center_, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Player(Vector3 center_, Vector3 size_) : this(center_, size_, Globals.Game_Obj_Quat) { }
        public Player(Vector3 center_, Vector3 size_, Quaternion theta_)
            : base(center_, size_, theta_)
        {
            player_KO = false;
            my_team = null;
            snow_in_pack = Globals.Max_Snow_in_pack;
            //we need to set the team somewhere
        }

		public override string get_model_name()
		{
			return Team.get_name() + "Girl";
		}

        //Going to mostly implement it here and then maybe redo it in AI or H
        //Need to also bring in constructurs to make this as versatile as possible
        private Team my_team;
		public Team Team
		{
			get
			{
				return my_team;
			}
			set
			{
				my_team = value;
			}
		}

        //protected BoundingSphere body;
        protected float snowball_radius;
        protected float snow_in_pack;

        private bool player_KO;
        public Boolean Player_KO
        {
            get
            {
                return player_KO;
            }
            protected set
            {
                player_KO = value;
            }
        }
   

        public override void Update()
        {
            //Debug.Print("CenterZ: " + center.Z);
            base.Update();
        }

		public void build_structure(Structure_Type_e type)
		{
			//My state if we add it...


		 	try
			{
				iTile build_on = GM_Proxy.Instance.get_World().get_Tile(center);
				// team.tile_is_ready
				
				Structure.create(type, my_team, build_on);
				// decrease resourses
				// increment stats
			
			}
			catch (Exception)
			{ 
				// add message that you cant build and why
				
			}


		}


		public override int get_ID()
		{ return ID(); }

		public static new int ID()
		{ return 1; }

        /// <summary>
        /// Increase the radius of the current snowball by a constant rate 
        /// that is determined in by a fun variable
        /// </summary>
        public void charge_ball()
        {
            if (Player_KO)
                return;

            if (snow_in_pack <= 0)
            {
                //add messsage %%%%%
                snow_in_pack = 0;
            }
            else if (snowball_radius >= Globals.Max_projectile_size)
            {
                snowball_radius = Globals.Max_projectile_size;
            }
            else
            {
                //Current packing methods of casiting floats and doubles, or just use ints?
                snowball_radius += Globals.snowball_making_rate * (float)GM_Proxy.Instance.Time_Step.TotalSeconds;
                //stats
                snow_in_pack -= Globals.snow_depletion_rate * (float)GM_Proxy.Instance.Time_Step.TotalSeconds;
            }

            
        }

        /// <summary>
        /// Release the current ball and give it an initial velocity as well as
        /// adding it to the model.
        /// </summary>
        public virtual void throw_ball()
        {
            if (Player_KO)
                return;

            if (snowball_radius <= 0)
                return;

            Snowball sb = new Snowball(this, center, new Vector3(snowball_radius, snowball_radius, snowball_radius));
            snowball_radius = 0;
            //This presents a problem, where AI and human diverge
            sb.Launch_Projectile(new Vector3(0, 1, 0));
            GM_Proxy.Instance.add_moveable(sb); 
        }


    }

    public class H_Player : Player
    {
        private CameraComponent camera;
        protected Mediator_Player_Controls PC_mediator;
        private bool mini_map;

		public Structure_Type_e structure_wheel_pos {get; set;}

        public Boolean Mini_Map
        {
            get
            {
                return mini_map;
            }
            set
            {
                mini_map = value; 
            }
        }

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

			structure_wheel_pos = Structure_Type_e.HEALING_POOL;

            camera.Perspective(95, 1280 / 800, 2f, 3000);
            //game_.GraphicsDevice.Viewport.AspectRatio
            //DO THIS BRO
            //aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;
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

		

        public override void throw_ball()
        {
            if (Player_KO)
                return;

            if (snowball_radius <= 0)
                return;

            Snowball sb = new Snowball(this, center, new Vector3(snowball_radius, snowball_radius, snowball_radius));
            snowball_radius = 0;
            //This presents a problem, where AI and human diverge
            sb.Launch_Projectile(Camera_p.ViewDirection);
            GM_Proxy.Instance.add_moveable(sb);
            
        }

    }

    class AI_PLayer : Player
    {
    }

}
