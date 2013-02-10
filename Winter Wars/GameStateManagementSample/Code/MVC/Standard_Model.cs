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
        Collision_Table table;
        List<Player> players;
        List<Team> teams;
        HashSet<Collidable> colliders;

        View view;
        iWorld world;

        H_Player johnny;
        Seen_Object ship;
        Seen_Object ship1;
        Seen_Object ship2;

        private float time_step;
        public float Time_Step
        {
            get
            {
                return time_step;
            }
            set
            {
                time_step = value;
            }
        }

        private static Standard_Model instance;
        private Standard_Model() 
        {
            table = new Collision_Table();
            players = new List<Player>();
            teams = new List<Team>();
            colliders = new HashSet<Collidable>();
            
        }
        public static Standard_Model Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Standard_Model();
                }
                return instance;
            }
        }



        public void Update()
        {
            

            //Obviously this isnt perfect yet, so for now just updates players
            foreach(Player p in players)   {
                p.Update();

            }
        }

        public void draw()
        {
            view.render();
        }

        public void Load_Content()
        {
            view.load_models();
        }

        public void start_up(GraphicsDeviceManager graphics_, ContentManager content, Controls [] controllers_)
        {

            ship = new Seen_Object(new Vector3(-500.0f, 0.0f, -5000.0f), new Vector3(100,100,100));
            ship1 = new Seen_Object(new Vector3(500.0f, 0.0f, -5000.0f), new Vector3(100, 100, 100));
            ship2 = new Seen_Object(new Vector3(0.0f, 500.0f, -5000.0f), new Vector3(100, 100, 100));

            johnny = new H_Player(controllers_[1]);

            //if his continues to cause problems could just put it in play state and have referene
            view = new View(graphics_, content);
            world = new World(view, 10, 10, 100);

            view.add_player_view(new Player_View(johnny, view.get_graphics(), view.get_content()));
            view.add_renderable(ship);
            view.add_renderable(ship1);
            view.add_renderable(ship2);

            

            for (int i = 0; i < 4; i++)
            {
                Player p = new H_Player(controllers_[i+1]);
                players.Add(p);
            }
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

        public Player get_player(Microsoft.Xna.Framework.PlayerIndex i)
        {
            throw new NotImplementedException();
        }

        public Environment.Team get_team(int i)
        {
            throw new NotImplementedException();
        }

        public Environment.World get_World()
        {
            throw new NotImplementedException();
        }

        public void add_player(Player p)
        {
            throw new NotImplementedException();
        }

        public void add_moveable(Moveable m)
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
