using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WWxna.Code.MVC;

namespace WWxna.Code.Game_Objects
{
    class Mediator_Player_Controls
    {
        private Player p;
        private Controls c;

        public Mediator_Player_Controls(Controls c_, Player p_)
        {
            p = p_;
            c = c_;
            //Initialize states here as well
        }

        public void Control_the_player()
        {



        }


    }
}
