using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using WWxna.Code.Environment;

namespace WWxna.Code.Game_Objects.Structures
{
	class Base : Healing_Pool
	{
		public Base(Team team, iTile tile_) :
			base(team, tile_)
		{
			Status = Structure_State_e.BUILT;
		}

	}
}
