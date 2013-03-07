using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using WWxna.Code.Environment;

namespace WWxna.Code.Game_Objects.Structures
{
	class Fort : Structure
	{
		public Fort(Team team_, iTile tile_) :
			base(team_, tile_)
		{
//			animation_state = new Present_wrapped();
		}
		
		public override void handle_player_collision(Player player)
		{
			// if its a present, hit it
			if (Status == Structure_State_e.PRESENT_MODE)
			{
				base.handle_player_collision(player);
				return;
			}

			// if it is not yours you cant go inside it
			if (player.Team != owner)
				base.handle_player_collision(player);
		}

		public override void Update()
		{
			base.Update();
		}

		public override String get_model_name()  
		{	
			return "Fort";
		}

/*		public Animator get_animator() 
		{
			return animation_state;
		}
*/
		protected override void create_body()	{}

		public override float get_integrity()
		{
			return Globals.fort_integrity;
		}
	}
}
