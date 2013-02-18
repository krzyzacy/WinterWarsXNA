using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using WWxna.Code.Environment;
using WWxna.Code.Game_Objects;
using WWxna.Code.MVC;

namespace WWxna.Code.MVC
{
    abstract class Game_Model : iGame_Model
    {
        protected float timestep;
        public float TimeStep
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
        protected List<Team> teams;
        protected HashSet<Collidable> colliders;

        protected View view;
        protected iWorld world;

        public Game_Model()
        {
            table = new Collision_Table();
            players = new List<Player>();
            teams = new List<Team>();
            colliders = new HashSet<Collidable>();
        }


        public virtual void Update()
        {
            throw new NotImplementedException("Up GM");
        }

        public virtual void draw()
        {
            throw new NotImplementedException("Dr  GM");
        }

        public virtual void start_up(GraphicsDeviceManager graphics_, ContentManager content, Controls[] controllers_)
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
    }
}
