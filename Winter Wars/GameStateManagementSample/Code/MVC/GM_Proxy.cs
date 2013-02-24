using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


using WWxna.Code.Environment;
using WWxna.Code.Game_Objects;

namespace WWxna.Code.MVC
{
    public sealed class GM_Proxy : iGame_Model
    {
        public TimeSpan Time_Step 
        {
            get
            {
                return GM.TimeStep;
            }
            set 
            {
                GM.TimeStep = value;
            }
        }

        private SpriteBatch sprtbtchref;
        private ContentManager content;
        private Dictionary<Point, String> str_test_dic;
                
        
        private Game_Model GM;

        private GM_Proxy()
        {
            //Initialization Stuff
            str_test_dic = new Dictionary<Point,string>();
        }
        private static GM_Proxy instance;
        public static GM_Proxy Instance
        {
            get
            {
                if (instance == null)
                    instance = new GM_Proxy();
                return instance;
            }
        }

        public void Update()
        {
            GM.Update();
        }

        public void draw()
        {
            GM.draw();
            sprtbtchref.Begin();
            foreach (Point k in str_test_dic.Keys)
            {
                SpriteFont gamefnt = content.Load<SpriteFont>("gamefont");
                Vector2 FontOrigin = gamefnt.MeasureString(str_test_dic[k]) / 2;
                //unit_px????
                sprtbtchref.DrawString(gamefnt, str_test_dic[k], new Vector2(k.X, k.Y),
                                           Color.Black, 0, FontOrigin, 1.0f,
                                           SpriteEffects.None, 0.5f);

            }


            sprtbtchref.End();
        }

        public void Start_Model(Game game_, GraphicsDeviceManager graphics_, ContentManager content_, Controls[] controllers_, string model_type_)
        {
            if (model_type_ == "standard")
                GM = new Standard_Model();
            else
                GM = new Standard_Model();  //Since We have nothing else for now

            sprtbtchref = new SpriteBatch(graphics_.GraphicsDevice);
            content = content_;

            GM.start_up(game_, graphics_, content_, controllers_);

        }


        public void start_up(Game game_, GraphicsDeviceManager graphics_, ContentManager content_, Controls[] controllers_)
        {
            Start_Model(game_, graphics_, content_, controllers_, "standard");
        }

        public void add_hud_string(Point p, String in_str)
        {
            if (str_test_dic.ContainsKey(p))
                str_test_dic[p] = in_str;
            else
                str_test_dic.Add(p, in_str);
        }

        public void Clean_dead()
        {
            throw new NotImplementedException();
        }

        public void Load_Content()
        {
            GM.Load_Content();
        }

		public iWorld get_World()
		{
			return GM.get_World();
		}

    }
}
