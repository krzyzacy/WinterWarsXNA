using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
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
	    private func[,] table;

	    private bool collided;

        public Collision_Table()
        {
			table = new func[4,4];

			table[Snowball.ID(), Collidable.ID()] = null;

			table[(Snowball.ID()),(Snowball.ID())] = collideSnowballSnowball;

			table[(Snowball.ID()),(Player.ID())] = collideSnowballPlayer;

			table[(Snowball.ID()),(Structure.ID()) ] = collideSnowballStructure;

			
	
			table[(Player.ID()),(Collidable.ID())] = null;

			table[(Player.ID()),(Snowball.ID())] = collidePlayerSnowball;

			table[(Player.ID()),(Player.ID())] = collidePlayerPlayer;

			table[(Player.ID()),(Structure.ID())] = collidePlayerStructure;


				
			table[(Structure.ID()),(Collidable.ID())] = null;

			table[(Structure.ID()),(Player.ID())] = collideStructureSnowball;

			table[(Structure.ID()),(Snowball.ID())] = collideStructurePlayer;

			table[(Structure.ID()),(Structure.ID())] = collideStructureStructure;		

            


	        collided = false;

        }

	    public void handle_collision(Collidable A, Collidable B)
	    {
			table[A.get_ID(), B.get_ID()](A, B);
	    }

		

	    // these functions should check to see if the objects are colliding
	    // and then handle the collision if they are
		private void collideSnowballSnowball(Collidable c1, Collidable c2)
		{
            //new casting technique, returns null if false
            Snowball s1 = c1 as Snowball;
            Snowball s2 = c2 as Snowball;
            //Will Exit if something goes awry (other error checking involves is operator)
            if (s1 == s2 || s1 == null || s2 == null)
                return;

            //No Collision, do nothing
            if (!s1.Body.Intersects(s2.Body))
                return;

            //Will effectively kill the smaller one, both if equal
            if(s2.Damage >= s1.Damage)
                s1.deal_damage();
            if(s1.Damage >= s2.Damage)
                s2.deal_damage();
		}

		private void collidePlayerSnowball(Collidable c1, Collidable c2)
		{
            Player p = c1 as Player;
            Snowball s = c2 as Snowball;

            if (p == null || s == null)
                return;

            

            if (!p.Body.Intersects(s.Body) || s.Owner == p)
                return;

            if (s.Dealt_Damage)
                return;
	
            /*
			// // Friendly Fire
			if (p1->get_team() == b1->team)
			{
				if (b1->owner) // not a snowman
					b1->owner->stats.friendly_hit++;	

				if (!b1->owner) // <-comment out for all friendly fire to go through
					return;  // just pass through if thrown by snowman
			}
			// 
             */

            //if player is knocked out then stop
            if (p.Player_KO)
                return;


            p.receive_damage(s.deal_damage());
            /*

			//If we want to stop the snowball, move this above friendly fire
			float damage_dealt = b1->deal_damage();  

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

		private void collideSnowballPlayer(Collidable c1, Collidable c2)
		{
			collidePlayerSnowball(c1,c2);
		}

		private void collidePlayerPlayer(Collidable c1, Collidable c2)
		{
            Player p1 = c1 as Player;
            Player p2 = c2 as Player;

            if(p1 == p2)
                return;

            //if no collision, return
            if (Vector3.Distance(p1.Position, p2.Position) < 30)
                p1.accelerate(new Vector3(0.1f, 0.1f, 0));            

            if (!p1.Body.Intersects(p2.Body) || p1 == p2)
                return;

            p1.accelerate(new Vector3(0, 500, 0));
	/*		

			p1->push_away_from(p2->center, 200);
			p2->push_away_from(p1->center, 200);
	*/	}

		private void collideStructureSnowball(Collidable c1, Collidable c2)
		{	
			collideSnowballStructure(c1, c2);
		}

		private void collidePlayerStructure(Collidable c1, Collidable c2)
		{	
	/*		//Structure player collision resolution

			w1->handle_player_in_range(ob2->myTeam, ob2->body);

			if(!ob2->body.intersects(w1->body))
				return;
			w1->handle_player_collision(ob2);
	*/	}

		private void collideStructurePlayer(Collidable c1, Collidable c2)
		{
			collidePlayerStructure(c1, c2);
		}

		private void collideSnowballStructure(Collidable c1, Collidable c2)
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

		private void collideStructureStructure(Collidable c1, Collidable c2)
		{
			//WAT. This cannot happen
			// Explode Everything!
		}

	}
}
