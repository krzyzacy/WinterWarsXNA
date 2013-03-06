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
        protected List<Team> teams;
        protected HashSet<Collidable> colliders;
		protected HashSet<Moveable> movers;

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

		public Environment.Team get_team(int i)
		{
			return teams[i];
		}

        public virtual void Update()
        {
            throw new NotImplementedException("Up GM");
        }

        public virtual void draw()
        {
            throw new NotImplementedException("Dr  GM");
        }

        public virtual void start_up(Game game_, GraphicsDeviceManager graphics_, ContentManager content, Controls[] controllers_)
        {
            throw new NotImplementedException("Str  GM");
        }

        public virtual void Clean_dead()
        {
            throw new NotImplementedException("ClDd  GM");
        }


        public virtual void Load_Content()
        {
            throw new NotImplementedException("ld con  GM");
        }

		public virtual iWorld get_World()
		{
			return world;
		}
    }
}
