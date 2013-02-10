using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using WWxna;

using WWxna.Code.Environment;
using WWxna.Code.MVC;
using WWxna.Code.Game_Objects;

namespace WWxna
{
  

    
    public class Play_State : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        ContentManager content;
        SpriteBatch spriteBatch;
        private double TimeStep;
        
        //1-4 represents which screen you want to control
        //0 represents god mode/global controls  -- SINE WAVE
        private int ActiveKeyboardPlayer;
        private KeyboardState keyState;
        Controls [] controllers;
        List<Team> teams;

        public Play_State(GraphicsDeviceManager graphics_, ContentManager content_)
        {
            IsFixedTimeStep = false;
            graphics = graphics_;
            content = content_;
                       
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 

        public void Pub_Initialize()
        {
            Initialize();
        }
        protected override void Initialize()
        {
            //graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            controllers = new Controls[5];
            teams = new List<Team>();

            controllers[1] = new Controls(PlayerIndex.One);
            controllers[2] = new Controls(PlayerIndex.Two);
            controllers[3] = new Controls(PlayerIndex.Three);
            controllers[4] = new Controls(PlayerIndex.Four);

            ActiveKeyboardPlayer = 0;

            Standard_Model.Instance.start_up(graphics, content, controllers);
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// 
        /// 
        /// </summary>
        /// 

        float aspectRatio;
        public void Pub_LoadContent()   {
            LoadContent();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;
            Standard_Model.Instance.Load_Content();


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        /// 
        public void Pub_UnloadContent()    {
            UnloadContent();
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        public void Pub_Update(GameTime gameTime)
        {
            Update(gameTime);
        }
        protected override void Update(GameTime gameTime)
        {

            try
            {
                TimeStep = gameTime.ElapsedGameTime.Milliseconds;
                Standard_Model.Instance.Time_Step = (float)TimeStep;
                UpdateInput();

                Standard_Model.Instance.Update();



                // Allows the game to exit
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();

                // TODO: Add your update logic here
                //  modelRotation += (float)gameTime.ElapsedGameTime.TotalMilliseconds *
                //          MathHelper.ToRadians(0.1f);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Handle exception?               
            }

            base.Update(gameTime);

        }

        
        protected void UpdateInput()
        {
            keyState = Keyboard.GetState();
            Check_keyboard_player_switch();

            foreach (Controls con in controllers)
            {
                con.UpdateInput();
            }


            Handle_keyboard_input();

        }

        private void Check_keyboard_player_switch()
        {   //Basically if they hit 1-4, or 0 switch the keyboard controls
            
            if (keyState.IsKeyDown(Keys.D0))
                ActiveKeyboardPlayer = 0;
            else if (keyState.IsKeyDown(Keys.D1))
                ActiveKeyboardPlayer = 1;
            else if (keyState.IsKeyDown(Keys.D2))
                ActiveKeyboardPlayer = 2;
            else if (keyState.IsKeyDown(Keys.D3))
                ActiveKeyboardPlayer = 3;
            else if (keyState.IsKeyDown(Keys.D4))
                ActiveKeyboardPlayer = 4;
        }

        private void Handle_keyboard_input()
        {
            //Check the special stuff first for thing being zero
            //then check the other stuff
            if (ActiveKeyboardPlayer == 0)
            {
                //SINE WAVE
            }
            else
                controllers[ActiveKeyboardPlayer].Update_Input_From_Keyboard(keyState);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 

        public void Pub_Draw(GameTime gameTime)  {
            Draw(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {

            Standard_Model.Instance.draw();

            base.Draw(gameTime);
        }

    }
}
