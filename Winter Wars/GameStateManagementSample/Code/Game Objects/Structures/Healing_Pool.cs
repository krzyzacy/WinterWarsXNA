using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using WWxna.Code.Environment;

namespace WWxna.Code.Game_Objects.Structures
{
	class Healing_Pool : Structure
	{
		public Healing_Pool(Team team, iTile tile_) :
			base(team, tile_)
		{
	//		animation_state = new Present_wrapped();
		}

		public override void Update()
		{
			base.Update();

			if (Status == Structure_State_e.UNWRAP_MODE)
			{
				center.Z -= 22;
				//Magic number shift height attempt
				Status = Structure_State_e.BUILT;
			}

			if (Status != Structure_State_e.PRESENT_MODE 
			 && Status != Structure_State_e.UNWRAP_MODE)
			{
/*
				if (Connected_to_Team)
					switch_state(POOL_HEAL);
				else
					switch_state(POOL_ISO);
*/			}
		}

		public override void handle_player_collision(Player player)	
		{
			if (Status == Structure_State_e.PRESENT_MODE)
			{
				base.handle_player_collision(player);
				return;
			}
			
			if (!Connected_to_Team)
				return;

			// heal this player
			if (player.Team == owner)	
			{
				//	switch_state(POOL_HEAL);
//				player.healing_waters(Globals.healing_rate * Game_Model::get().get_time_step());
			}
			
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
