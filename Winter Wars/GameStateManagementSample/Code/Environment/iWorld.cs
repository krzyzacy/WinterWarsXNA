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
    //This interface represents the different types of possible games that will exist.. maybe
    public interface iWorld
    {
        iTile get_Tile(int row, int col);
        iTile get_Tile(Vector3 position);

	    //iTile player_is_looking_at(Vector3 player_pos, Vector3 look_dir);

	    //change input type if you want, or make multiple types
	    //bool is_adjacent(iTile A, iTile B);
	    //bool is_boundary_tile(iTile t);

	    //void raise_tile(Vector3 location);
	    //void lower_tile(Vector3 location);

	    //float get_friction_coeff(Vector3 spot);
	    //bool allowed_to_scoop(Vector3 pos_);

        // LOL I NEVER REALIZE IT WAS IN THE OLD FILE!
	    //void Run_Sin_Wave();
	    //void Start_Sin_Wave();
	
	    /*Returns the six adjacent tiles to Central*/
	    //List<iTile> Get_Family(iTile Central);

	    //Called during set up, gives next Tile that represents the base
	    iTile get_next_Base_Tile();
        //iTile get_center_Tile();
	
	    /* returns height of ground at that location*/
	    //float get_ground_height(Vector3 location);

    }
}