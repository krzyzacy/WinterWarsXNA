using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using WWxna.Code.Environment;

namespace WWxna.Code.Game_Objects.Structures
{
    class Snowman : Structure
    {	
		Vector3 left_launch;
		Vector3 right_launch;

		bool left; // What is this?

//		Zeni::Chronometer<Zeni::Time> reload_time;
//		Zeni::Chronometer<Zeni::Time> targeting_delay;

		LinkedList<Vector3> targets;

		public Snowman(Team team, iTile tile_) :
			base(team, tile_)
		{
//			animation_state = new Present_wrapped();

			left = true;
			left_launch = center - new Vector3(50, 0,0);
			right_launch = center + new Vector3(50, 0,0);
//			targeting_delay.start();
//			reload_time.start();
		}

		public override void Update()
		{			
			Vector3 axis = new Vector3(0,10,0);
			base.Update();

			//Magic happens here, need to decide how this will works, def statemachine
			if (Status == Structure_State_e.UNWRAP_MODE)
			{
				center.Z -= 8;
				Status = Structure_State_e.BUILT; //<- why not in Structure????
			}

			if (Status != Structure_State_e.PRESENT_MODE && Status != Structure_State_e.UNWRAP_MODE)
			{
				update_snowman_state();
			}
		}

		private void update_snowman_state()
		{ 
			// put this into more functions/add more comments
/*			if (Connected_to_Team)
			{
				float turn = 0;
				if(targets.empty())
					switch_state(SM_STAND);

				if(!targets.empty() && reload_time.seconds() > 0.5)	
				{
					Point3f aim = targets.front();
					targets.pop_front();
					turn = axis.angle_between((center - aim).get_ij());
					if (center.x > aim.x) turn *= -1;
					rotation = Quaternion(turn,0,0);
					//Launch depending on the orientation of the snowman
					left_launch = center - Vector3f(50*cos(turn), 50*sin(turn),0);
					right_launch = center + Vector3f(50*cos(turn), 50*sin(turn),0);
					Point3f Origin = right_launch;
					if(left) Origin = left_launch;
					Game_Model::get().play_snowballthrow();
					Snowball* sb = new Snowball(owner, Origin, Globals.snowman_snowball_size);
					Vector3f sight_line(aim - Origin);
					//sight_line.z += 20;
					//sb->get_thrown(aim - Origin);
					sb->get_thrown(sight_line.normalize(), 600);
					Game_Model::get().add_moveable(sb);
					if(left)
						switch_state(SM_THROWR);
					else
						switch_state(SM_THROWL);
					left = !left;
					reload_time.reset();
				}
			}
			else
				switch_state(SM_ISO);
*/		
		}
/*
		private void handle_player_in_range(Team t, Collision::Capsule person)	
		{
			//Could add velocity stuff later, to predict motion, but fuck it for now
			if(t->get_Team_Index() == hex->get_team())
				return;

			if(!person.intersects(field))
				return;

			//Target the player if targeting threshold has passed
			if(targeting_delay.seconds() > 0.5)	{
				Point3f head = person.get_end_point_a() + Vector3f(0,0,20);
				targets.push_back(head);
				targeting_delay.reset();
			}
		}
*/
		public override String get_model_name()  
		{
			return "Snowman";
		}

		protected override void create_body()
		{

		}

/*
		public Animator get_animator() 
		{
			return animation_state;
		}

*/
		public override float get_integrity()
		{
			return Globals.snowman_integrity;
		}
    }
}
