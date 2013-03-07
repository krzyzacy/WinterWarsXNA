using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using Microsoft.Xna.Framework;
using WWxna.Code.Environment;

namespace WWxna.Code.Game_Objects
{
    public class Snowball : Projectile
    {
        public Snowball(Player _player, Vector3 center_, Vector3 size_)
            : base(center_, size_, Globals.Game_Obj_Quat)
        {
            // max - min / max_siz -4  * (size.z - 4) + min
            Damage = ((Globals.max_snowball_damage - Globals.min_snowball_damage) /
                      (Globals.Max_projectile_size - 4)) * (size.Z - 4) + Globals.min_snowball_damage;
            
            Owner = _player;
            My_Team = _player.Team;
            melt_clock = new Stopwatch();
        }

        public Snowball(Team _team, Vector3 center_, Vector3 size_)
            : base(center_, size_, Globals.Game_Obj_Quat)
        {
            // max - min / max_siz -4  * (size.z - 4) + min
            Damage = ((Globals.max_snowball_damage - Globals.min_snowball_damage) /
                      (Globals.Max_projectile_size - 4)) * (size.Z - 4) + Globals.min_snowball_damage;

            Owner = null;
            My_Team = _team;
            melt_clock = new Stopwatch();
        }

        private static TimeSpan Melting_Time = new TimeSpan(0, 0, 3);

        private Stopwatch melt_clock;

        public override void Update()
        {
            if (melt_clock.Elapsed > Melting_Time)
                mark_for_deletion();

            base.Update();
        }

        public override float deal_damage()
        {
            if (!Dealt_Damage)
                melt_clock.Start();

            return base.deal_damage();
        }

    }
}
