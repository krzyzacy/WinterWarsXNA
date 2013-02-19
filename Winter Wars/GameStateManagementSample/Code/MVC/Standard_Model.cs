using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using WWxna.Code.Game_Objects;
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



		public override void Update()
		{


			//Obviously this isnt perfect yet, so for now just updates players
			foreach (Player p in players)
			{
				p.Update();
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

		public override void start_up(Game game_, GraphicsDeviceManager graphics_, ContentManager content, Controls[] controllers_)
        {

            //ship = new Seen_Object(new Vector3(-500.0f, 0.0f, -5000.0f), new Vector3(100,100,100));
            //ship1 = new Seen_Object(new Vector3(500.0f, 0.0f, -5000.0f), new Vector3(100, 100, 100));
            //ship2 = new Seen_Object(new Vector3(0.0f, 500.0f, -5000.0f), new Vector3(100, 100, 100));

            //johnny = new H_Player(controllers_[1]);

            //if his continues to cause problems could just put it in play state and have referene
            view = new View(graphics_, content);
            world = new World(view, 10, 10, 100);


            for (int i = 0; i < 4; i++)
            {
                //Player p = new H_Player(controllers_[i], new Vector3(100, 100, 100 + 50*i), new Vector3(50, 50, 50));
				Player p = new H_Player(game_, controllers_[i]);
				add_player(p);
            }

            view.add_player_view(new Player_View((H_Player)players.ElementAt(1), view.get_graphics(), view.get_content()));
            
            //view.add_renderable(ship);
            //view.add_renderable(ship1);
            //view.add_renderable(ship2);

            
            
            
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

		public void add_player(Player p)
		{
			players.Add(p);
			add_moveable(p);
		}

		public void add_moveable(Moveable m)
		{
			movers.Add(m);
			add_collidable(m);
		}

		public void add_collidable(Collidable c)
		{
			colliders.Add(c);
			view.add_renderable(c);
		}

        public Environment.Team get_team(int i)
        {
            throw new NotImplementedException();
        }

        public Environment.World get_World()
        {
            throw new NotImplementedException();
        }

        public void add_structure(Game_Objects.Structures.Structure s)
        {
            throw new NotImplementedException();
        }

        public void add_effect(Environment.Effect e)
        {
            throw new NotImplementedException();
        }

        public void Clean_dead()
        {
            throw new NotImplementedException();
        }
    }
}
