﻿using System;
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
    public class VoidTile : Seen_Object, iTile
    {

        public VoidTile()
        {
        }

        /* cannot overload '=' ... lol ...
        public static IceTile operator + ( IceTile rhs )
        {
            this.tile_size = rhs.tile_size;
            this.Building = rhs.Building;
            this.center = rhs.center;
            this.size = rhs.size;
            this.col = rhs.col;
            this.row = rhs.row;

            return this;
        }
        */

        public Seen_Object get_renderable()
        {
            return this;
        }

        public int get_col()
        {
            return 0;
        }

        public int get_row()
        {
            return 0;
        }

        public bool has_building()
        {
            return false;
        }

        public float get_height()
        {
            return 0.0f;
        }

        public Vector3 get_top_center()
        {
            return new Vector3(0, 0, 0);
        }

        /*
        public bool set_height(float height__){
            float Max_Tile_Height = Outer_Max_TH;
            int map_h = Game_Model::get().get_World()->get_height();
            int map_w = Game_Model::get().get_World()->get_width();
	
            if(row > 3 && row < map_h - 3 && col > 3  && col < map_w - 3)
                Max_Tile_Height = Inner_Max_TH;


            if((get_height() == Max_Tile_Height && height__ > 0) 
                || (get_height() == Min_Tile_Height && height__ < 0))
                return false;

            center.z += height__;
            if(has_building())	
                Building->change_height(height__);
	
            if(get_height() > Max_Tile_Height)	{
                if(has_building()) Building->change_height(-abs(get_height() - Max_Tile_Height));
                center.z = Max_Tile_Height - tile_size;
            }
            if(get_height() < Min_Tile_Height)	{
                if(has_building()) Building->change_height(abs(Min_Tile_Height - get_height()));
                center.z = Min_Tile_Height - tile_size;
            }
	
            return true;
        }
        */

        /*
        public void set_team(TEAM_INDEX teamid){
            team = teamid;
        }
        void Tile::set_covering(TILE_TYPE coverid){
            covering = coverid;
        }
        */

        public override String get_model_name()
        {
            return "IceTile";
        }

        public String get_tile_name()
        {
            return "Void";
        }

        public Vector3 get_structure_base()
        {
            return new Vector3(0, 0, 0);
        }

        /* leave Strucures alone xD
        public void build_structure(Structure S, Team new_team)	{
            if(new_team)
                team = new_team->get_Team_Index();
            Building = S;
        }
        

        void Tile::destroy_structure()	{
            //Will add more here later, but tile should be interface for interacting with a structure
            if(has_building())
                Building->mark_for_deletion();
            team = NEUTRAL;
            Building = 0;
        }
        */

    }
}