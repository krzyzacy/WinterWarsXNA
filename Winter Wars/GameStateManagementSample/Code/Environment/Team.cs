using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using WWxna.Code.Game_Objects;

namespace WWxna.Code.Environment
{
	public enum Team_Color_e {
		GREEN, RED, BLUE, ORANGE, YELLOW, PURPLE
	}; // USE null INSTEAD OF NEUTRAL

    public class Team
    {
		public Team(iTile BaseTile = null){} //Enter Players, And Color?

		public void add_player(Player player){}

		//Victory Stuf
//		public bool Is_Tree_Claimed(){}
		public void Start_Victory_Countdown(){}
		public void Stop_Victory_Countdown(){}
//		public bool win(){}	//Tells the rest of the game we've won
//		public float time_till_win(){}

		//Network related
		public void update(){}
		public void check_connectivity(){}	//Deactivates tiles if they aren't connected
		public void Deactivate_disconnected(){}
		public void reintegrate_connected(){}
		public void add_tile(iTile tile){}
		public void remove_tile(iTile tile){}

//		public bool is_in_network(iTile tile){}
//		public bool is_adjacent_to_network(iTile tile){}
		public void destabilize_network() { network_unstable = true; }
		public void modify_resources(int amt){}
//		public int take_resources(int amt){}

		public void message_team(String message, int priority = 0){}

		public bool is_empty() { return members.Count() == 0; }

		//Building related
//		public bool tile_is_ready(iTile candidate, int type){}

		//Set Up and utility
		public int get_Resources() { return Ice_Blocks; }
//		public Vector3 get_spawn_point() { }

		// returns null if index == number of players
		public Player get_player(int index)
		{
			return members[index];
		}

		 // returns "orange", "blue", etc.
//		public String get_name(){}

		// returns "Orange", "Blue"
//		public String get_name_Upper_Case(){}

	/*	struct Stats{
			Stats() :
				total_resources(0), largest_network(0), 
				tiles_lost(0), final_network(0), resources_spent(0)
			{
				for (int i = 0 ; i < 5 ; i++)
					structures[i] = 0;
			}
			int total_resources;
			int largest_network;
			int tiles_lost;
			int final_network;	
			int resources_spent;
			int structures[5];

			int all_structures()
			{	int ret = 0;
				for (int i = 0 ; i < 5 ; i++)
					ret += structures[i];
				return ret;
			}

		} stats;
*/
		//list of players
		private List<Player>	members;
		private bool network_unstable;

		//Resource value
		private int Ice_Blocks;
		private int intake_rate;

	//	Zeni::Chronometer<Zeni::Time> ResourceTime;
	//	Zeni::Chronometer<Zeni::Time> WinTimer;

		public Team_Color_e Team_Color
		{
			get
			{
				return Team_Color;
			}
			set
			{
				Team_Color = value;
			}
		}

		//Holds tile information pertininet to team
		private HashSet<iTile> Network;
		private HashSet<iTile> Adjacent_Tiles;
		private HashSet<iTile> Disconnected_Tiles;

		private iTile Base;
    }
}
