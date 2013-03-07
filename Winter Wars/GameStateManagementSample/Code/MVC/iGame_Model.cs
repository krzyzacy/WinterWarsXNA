using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using WWxna.Code.Game_Objects;
using WWxna.Code.Environment;
using WWxna.Code.Game_Objects.Structures;

namespace WWxna.Code.MVC
{

    //Model Accessor Singleton, then abstract base class, then other classes and stuff



    //This interface represents the different types of 
	// possible games that will exist.. maybe
    interface iGame_Model
    { 
		void start_up(Game game_, GraphicsDeviceManager graphics_, ContentManager content, Controls[] controllers_);


        void Update();
        void draw();
        //void restart();
        //void finish();
        //bool win();
        //float time_till_win();

        void Load_Content();
        //Player get_player(PlayerIndex i);
        //Team get_team(int i);
        //World get_World();

        void add_moveable(Moveable m);
        void add_structure(Structure s);
        //void add_effect(Effect e);

        void Clean_dead();

    }
}
