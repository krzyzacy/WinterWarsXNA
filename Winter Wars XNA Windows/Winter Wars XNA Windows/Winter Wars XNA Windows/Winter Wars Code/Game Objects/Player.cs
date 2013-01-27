using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Winter_Wars_XNA_Windows.Winter_Wars_Code.Environment;
using Microsoft.Xna.Framework;

namespace Winter_Wars_XNA_Windows.Winter_Wars_Code.Game_Objects
{
    

    class Player : Moveable
    {
        //Going to mostly implement it here and then maybe redo it in AI or H

        //Camera?? not totally understood yet

        private Team myTeam;

        private bool mini_open;

        private BoundingSphere body;
        
        //Collision body is a big issue
            
    }

    class H_Player : Player
    {
    }

    class AI_PLayer : Player
    {
    }

}
