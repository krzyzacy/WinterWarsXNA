using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using WWxna.Code.Environment;
using WWxna.Code.Game_Objects;

namespace WWxna.Code.MVC
{
    public sealed class GM_Proxy : iGame_Model
    {
        public float Time_Step 
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
                
        
        private Game_Model GM;

        private GM_Proxy()
        {
            //Initialization Stuff
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
        }

        public void Start_Model(GraphicsDeviceManager graphics_, ContentManager content_, Controls [] controllers_, string model_type_)
        {
            if (model_type_ == "standard")
                GM = new Standard_Model();
            else
                GM = new Standard_Model();  //Since We have nothing else for now

            GM.start_up(graphics_, content_, controllers_);

        }


        public void start_up(GraphicsDeviceManager graphics_, ContentManager content_, Controls [] controllers_)
        {
            Start_Model(graphics_, content_, controllers_, "standard");
        }

        public void Clean_dead()
        {
            throw new NotImplementedException();
        }

        public void Load_Content()
        {
            GM.Load_Content();
        }
    }
}
