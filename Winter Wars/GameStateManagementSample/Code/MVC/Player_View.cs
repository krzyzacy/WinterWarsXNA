using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using WWxna.Code.Game_Objects;

namespace WWxna.Code.MVC
{
    class Player_View
    {
        public H_Player player;

        public Player_View(H_Player p)
        { player = p; }

        public Camera get_camera(/*Vector2 topLeft, Vector2 bottomRight*/)
        {         
	//        get_Video().set_3d_view(player.get_camera(), std::make_pair(topLeft, bottomRight));
            return player.get_camera();
        }

        public void render_hud(Vector2 topLeft, Vector2 bottomRight)
        { 
        
        }

//	    void render_minimap(Vector2 topLeft, Vector2 bottomRight, std::string avartar);

//	    void render_build(Vector2 topLeft, Vector2 bottomRight);

//	    void render_death(Vector2 topLeft, Vector2 bottomRight);

//	    void render_message(Vector2 topLeft, Vector2 bottomRight, Zeni::String message);

//	    void render_tree_claimed(Vector2 topLeft, Vector2 bottomRight);



    }
}
