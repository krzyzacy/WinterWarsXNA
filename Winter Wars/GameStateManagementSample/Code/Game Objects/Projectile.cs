using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WWxna.Code.Game_Objects
{
    class Projectile : Moveable
    {
		public override int get_ID()
		{ return ID(); }

		public static new int ID()
		{ return 2; }

    }
}
