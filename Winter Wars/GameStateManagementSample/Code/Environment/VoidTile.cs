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
    public class VoidTile : Tile
    {

        public VoidTile() :
			base(0, Vector3.Zero, Vector3.Zero, 0, 0)
        {
        }

        public override String get_model_name()
        {
            return "IceTile";
        }

        public override String get_tile_name()
        {
            return "Void";
        }

    }
}
