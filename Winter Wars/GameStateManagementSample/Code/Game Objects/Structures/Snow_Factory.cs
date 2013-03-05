using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;

using WWxna.Code.Environment;

namespace WWxna.Code.Game_Objects.Structures
{
	class Snow_Factory : Structure
	{
		public Snow_Factory(Team team, iTile tile_) :
			base(team, tile_)
		{
			produce_snow();
		
	//		animation_state = new Present_wrapped();
		}
		
		public override void Update()
		{
			if(Status == Structure_State_e.DESTROYED)
			{
				handle_destruction();				
			}

			base.Update();

			if (Status == Structure_State_e.UNWRAP_MODE)
			{
				// I don't know why this is here
				size = size * new Vector3(0.5f, 0.5f, 0.5f);
				center.Z -= 30;

				Status = Structure_State_e.BUILT;
			}

			if (Status != Structure_State_e.PRESENT_MODE && Status != Structure_State_e.UNWRAP_MODE)
			{
	/*			if (Connected_to_Team)
					switch_state(FAC_SPIN);
				else
					switch_state(FAC_ISO);
	*/		}
		}

		// turns every tile touching the tile it is on to a soft_snow Tile
		private void produce_snow()
		{
/*	
			list<Tile> family = Game_Model::get().get_World()->Get_Family(tile_on);
			
			for(list<Tile>::iterator it = family.begin(); it != family.end(); ++it)
				(it)->set_covering(SOFT_SNOW);
			
			tile_on.set_covering(SOFT_SNOW);
*/
		}

		private void handle_destruction()
		{
/*
			tile_on.set_covering(ICE);
			//First sets the covering of all the tiles to randomly Ice or snow
			list<Tile> nuc_family = Game_Model::get().get_World()->Get_Family(tile_on);
			for(list<Tile>::iterator it = nuc_family.begin(); it != nuc_family.end(); ++it)					{
				if((it) == 0) continue;
				int randomcov = rand() %2;
				if(randomcov == 0) (it)->set_covering(ICE);
				if(randomcov == 1) (it)->set_covering(HARD_SNOW);
			}

			//Then, iff they are double covered, turns back to soft snow
			nuc_family.push_back(tile_on);
			for(list<Tile>::iterator it = nuc_family.begin(); it != nuc_family.end(); ++it)	
			{
				if((it) != tile_on && (it)->has_building() && (it)->get_building()->is_snow_maker())	
				{
					(it)->set_covering(SOFT_SNOW);
					continue;
				}
				list<Tile> ext_fam = Game_Model::get().get_World()->Get_Family(it);
				for(list<Tile>::iterator efit = ext_fam.begin(); efit != ext_fam.end(); ++efit)	
				{
					if((efit) != tile_on && (efit)->has_building())	
					{
						if((efit)->get_building()->is_snow_maker())	
						{
							(it)->set_covering(SOFT_SNOW);
							break;
						}
					}
				}
			}
*/
		}

		public override String get_model_name() 
		{
			return "Snow_Factory";
		}

		protected override void create_body()	{ }
/*
		Animator get_animator() const
		{
			return animation_state;
		}
*/
		public override float get_integrity()
		{
			return Globals.snow_factory_integrity;
		}
	}
}
