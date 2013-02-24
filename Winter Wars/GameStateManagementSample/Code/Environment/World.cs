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
    public class World : iWorld
    {
        List< List<iTile> > map;
        MVC.View view;
        int map_width;                   // #col
        int map_height;                  // #row
        float tile_size;                 // size of a tile
        int cur_team_count;

        //bool sin_active;

        public World(   MVC.View view_,
		                int width__,
		                int height__,
		                float hex_length__
		        )
        {
            view = view_;
            map = new List< List<iTile> >();
	        map_width = width__;
	        map_height = height__;
	        cur_team_count = 0;

	        tile_size = hex_length__;

	        float tR = (float)Math.Sqrt(3.0f) * tile_size / 2;
	        float tS = tile_size;
	        float tH = tile_size / 2;

            tR *= 2.5f;
            tS *= 2.5f;
            tH *= 2.5f;

            for (int h = 0; h < map_height; h++)
            {
                map.Add(new List<iTile>());
                for (int w = 0; w < map_width; w++)
                {

                    Vector3 center;
                    center.X = w * tR * 2 + tR;
                    if (h % 2 == 1) center.X += tR;

                    center.Z = h * (tH + tS) + tS;
                    center.Y = 0.0f;

                    /*
			        if((Math.Abs(6 - h) + Math.Abs(7 - w)) < 4){
				        center.Z += 0.6 * tile_size;
			        }
			        else if((Math.Abs(6 - h) + Math.Abs(7 - w)) < 7){
				        center.Z += 0.2 * tile_size;
			        }
                    */

                    
                    //center.X = 500.0f;
                    //center.Y = 0.0f;
                    //center.Z = -50.0f;
			        
			        float scale_size = (float)2.0 * tile_size;


			        iTile tmp;
                    if (h == 0 || h == map_height - 1 || w == 0 || w == map_width - 1)
                        tmp = new BoundaryTile(tile_size, center, new Vector3(scale_size, scale_size, scale_size), w, h);
                    else
                        tmp = new IceTile(tile_size, center, new Vector3(scale_size, scale_size, scale_size), w, h);
			
			        map[h].Add(tmp);

			        view.add_renderable(map[h][w].get_renderable());

		        }
	        }
        }


        public iTile get_Tile(Vector3 position){
	        float xr = position.X;
	        float yr = position.Y;

	        if(xr < 0 || yr < 0){
		        return null;
	        }

	        float tR = (float)(Math.Sqrt(3.0f) * tile_size / 2);
	        float tS = tile_size;
	        float tH = tile_size / 2; 

	        // "slice" the map as squares - type A and type B
	        // and adjust the vector index accordingly
	
	        int sec_x = (int)(xr / (2 * tR));
	        int sec_y = (int)(yr / (tS + tH));

	        if((sec_y % 2 == 0 && sec_x >= map_width) || sec_x > map_width || sec_y >= map_height)
		        return null;

	        xr -= sec_x * 2 * tR;
	        yr -= sec_y * (tS + tH);

	        if(sec_y % 2 == 0){ // odd row, section A
		        if(yr >= tH){
				        return map[sec_y][sec_x];
		        }
		        else if(xr >= tR){
			        if(yr <= (Math.Sqrt(3.0f) / 3 ) * (xr - tR) ){
				        if(sec_y != 0)
					        return map[sec_y - 1][sec_x];
				        else
					        return null;
			        }
			        else{
					        return map[sec_y][sec_x];
			        }
		        }
		        else{
			        if(yr <= (-(Math.Sqrt(3.0f) * xr)/3 + tH)){
				        if(sec_y != 0 && sec_x != 0)
					        return map[sec_y - 1][sec_x - 1];
				        else
					        return null;
			        }
			        else{
					        return map[sec_y][sec_x];
			        }
		        }
	        }
	        else{ // even row, section B (sec_y == map_height - 1 == 13)
		        if(xr >= tR){
			        if(yr >= tH){
					        if(sec_x != map_width){
						        return map[sec_y][sec_x];
					        }
					        else
						        return null;
			        }
			        else{
				        if(yr <= (-(Math.Sqrt(3.0f) * (xr - tR))/3 + tH)){
					        if(sec_y != 0 && sec_x != map_width)
						        return map[sec_y - 1][sec_x];
					        else
						        return null;
				        }
				        else{
					        //if(sec_x != map_width)
						        return map[sec_y][sec_x];
					        //else
						        //return NULL;
				        }
			        }
		        }
		        else{
			        if(yr >= tH){
				        if(sec_x != 0)
					        return map[sec_y][sec_x - 1];
				        else
					        return null;
			        }
			        else{
				        if(yr <= (Math.Sqrt(3.0f) / 3 ) * xr ){
					        if(sec_y != 0 && sec_x != map_width)
						        return map[sec_y - 1][sec_x];
					        else
						        return null;
				        }
				        else{
					        if(sec_x != 0)
						        return map[sec_y][sec_x - 1];
					        else
						        return null;
				        }
			        }
		        }
	        }
        }

        public iTile get_Tile(int row, int col){
	        return map[row][col];
        }

        public bool is_adjacent(iTile A, iTile B){
	        int row_A = A.get_row();
	        int row_B = B.get_row();
	        int col_A = A.get_col();
	        int col_B = B.get_col();

	        if(Math.Abs(row_A - row_B) > 1 || Math.Abs(col_A - col_B) > 1)
		        return false;

	        if(row_A % 2 == 0){
		        if(col_B - col_A == 1)
			        return false;
	        }
	
	        if(row_A % 2 == 1){
		        if(col_A - col_B == 1)
			        return false;
	        }
	
	        return true;
        }

        /* haven't tested.. should be working.. */
        public List<iTile> Get_Family(iTile Central){
	        List<iTile> ret = new List<iTile>();

	        if(Central.get_col() != 0)
		        ret.Add(map[Central.get_row()][Central.get_col() - 1]);

	        if(Central.get_col() != map_width - 1)
		        ret.Add(map[Central.get_row()][Central.get_col() + 1]);

	        if(Central.get_row() % 2 == 0){
		        if(Central.get_row() == 0){
			        if(Central.get_col() == 0){
				        ret.Add(map[Central.get_row() + 1][Central.get_col()]);
			        }
			        else{
				        ret.Add(map[Central.get_row() + 1][Central.get_col()]);
				        ret.Add(map[Central.get_row() + 1][Central.get_col() - 1]);
			        }
		        }
		        else if(Central.get_row() == map_height - 1){
			        if(Central.get_col() == 0){
				        ret.Add(map[Central.get_row() - 1][Central.get_col()]);
			        }
			        else{
				        ret.Add(map[Central.get_row() - 1][Central.get_col()]);
				        ret.Add(map[Central.get_row() - 1][Central.get_col() - 1]);
			        }
		        }
		        else{
			        if(Central.get_col() == 0){
				        ret.Add(map[Central.get_row() - 1][Central.get_col()]);
				        ret.Add(map[Central.get_row() + 1][Central.get_col()]);
			        }
			        else{
				        ret.Add(map[Central.get_row() - 1][Central.get_col()]);
				        ret.Add(map[Central.get_row() - 1][Central.get_col() - 1]);
				        ret.Add(map[Central.get_row() + 1][Central.get_col()]);
				        ret.Add(map[Central.get_row() + 1][Central.get_col() - 1]);
			        }
		        }
	        }
	        else{
		        if(Central.get_row() == map_height - 1){
			        if(Central.get_col() == map_width - 1){
				        ret.Add(map[Central.get_row() - 1][Central.get_col()]);
			        }
			        else{
				        ret.Add(map[Central.get_row() - 1][Central.get_col()]);
				        ret.Add(map[Central.get_row() - 1][Central.get_col() + 1]);
			        }
		        }
		        else{
			        if(Central.get_col() == map_width - 1){
				        ret.Add(map[Central.get_row() - 1][Central.get_col()]);
				        ret.Add(map[Central.get_row() + 1][Central.get_col()]);
			        }
			        else{
				        ret.Add(map[Central.get_row() - 1][Central.get_col()]);
				        ret.Add(map[Central.get_row() - 1][Central.get_col() + 1]);
				        ret.Add(map[Central.get_row() + 1][Central.get_col()]);
				        ret.Add(map[Central.get_row() + 1][Central.get_col() + 1]);
			        }
		        }
	        }

	        return ret;
        }


        public iTile get_next_Base_Tile()	{
	        cur_team_count++;
	        switch(cur_team_count)	{
	        case 1:
		        return map[1][1];
	        case 2:
		        return map[map_height - 2][map_width - 2];
	        case 3:
		        return map[map_height - 2][1];
	        case 4:
		        return map[1][map_width - 2];
	        default:
		        return null;
	        }
	
        }

        /*
        public iTile player_is_looking_at(Vector3 player_pos, Vector3 look_Dir)	{
	        //&&& Basic for now, to allow for testing
	        //If the player is "looking" to far away, like level across the board, then
	        //just return the tile next to them in that direction

	        //return get_tile(player_pos);

	
	        if(look_Dir.X >= Math.Math.Sqrt(3.0f) / 2){ // right
		        if(get_tile(player_pos).Col != map_width - 1)
			        return map[get_tile(player_pos)->get_row()][get_tile(player_pos)->get_col() + 1];
		        else
			        return NULL;
	        }
	        else if(look_Dir.x <= - Math.Sqrt(3.0f) / 2){ // left
		        if(get_tile(player_pos)->get_col() != 0)
			        return map[get_tile(player_pos)->get_row()][get_tile(player_pos)->get_col() - 1];
		        else
			        return NULL;
	        }
	        else if((look_Dir.x <= Math.Sqrt(3.0f) / 2 && look_Dir.x >= 0) && look_Dir.y <= 0 ){ // upright
		        if(get_tile(player_pos)->get_row() == 0)
			        return NULL;
		        else if(get_tile(player_pos)->get_row() % 2 == 1){
			        if(get_tile(player_pos)->get_col() == map_width - 1){
				        return NULL;
			        }
			        else{
				        return map[get_tile(player_pos)->get_row() - 1][get_tile(player_pos)->get_col() + 1];
			        }
		        }
		        else
			        return map[get_tile(player_pos)->get_row() - 1][get_tile(player_pos)->get_col()];	
	        }
	        else if((look_Dir.x >= - Math.Sqrt(3.0f) / 2 && look_Dir.x <= 0) && look_Dir.y <= 0 ){ // upleft
		        if(get_tile(player_pos)->get_row() == 0)
			        return NULL;
		        else if(get_tile(player_pos)->get_row() % 2 == 0){
			        if(get_tile(player_pos)->get_col() == 0){
				        return NULL;
			        }
			        else{
				        return map[get_tile(player_pos)->get_row() - 1][get_tile(player_pos)->get_col() - 1];
			        }
		        }
		        else
			        return map[get_tile(player_pos)->get_row() - 1][get_tile(player_pos)->get_col()];
	        }
	        else if((look_Dir.x <= Math.Sqrt(3.0f) / 2 && look_Dir.x >= 0) && look_Dir.y >= 0 ){ // lowerright
		        if(get_tile(player_pos)->get_row() == map_height)
			        return NULL;
		        else if(get_tile(player_pos)->get_row() % 2 == 1){
			        if(get_tile(player_pos)->get_col() == map_width - 1){
				        return NULL;
			        }
			        else{
				        return map[get_tile(player_pos)->get_row() + 1][get_tile(player_pos)->get_col() + 1];
			        }
		        }
		        else
			        return map[get_tile(player_pos)->get_row() + 1][get_tile(player_pos)->get_col()];
			
	        }
	        else if((look_Dir.x >= - Math.Sqrt(3.0f) / 2 && look_Dir.x <= 0) && look_Dir.y >= 0 ){ // lowerleft
		        if(get_tile(player_pos)->get_row() == map_height)
			        return NULL;
		        else if(get_tile(player_pos)->get_row() % 2 == 0){
			        if(get_tile(player_pos)->get_col() == 0){
				        return NULL;
			        }
			        else{
				        return map[get_tile(player_pos)->get_row() + 1][get_tile(player_pos)->get_col() - 1];
			        }
		        }
		        else
			        return map[get_tile(player_pos)->get_row() + 1][get_tile(player_pos)->get_col()];
	        }
	        else
		        return NULL;
	
        }
        */
        
        /*
        void World::raise_tile(Point3f location)	{
	        //Add ownership restrictions to this later
	        Tile* ti = get_tile(location);
	        float delta = Game_Model::get().get_time_step() * Tile_Move_Speed;
	        if(ti->set_height(delta))	{
		        for(int i = 0; i < 4; i++)	{
			        if(get_tile(Game_Model::get().get_player(i)->get_posistion()) == ti)
				        Game_Model::get().get_player(i)->change_z(delta);
		        }
	        }
        }

        void World::lower_tile(Point3f location)	{
	        Tile* ti = get_tile(location);
	        float delta = Game_Model::get().get_time_step() * Tile_Move_Speed;
	        if(ti->set_height(-delta))	{
		        for(int i = 0; i < 4; i++)	{
			        if(get_tile(Game_Model::get().get_player(i)->get_posistion()) == ti)
				        Game_Model::get().get_player(i)->change_z(-delta);
		        }
	        }
        }
        

        float World::get_friction_coeff(Point3f &spot)	{
	        Tile *t = get_tile(spot);
	        switch(t->get_covering())	{
	        case SOFT_SNOW:
	        case HARD_SNOW:
		        return Norml_friction;
	        case ICE:
		        return Ice_friction;
	        default:
		        return Norml_friction;
	        }
        }

        bool World::allowed_to_scoop(Point3f &pos_)	{
	        Tile *t = get_tile(pos_);
	        switch(t->get_covering())	{
	        case SOFT_SNOW:
		        return true;
	        case HARD_SNOW:
	        case ICE:
	        default:
		        return false;
		        break;
	        }
        }
        

        /* returns height of ground at that location
        public float get_ground_height(Vector3 location)
        {
	        return get_tile(location).get_height();

        }

        bool World::is_boundary_tile(Tile* t)	{
	        if(t->get_col() == 0 || t->get_col() == map_width - 1	
		        || t->get_row() == 0 || t->get_row() == map_height - 1)
		        return true;
	        return false;
        }

        void World::Run_Sin_Wave()	{}
        */

    }
}
