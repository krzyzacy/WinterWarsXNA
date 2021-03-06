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
	public class IceTile : Tile
	{
		Structure Building;
		//TEAM_INDEX team;
		int col;
		int row;
		float tile_size;

		public IceTile(float tile_size__,
				Vector3 center__,
				Vector3 scale__,
				int col__,
				int row__
		)
			: base(tile_size__, center__, scale__, col__, row__)
		{
		}

		public IceTile(IceTile rhs)
			: base(rhs)
		{
		}

		public override String get_model_name(){
			return "IceTile";
		}

        public override String get_tile_name()
        {
            return "Ice";
        }
		

	}
}
