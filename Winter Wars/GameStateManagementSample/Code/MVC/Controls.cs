using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WWxna.Code.Game_Objects;


namespace WWxna.Code.MVC
{
    public struct Inputs
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

    public class Controls
    {
        private Inputs input;
        public PlayerIndex which_id;
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

        public Inputs State
        {
            get
            {
                return input;
            }
            set { }
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
                input.jet_pack_mode = (input.R_roll && input.L_roll);
            }
        }


        public void Update_Input_From_Keyboard(KeyboardState keyState)
        {
            input.jump = keyState.IsKeyDown(Keys.LeftShift);
            input.pack = keyState.IsKeyDown(Keys.E);
            input.Build = keyState.IsKeyDown(Keys.B);
            input.tip = keyState.IsKeyDown(Keys.T);

            input.Tile_up = keyState.IsKeyDown(Keys.PageUp);
            input.Tile_down = keyState.IsKeyDown(Keys.PageDown);
            input.R_roll = keyState.IsKeyDown(Keys.N);
            input.L_roll = keyState.IsKeyDown(Keys.V);

            input.mini_map = keyState.IsKeyDown(Keys.M);
            input.shoot = keyState.IsKeyDown(Keys.Space);

            input.Move.X = Convert.ToInt32(keyState.IsKeyDown(Keys.D)) - Convert.ToInt32(keyState.IsKeyDown(Keys.A));
            input.Move.Y = Convert.ToInt32(keyState.IsKeyDown(Keys.W)) - Convert.ToInt32(keyState.IsKeyDown(Keys.S));

            // MouseState MS = Mouse.GetState();
            //So I'm not sure how to figure out the center of the screen
            //But bring this up during view and player view so it wil be figured out.
            // *****%%%
            //input.Cam.X = Mouse.GetState().X - 300;
            //input.Cam.Y = Mouse.GetState().Y - 300;
            //Mouse.SetPosition(300, 300);

            input.Cam.X = Convert.ToInt32(keyState.IsKeyDown(Keys.Right)) - Convert.ToInt32(keyState.IsKeyDown(Keys.Left));
            input.Cam.Y = Convert.ToInt32(keyState.IsKeyDown(Keys.Up)) - Convert.ToInt32(keyState.IsKeyDown(Keys.Down));


        
            

            input.jet_pack_mode = (input.R_roll && input.L_roll);

        }
        public void update_player_actions(Player Tron) { }

    }
}
