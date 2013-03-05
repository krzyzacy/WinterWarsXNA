using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


using Microsoft.Xna.Framework;

using WWxna.Code.Environment;

namespace WWxna.Code.Game_Objects.Structures
{

	public enum	Structure_State_e	{
		PRESENT_MODE, UNWRAP_MODE, BUILT, DAMAGED, DESTROYED
	};

    abstract class Structure : Collidable
    {
		protected float health;
		protected Structure_State_e Status;
		protected bool Connected_to_Team;

		protected Vector3 default_position;
		protected Vector3 default_size;
		protected float default_radius;
		protected Team owner;
		protected iTile tile_on;

		Stopwatch Isolation_Clock = new Stopwatch();
		Stopwatch Present_Clock = new Stopwatch();	
		protected bool opened;

	//	Collision::Capsule body;
		protected float save_height;


		protected Structure(Team team, iTile tile_, float radius = 10.0f) :
			base(tile_.get_top_center() + new Vector3(0, 400, 0), new Vector3(1,1,1) * radius)
		{
			owner = team; 
			health = get_integrity(); 
			Status = Structure_State_e.PRESENT_MODE; 
			Connected_to_Team = true; 
			tile_on = tile_; 
			opened = false;
			default_position = center; 
			default_size = new Vector3(1,1,1)*radius; 
			default_radius = radius;

			create_body();

			save_height = tile_on.get_height();
			Present_Clock.Start();
		}

		public override void Update()
		{
			//Structures don't move, so their body doen't need to be changed.

			base.Update();

			if(Status == Structure_State_e.DESTROYED)	
			{
//				perform_destruction_effects();
//				tile_on.destroy_structure();
				owner.remove_tile(tile_on);
			}
	
			if(Isolation_Clock.ElapsedMilliseconds > Globals.time_isolated)	
			{
				Status = Structure_State_e.DESTROYED;
	//			Game_Model::get().play_chainbreak(); // Sound
			}

			if (Present_Clock.ElapsedMilliseconds > Globals.time_as_present && !opened)
			{
				opened = true; 
				Status = Structure_State_e.UNWRAP_MODE;
			}

			if (Status == Structure_State_e.UNWRAP_MODE)
			{
	
				/* EWWW
				
				switch(owner.get_Team_Index())	
				{
					case BLUE:
						{
						Game_Model::get().add_effect(new Effect("bluepresent_unwrapped", center, size, 50));
						break;
						}
					case GREEN:
							{
							Game_Model::get().add_effect(new Effect("greenpresent_unwrapped", center, size, 50));
							break;
							}
					case RED:
							{
							Game_Model::get().add_effect(new Effect("redpresent_unwrapped", center, size, 50));
							break;
							}
					case ORANGE:
							{
							Game_Model::get().add_effect(new Effect("orangepresent_unwrapped", center, size, 50));
							break;
							}
					default:
						Game_Model::get().add_effect(new Effect("bluepresent_unwrapped", center, size, 50));
						break;
				}
				 */
				restore_default_size_and_position();
				center.Z -= (save_height - tile_on.get_height());
			}
		}

		public void change_height(float delta)
		{
			center.Z += delta;
		}

		public void receive_hit(float damage)
		{		
			health -= damage;
			if(health < 0)
				Status = Structure_State_e.DESTROYED;
		}

		public virtual void handle_player_collision(Player P)
		{
			//Should be overwritten by each
			//However fort and factory, for now do the same thing
			if (Status == Structure_State_e.PRESENT_MODE)
				return;

	//		P->push_away_from(center, 25);
		}

		public virtual void destabilize_network() { }
		public Team get_team_pt() { return owner; }

		public void perform_destruction_effects()
		{
/*			
			if(Isolation_Clock.seconds() < 10)
				Game_Model::get().play_breaking();

			int quantity = rand()%8;
			for(int i = 0; i < quantity; i++)	{
				int size = rand()%30;
				int x_off = rand()%150 - 75;
				int y_off = rand()%150 - 75;
				int z_off = rand()%80 - 25;
				Game_Model::get().add_effect(new Effect("explode", center + Vector3(x_off, y_off, z_off), Vector3(1,1,1)*size));
			}
*/
		}

		public void begin_isolation()
		{
			Connected_to_Team = false;
			Isolation_Clock.Start();
		}

		public void reintegrate()
		{
			Connected_to_Team = true;
			Isolation_Clock.Stop();
			Isolation_Clock.Reset();
		}

	//	virtual void handle_player_in_range(Team color, Collision::Capsule person)	{}

		public virtual bool is_snow_maker() { return false; }

		public void save_position()
		{

		}

		// State?  Building . Built . Damaged? . Destroyed??
		//Would the damaged state look different? like a broken version of the model???
		//could be cool
	
		/*
		// Animation
		StructureAnimator animation_state;
		virtual Animator get_animator() const;
		virtual void switch_state(StructureEvent_e);
		*/

		public void restore_default_size_and_position()
		{
			center = default_position;
			size = default_size;
			center.Z += default_radius / 2;
		}


		protected virtual void create_body() { }

		public virtual float get_integrity()
		{ return 0; }

		public override int get_ID()
		{ return ID(); }

		public static new int ID()
		{ return 3; }
    }
}
