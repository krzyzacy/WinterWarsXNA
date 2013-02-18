﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WWxna.Code.Game_Objects;
using WWxna.Code.Game_Objects.Structures;

namespace WWxna.Code.Game_Objects
{
	/*	Whenever you make a new collidable that needs to be a different collidable 
	 *	create an id for it where new_class_id = get_new_id()
	 */
/*	static class Collision_ID
	{
		private int cur_max_id = 0;
		
		public int get_new_id()
		{
			return cur_max_id++;
		}

		public int num_collidables()
		{
			return cur_max_id;
		}
	}
	*/
    class Collision_Table
    {
	    private bool get_collided() { return collided;}
 
	    private delegate void func(Collidable x, Collidable y);
	    private List<List<func>> table;

	    private bool collided;

        public Collision_Table()
        {
			table = new List<List<func>>();

	        collided = false;

        }

	    public void handle_collision(Collidable A, Collidable B)
	    {
			SortedDictionary<Type, func> tmp; 
			func fxn;

	//		A.get_id()
	//		fxn = table.
	//		fxn(A, B);
	    }

		

	    // these functions should check to see if the objects are colliding
	    // and then handle the collision if they are
		private void collideSnowballSnowball(Snowball  b1, Snowball  b2)
		{



		}

		private void collidePlayerSnowball(Player  p1, Snowball  b1)
		{	
	  /* 		//if no collision, return
			if (!p1->body.intersects(b1->body) || b1->owner == p1)
				return;

			if (b1->damage_dealt)
				return;


			// // Friendly Fire
			if (p1->get_team() == b1->team)
			{
				if (b1->owner) // not a snowman
					b1->owner->stats.friendly_hit++;	

				if (!b1->owner) // <-comment out for all friendly fire to go through
					return;  // just pass through if thrown by snowman
			}
			// /


			// if the player's dead, don't continue
			if (p1->is_player_KO())
				return;

			//If we want to stop the snowball, move this above friendly fire
			float damage_dealt = b1->deal_damage();  

			p1->get_damaged(damage_dealt);

			Game_Model::get().add_effect(new Effect("explode", b1->center, Vector3f(10,10,10) b1->size.z/4));

			// Drain Resources on death
			if (p1->is_player_KO() )
			{
				b1->team->modify_resources(p1->get_team()->take_resources(500));
			}

			// if snowman shot it, don't add player stats
			if (!b1->owner)
				return;

			// tell the player that threw the ball that he made a hit
			b1->owner->stats.hit++;
			b1->owner->stats.damage_dealt += damage_dealt;

			// he killed the player
			if (p1->is_player_KO() )
			{
				b1->owner->stats.kills++;	

			}
	   * */
		}

		private void collideSnowballPlayer(Snowball  b1, Player  p1)
		{
			collidePlayerSnowball(p1,b1);
		}

		private void collidePlayerPlayer(Player  p1, Player  p2)
		{
	/*		//if no collision, return
			if (!p1->body.intersects(p2->body) || p1 == p2)
				return;

			p1->push_away_from(p2->center, 200);
			p2->push_away_from(p1->center, 200);
	*/	}

		private void collideStructureSnowball(Structure  w1, Snowball  ob2)
		{	
			collideSnowballStructure(ob2, w1);
		}

		private void collidePlayerStructure(Player  ob2, Structure  w1)
		{	
	/*		//Structure player collision resolution

			w1->handle_player_in_range(ob2->myTeam, ob2->body);

			if(!ob2->body.intersects(w1->body))
				return;
			w1->handle_player_collision(ob2);
	*/	}

		private void collideStructurePlayer(Structure  w1, Player  ob2)
		{
			collidePlayerStructure(ob2, w1);
		}

		private void collideSnowballStructure(Snowball  b2, Structure  w1)
		{

	/*		if(Game_Model::get().get_World()->get_tile(w1->get_bottom_center()) == Game_Model::get().get_World()->get_center_Tile())
				return;

			if (!b2->body.intersects(w1->body))
				return;

			if (b2->damage_dealt)
				return;

			if (w1->Status == DESTROYED || b2->team == w1->owner)
				return;

			int damage = b2->deal_damage();

			w1->receive_hit(damage);

			Game_Model::get().get_player(1)->play_sound();
			Game_Model::get().add_effect(new Effect("explode", b2->center, Vector3f(10,10,10) b2->size.z/4));

			if (!b2->owner)  //snowmen should damage other structures
				return;		// but no stats

			b2->owner->stats.hit++;
			b2->owner->stats.damage_dealt += damage;

			if (w1->Status == DESTROYED)
				b2->owner->stats.destroyed++;
	*/	}

		private void collideStructureStructure(Structure a , Structure a3 )
		{
			//WAT. This cannot happen
			// Explode Everything!
		}

	}
}
