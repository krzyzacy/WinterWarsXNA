using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using WWxna.Code.Environment; 

namespace WWxna.Code.Game_Objects.Structures
{
	class Catapult : Structure
	{

		// JK.  this does nothing

		public Catapult(Team team, iTile tile_) :
			base(team, tile_)
		{

		}

		public override void Update()
		{
			base.Update();
		}

		public override void handle_player_collision(Player player)	
		{
			
		}

		public override String get_model_name()  
		{
			return "Healing_Pool";
		}

		protected override void create_body()		{}

/*
		public Animator get_animator() 
		{
			return animation_state;
		}

*/
		public override float get_integrity()
		{
			return Globals.healing_pool_integrity;
		}
	}
}
