using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WWxna.Code.Game_Objects;


namespace WWxna.Code.MVC
{
    struct Inputs
    {
        public bool jump;
        public bool pack;
        public bool Build;
        public bool tip;
        
        public bool Tile_up;
        public bool Tile_down;
        public bool R_roll;
        public bool L_roll;
        
        public bool mini_map;
        public bool shoot;

        public bool jet_pack_mode;

        public Vector2 Cam;
        public Vector2 Move;

    }

    class Controls
    {
        private Inputs input;
        private PlayerIndex which_id;
        private bool invert = false;
        public bool inverted
        {
            get
            {
                return invert;
            }
            set
            {
                invert = value;
            }
        }

        //Shooting State, Mouse Camera
        public Controls(PlayerIndex PI)
        {
            which_id = PI;
        }

        public void UpdateInput()
        {
            GamePadState current = GamePad.GetState(which_id);
            if (current.IsConnected)
            {
                input.jump = current.Buttons.A == ButtonState.Pressed;
                input.pack = current.Buttons.B == ButtonState.Pressed;
                input.Build = current.Buttons.X == ButtonState.Pressed;
                input.tip = current.Buttons.Y == ButtonState.Pressed;

                input.Tile_up = current.DPad.Up == ButtonState.Pressed;
                input.Tile_down = current.DPad.Down == ButtonState.Pressed;
                input.R_roll = current.Buttons.RightShoulder == ButtonState.Pressed;
                input.L_roll = current.Buttons.LeftShoulder == ButtonState.Pressed;

                input.mini_map = current.Triggers.Left >= 0.9;
                input.shoot = current.Triggers.Right >= 0.8;

                //Sticks vary from -1 to 1 (similar to zeni)
                input.Cam = current.ThumbSticks.Right;
                input.Move = current.ThumbSticks.Left;
                
                //I couldn't resist;
                if (input.R_roll && input.L_roll)
                    input.jet_pack_mode = true;


            }
        }

        public void update_player_actions(Player Tron) { }

    }
}
