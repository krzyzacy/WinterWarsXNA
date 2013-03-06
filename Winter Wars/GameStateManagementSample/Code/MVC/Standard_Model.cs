﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using WWxna.Code.Game_Objects;
using WWxna.Code.Game_Objects.Structures;
using WWxna.Code.Environment;

namespace WWxna.Code.MVC
{
    //This is the usual model that we have designed previously
    class Standard_Model : Game_Model
    {

        //H_Player johnny;
        //Seen_Object ship;
        //Seen_Object ship1;
        //Seen_Object ship2;

        //private float time_step;
        //public float Time_Step
        //{
        //    get
        //    {
        //        return time_step;
        //    }
        //    set
        //    {
        //        time_step = value;
        //    }
        //}

       
        public Standard_Model() 
            : base()
        {
            
            
        }


		public override void start_up(Game game_, GraphicsDeviceManager graphics_, ContentManager content, Controls[] controllers_)
        {
            //if his continues to cause problems could just put it in play state and have referene
            view = new View(graphics_, content);
            world = new World(view, 10, 10 ,100);
			//world = new HexWorld(view, 5, 100);

            for (int i = 0; i < 4; i++)
            {
                //Player p = new H_Player(controllers_[i], new Vector3(100, 100, 100 + 50*i), new Vector3(50, 50, 50));
				Player p = new H_Player(game_, controllers_[i], get_World().get_next_Base_Tile().get_top_center());
				add_player(p);
            }

			
			add_structure(new Fort(null, world.get_Tile(5,5)));

			view.add_player_view(new Player_View((H_Player)players.ElementAt(0), view.get_graphics(), view.get_content()));
			view.add_player_view(new Player_View((H_Player)players.ElementAt(2), view.get_graphics(), view.get_content()));
			view.add_player_view(new Player_View((H_Player)players.ElementAt(1), view.get_graphics(), view.get_content()));
			view.add_player_view(new Player_View((H_Player)players.ElementAt(3), view.get_graphics(), view.get_content()));
            
        }

		public override void Update()
		{
			foreach (Collidable c in colliders)
			{
				c.Update();
			}

			// check collisions
			foreach (Moveable m in movers)
				foreach (Collidable c in colliders)
					table.handle_collision(m, c);
		}

		public override void draw()
		{
			view.render();
		}

		public override void Load_Content()
		{
			view.load_models();
		}



        public void restart()
        {
            throw new NotImplementedException();
        }

        public void finish()
        {
            throw new NotImplementedException();
        }

        public bool win()
        {
            throw new NotImplementedException();
        }

        public float time_till_win()
        {
            throw new NotImplementedException();
        }

        public void add_effect(Environment.Effect e)
        {
            throw new NotImplementedException();
        }

		public override iWorld get_World()
		{
			return world;
		}

        public void Clean_dead()
        {
            throw new NotImplementedException();
        }
    }
}
