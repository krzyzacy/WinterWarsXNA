using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using WWxna.Code.Game_Objects;
using WWxna.Code.Environment;
using WWxna.Code.Game_Objects.Structures;

namespace WWxna.Code.Environment
{
    //interface for tiles
    public interface iTile
    {
        Seen_Object get_renderable();
        int get_col();
        int get_row();

        Vector3 get_structure_base();
        bool has_building();
        float get_height();

        Vector3 get_top_center();
        
        //void build_structure(Structure buildtype, Team new_color);
	    //void destroy_structure();

        //Structure get_building();

        // what can each tile do? then do something xD
        //void tile_special();

    }
}