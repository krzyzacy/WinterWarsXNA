using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using Microsoft.Xna.Framework;
using WWxna.Code.Environment;

namespace WWxna.Code.Game_Objects
{
    
    public class Projectile : Moveable
    {
        //Constructor Assumes Player input for now, will need to add just team%%%%
        public Projectile() : this(null, Globals.Game_Obj_Origin, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Projectile(Vector3 center_) : this(null, center_, Globals.Game_Obj_Size, Globals.Game_Obj_Quat) { }
        public Projectile(Vector3 center_, Vector3 size_) : this(null, center_, size_, Globals.Game_Obj_Quat) { }
        public Projectile(Vector3 center_, Vector3 size_, Quaternion theta_) : this(null, center_, size_, theta_) { }
        public Projectile(Player _player,Vector3 center_, Vector3 size_, Quaternion theta_ )
            : base(center_, size_, theta_)
        {
            damamge_dealt = false;
            damage = size.Length();

            Life_clock = new Stopwatch();
            Life_clock.Start();

            if (_player != null)
            {
                owner = _player;
                my_team = _player.Team;
            }
        }

        private const float size_decrease_rate = 0.90f;
        private static TimeSpan LifeSpan = new TimeSpan(0,0,15);

        //Backing Store and non-property data
        private Boolean damamge_dealt;
        private float damage;
        private Player owner;
        private Team my_team;

        protected Stopwatch Life_clock;

        #region Properties

        public Boolean Dealt_Damage
        {
            get
            {
                return damamge_dealt;
            }
            protected set
            {
                damamge_dealt = value;
            }
        }

        public float Damage
        {
            get
            {
                return damage;
            }
            protected set
            {
                damage = value;
            }
        }

        public Team My_Team
        {
            get
            {
                return my_team;
            }
            protected set
            {
                my_team = value;
            }
        }

        public Player Owner
        {
            get
            {
                return owner;
            }
            protected set
            {
                owner = value;
            }
        }

        #endregion 

		public override int get_ID()
		{ return ID(); }

		public static new int ID()
		{ return 2; }

        public override void Update()
        {
            base.Update();
            if (Dealt_Damage)
                size *= size_decrease_rate;

            if (Life_clock.Elapsed > LifeSpan)
                mark_for_deletion();
        }

        public virtual float deal_damage()
        {
            if (!Dealt_Damage)
            {
                Dealt_Damage = true;
                Velocity = Vector3.Zero;
                perform_contact_effects();
                return damage;
            }
            return 0;
        }

        /// <summary>
        /// Launches the projectile in the direction indicated by the vector
        /// at a determined speed that depends on projectile type;
        /// </summary>
        /// <param name="direction"></param>
        public virtual void Launch_Projectile(Vector3 direction)
        {
            direction.Normalize();
            Velocity = direction * Globals.Launch_Speed;
        }

        public void off_map()
        {
            mark_for_deletion();
        }

        public void hit_tile()
        {
            deal_damage();
        }

        public override void  on_ground()
        {
 	        //base.on_ground();
        }

        public virtual void perform_contact_effects()
        {}

    }
}
