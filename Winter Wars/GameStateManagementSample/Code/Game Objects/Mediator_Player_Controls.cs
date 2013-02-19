using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using System.Diagnostics;

using WWxna.Code.MVC;

namespace WWxna.Code.Game_Objects
{
    enum Shoot_State 
    { 
        CHILL, CHARGING, FIRE 
    };

    enum Jump_State
    {
        ON_GROUND, BOOST, FALLING_WITH_STYLE, JET_PACK
    };

    public class Mediator_Player_Controls
    {
        private H_Player p_avatar;
        private Controls c_input;

        public Mediator_Player_Controls(Controls c_, H_Player p_)
        {
            p_avatar = p_;
            c_input = c_;
            //Initialize states here as well
        }

        public void Control_the_player()
        {
            //calc movement, friction handled here
            calculate_movement();

            //handle jumping state
            Handle_Jump_State();

            //handle shooting state
            Handle_Shooting_State();

            //Move Camera??

        }


        private void Handle_Jump_State()
        {

        }

        private void Handle_Shooting_State()
        {
        }

        private void Move_Camera()
        {
            //adjust the camera in the player
        }

        private void calculate_movement()
        {//Old code sets velocity after calculating it so mimic it
            /*OLD PROCESS
             * get camera forward and left, normalize them
             * create temp variable with new velocity
             * Determine input target velocity
             *      Based on control sticks and some constants
             * Force Z independence
             * Get friction, from center - might need to make readable
             * Determine acceleratoin vector based on vector subtraction
             *      subtraction, makes the vectors very small though, but I think they are normalized
             *      
             * Apply friction and scaling factors, 
             * set the players velocity
            */

            /*
            //Up Cross Forward will give right
            Vector3 Forward = p_avatar.P_Camera.Facing;
            Vector3 Left = Vector3.Cross(p_avatar.P_Camera.Up, Forward);

            Forward.Normalize();
            Left.Normalize();

            Vector3 Temp_Vel = new Vector3(p_avatar.Velocity.X, p_avatar.Velocity.Y, p_avatar.Velocity.Z);
            float temp_Zvel = p_avatar.Velocity.Z;

            Vector3 Target_Vel = (Forward * c_input.State.Move.Y) + (Left * c_input.State.Move.X);

            //MAGIC NUMBER, Redo as Standard Speed later
            Target_Vel *= 200;
            //MAGIC NUMBER, Friction not implemented yet
            float friction = 0.2f;

            //Some of the multiplication constants are wrong here

            //Now the vector difference, may need to normalize Temp Velocity?
            Vector3 Net_Accel = Target_Vel - Temp_Vel;
            //Multiply this by speed? Normalization is gonna throw all this shit off
            Net_Accel.Normalize();
            Net_Accel *= 200;

            Temp_Vel *= (1 - friction / 10);
            Temp_Vel += Net_Accel * GM_Proxy.Instance.Time_Step;

            Temp_Vel.Z = temp_Zvel;
            p_avatar.Velocity = Temp_Vel;
            */

            //Simple Movement for framework testing purposes

            if (Math.Abs(c_input.State.Move.X) > 0.5)
                p_avatar.Velocity = new Vector3(0, 0, 1);

            if (Math.Abs(c_input.State.Move.Y) > 0.5)
                p_avatar.Velocity = new Vector3(0, 0, -1);

            Debug.Print("P:" + c_input.which_id + " Vel Z:" + p_avatar.Velocity.Z);
        }


    }
}
