using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using System.Diagnostics;

using WWxna.Code.MVC;                                                          

namespace WWxna.Code.Game_Objects
{
	enum Shoot_State 
	{ 
		CHILL, CHARGING, FIRE 
	};

	enum Jump_State
	{
		ON_GROUND, BOOST, FALLING_WITH_STYLE, JET_PACK
	};

	public class Mediator_Player_Controls
	{
		private H_Player p_avatar;
		private Controls c_input;
		private Shoot_State shooter;
		private Jump_State jumper;

		private Stopwatch AirTime;

		

		public Mediator_Player_Controls(Controls c_, H_Player p_)
		{
			p_avatar = p_;
			c_input = c_;
			shooter = Shoot_State.CHILL;
			jumper = Jump_State.ON_GROUND;
			AirTime = new Stopwatch();
			AirTime.Reset();
			AirTime.Stop();
		}

		public void Control_the_player()
		{
			p_avatar.Mini_Map = c_input.State.mini_map;


			//calc movement, friction handled here
			calculate_movement();

			//handle jumping state
			Handle_Jump_State();

			//handle shooting state
			Handle_Shooting_State();

			//Move Camera??
			Move_Camera();
		}


		private void Handle_Jump_State()
		{
			if (c_input.State.jet_pack_mode)
				jumper = Jump_State.JET_PACK;

			switch (jumper)
			{
				case Jump_State.ON_GROUND:
					if (c_input.State.jump)
					{
						AirTime.Start();
						jumper = Jump_State.BOOST;
					}
					break;
				case Jump_State.BOOST:
					//Boost Upwards (+Y)
					if (AirTime.ElapsedMilliseconds <= 400 && c_input.State.jump)
					{
						p_avatar.accelerate(Globals.jump_vec);
					}
					else
					{
						jumper = Jump_State.FALLING_WITH_STYLE;
						AirTime.Stop();
						AirTime.Reset();
					}
					break;
				case Jump_State.FALLING_WITH_STYLE:
					if (p_avatar.is_on_ground())
						jumper = Jump_State.ON_GROUND;
					break;
				case Jump_State.JET_PACK:
					p_avatar.accelerate(Globals.jump_vec);
					if (!c_input.State.jet_pack_mode)
						jumper = Jump_State.FALLING_WITH_STYLE;
					break;
				default:
					if (p_avatar.is_on_ground())
						jumper = Jump_State.ON_GROUND;
					else
						jumper = Jump_State.FALLING_WITH_STYLE;
					break;
			}
			Debug.Print(""+jumper);
		}

		private void Handle_Shooting_State()
		{
			//Player functions to implement -- ChargeBall,ShootBall
			
			
			//SO need  to have each state and act on it just like in the old player
			switch (shooter)
			{
				case Shoot_State.CHILL:
					if (c_input.State.shoot)
						shooter = Shoot_State.CHARGING;
					break;
				case Shoot_State.CHARGING:
                    p_avatar.charge_ball();
					if (!c_input.State.shoot)
						shooter = Shoot_State.FIRE;
					break;
				case Shoot_State.FIRE:
                    p_avatar.throw_ball();
					shooter = Shoot_State.CHILL;
					break;
				default:
					shooter = Shoot_State.CHILL;
					break;
			}
		}

		private void Move_Camera()
		{
			//adjust the camera in the player
			

			p_avatar.Camera_p.Rotate(Globals.cam_rotation_spd* -1* c_input.State.Cam.X, Globals.cam_rotation_spd* c_input.State.Cam.Y, 0);
			//Need to add a voncersion factor
		}

		private void calculate_movement()
		{//Old code sets velocity after calculating it so mimic it

			#region Bad process, broken
			/*OLD PROCESS
			 * get camera forward and left, normalize them
			 * create temp variable with new velocity
			 * Determine input target velocity
			 *      Based on control sticks and some constants
			 * Force Z independence
			 * Get friction, from center - might need to make readable
			 * Determine acceleratoin vector based on vector subtraction
			 *      subtraction, makes the vectors very small though, but I think they are normalized
			 *      
			 * Apply friction and scaling factors, 
			 * set the players velocity
			*/

			/*
			int x;
			if (c_input.which_id == PlayerIndex.One)
				x = 1;
			
			//Up Cross Forward will give right
			Vector3 Forward = p_avatar.Camera_p.ViewDirection;
			Vector3 Left = Vector3.Cross(new Vector3(p_avatar.Camera_p.ViewDirection.X, 0, p_avatar.Camera_p.ViewDirection.Z), Vector3.Up);

			Forward.Normalize();
			Left.Normalize();

			Vector3 Temp_Vel = new Vector3(p_avatar.Velocity.X, p_avatar.Velocity.Y, p_avatar.Velocity.Z);
			float temp_Zvel = p_avatar.Velocity.Y;

			Vector3 Target_Vel = (Forward * c_input.State.Move.Y) + (Left * c_input.State.Move.X);

			//MAGIC NUMBER, Redo as Standard Speed later
			Target_Vel *= 20;
			//MAGIC NUMBER, Friction not implemented yet
			float friction = 0.2f;

			//Some of the multiplication constants are wrong here

			//Now the vector difference, may need to normalize Temp Velocity?
			
			//Vector3 Net_Accel = Target_Vel - Temp_Vel;
			Vector3 Net_Accel = Target_Vel + Temp_Vel;
			//Multiply this by speed? Normalization is gonna throw all this shit off
			if(Net_Accel.Length() > 0.1)
				Net_Accel.Normalize();
			Net_Accel *= 20;

			Temp_Vel *= (1 - friction / 10);
			Temp_Vel += Net_Accel * GM_Proxy.Instance.Time_Step;

			if (Temp_Vel.Length() < 0.1)
				Temp_Vel = Vector3.Zero;

			Temp_Vel.Y = temp_Zvel;
			p_avatar.Velocity = Temp_Vel;

			if (c_input.which_id == PlayerIndex.One)
			{
				GM_Proxy.Instance.add_hud_string(new Point(300, 50),
					"Vel X:" + Math.Round(p_avatar.Velocity.X) + 
					" Y:" + Math.Round(p_avatar.Velocity.Y) + 
					" Z:" + Math.Round(p_avatar.Velocity.Z));

				Debug.Print("Vel X:" + Math.Round(p_avatar.Velocity.X) +
					" Y:" + Math.Round(p_avatar.Velocity.Y) +
					" Z:" + Math.Round(p_avatar.Velocity.Z));
			}
			
			*/
#endregion


			//Temporary Movement, No Friction but works effectively
			const int speed_c = 2;
			Vector3 Forward = p_avatar.Camera_p.ViewDirection;
			Vector3 Left = Vector3.Cross(new Vector3(p_avatar.Camera_p.ViewDirection.X, 0, p_avatar.Camera_p.ViewDirection.Z), Vector3.Up);
			Forward.Normalize();
			Left.Normalize();
			Vector3 New_Vel = (Forward * c_input.State.Move.Y) + (Left * c_input.State.Move.X);

			New_Vel *= speed_c;
			New_Vel.Y = p_avatar.Velocity.Y;

			p_avatar.Velocity = New_Vel;

			if (c_input.which_id == PlayerIndex.One)
			{
				GM_Proxy.Instance.add_hud_string(new Point(300, 50),
					"Vel X:" + Math.Round(p_avatar.Velocity.X) +
					" Y:" + Math.Round(p_avatar.Velocity.Y) +
					" Z:" + Math.Round(p_avatar.Velocity.Z));

				GM_Proxy.Instance.add_hud_string(new Point(300, 150),
					"Pos X:" + Math.Round(p_avatar.Position.X) +
					" Y:" + Math.Round(p_avatar.Position.Y) +
					" Z:" + Math.Round(p_avatar.Position.Z));

				//GM_Proxy.Instance.add_hud_string(new Point(300, 200),
				//    "Current TimeStep Size:" + GM_Proxy.Instance.Time_Step);
			}



		}


	}
}
