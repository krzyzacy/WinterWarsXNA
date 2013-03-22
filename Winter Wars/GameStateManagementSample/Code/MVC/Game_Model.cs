using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using WWxna.Code.Environment;
using WWxna.Code.Game_Objects;
using WWxna.Code.Game_Objects.Structures;
using WWxna.Code.MVC;


namespace WWxna.Code.MVC
{
    abstract class Game_Model : iGame_Model
    {
        protected TimeSpan timestep;
        public TimeSpan TimeStep
        {
            get 
			{
                return timestep;
            }
			
			set
			{
                timestep = value;
            }
        }

        protected Collision_Table table;

		protected List<Player> players;
		protected List<Structure> structures;
        protected HashSet<Collidable> colliders;
		protected HashSet<Moveable> movers;

        protected List<Team> teams;

        protected View view;
        protected iWorld world;

        public Game_Model()
        {
            table = new Collision_Table();
			players = new List<Player>();
			structures = new List<Structure>();
            teams = new List<Team>();
            colliders = new HashSet<Collidable>();
			movers = new HashSet<Moveable>();
        }

		public virtual void Load_Content()
		{
			view.load_models();
		}

		public virtual void Update()
		{
			foreach (Collidable c in colliders)
			{
				c.Update();
			}

			// check collisions
			foreach (Moveable m in movers)
				foreach (Collidable c in colliders)
					table.handle_collision(m, c);

            Clean_dead();
		}

        #region Add and Remove

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

		public void add_structure(Structure s)
		{
			structures.Add(s);
			add_collidable(s);
		}

        public void remove_collidable(Collidable c)
        {
            if (c == null)
                return;
            colliders.Remove(c);
        }

        public void remove_moveable(Moveable m)
        {
            if (m == null)
                return;
            movers.Remove(m);
        }

        public void remove_player(Player p)
        {
            if (p == null)
                return;
            players.Remove(p);
        }

        public void remove_structure(Structure s)
        {
            if (s == null)
                return;
            structures.Remove(s);
        }

        #endregion

        public Environment.Team get_team(int i)
		{
			return teams[i];
		}

        public virtual void draw()
        {
			view.render();
        }

        public virtual void start_up(Game game_, GraphicsDeviceManager graphics_, ContentManager content, Controls[] controllers_)
        {
        }

        /// <summary>
        /// Goes through the list of collidables (which should contain everything
        /// that can die) and removes it if it has been marked for deletion
        /// </summary>
        public virtual void Clean_dead()
        {
            //%%%%% I have not actually found a way to test this. Possible memory leak
            foreach (Collidable col in colliders.Reverse())
            {
                if (!col.is_alive())
                {
                    //This form of casting will return null if the cast is invalid
                    Structure _strut = col as Structure;
                    Moveable _mov = col as Moveable;
                    Player _play = col as Player; 

                    //This cast will throw exception if invalid, so don't use it
                    //players.Remove((Player)col);
                    remove_player(_play);
                    remove_moveable(_mov);
                    remove_structure(_strut);
                    remove_collidable(col);

                    view.remove_renderable(col);
                }
            }
        }

        public virtual void Remove_From_All(Collidable victim)
        {
            Player p = victim as Player;
            //if(!null) remove each type;

        }

		public virtual iWorld get_World()
		{
			return world;
		}

    }
}
