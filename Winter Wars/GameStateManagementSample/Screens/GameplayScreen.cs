#region File Description
//-----------------------------------------------------------------------------
// GameplayScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using CookComputing.XmlRpc;

using WWxna;
#endregion


namespace GameStateManagement
{
    /// <summary>
    /// This screen implements the actual game logic. It is just a
    /// placeholder to get the idea across: you'll probably want to
    /// put some more interesting gameplay in here!
    /// </summary>
    class GameplayScreen : GameScreen
    {
        Play_State my_game;
        


        #region Fields
        
        float pauseAlpha;
        ContentManager content;
        GraphicsDeviceManager graphics;

        #endregion

        #region Initialization

        /// <summary>
        /// Constructor.
        /// </summary>
        public GameplayScreen(GraphicsDeviceManager graphics_, ContentManager content_)
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
            content = content_;
            graphics = graphics_;

            my_game = new Play_State(graphics, content);
            
            
        }

        /// <summary>
        /// Load graphics content for the game.
        /// </summary>
        public override void LoadContent()
        {



            my_game.Pub_Initialize();
            my_game.Pub_LoadContent();


            //if (content == null)
            //    content = new ContentManager(ScreenManager.Game.Services, "Content");

            
         

            // A real game would probably have more content than this sample, so
            // it would take longer to load. We simulate that by delaying for a
            // while, giving you a chance to admire the beautiful loading screen.
      //      Thread.Sleep(200);

            // once the load has finished, we use ResetElapsedTime to tell the game's
            // timing mechanism that we have just finished a very long frame, and that
            // it should not try to catch up.
            ScreenManager.Game.ResetElapsedTime();
        }


        /// <summary>
        /// Unload graphics content used by the game.
        /// </summary>
        public override void UnloadContent()
        {
            my_game.Pub_UnloadContent();
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the state of the game. This method checks the GameScreen.IsActive
        /// property, so the game will stop updating when the pause menu is active,
        /// or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);

            // Gradually fade in or out depending on whether we are covered by the pause screen.
            if (coveredByOtherScreen)
                pauseAlpha = Math.Min(pauseAlpha + 1f / 32, 1);
            else
                pauseAlpha = Math.Max(pauseAlpha - 1f / 32, 0);

            my_game.Pub_Update(gameTime);

           
        }


        /// <summary>
        /// Lets the game respond to player input. Unlike the Update method,
        /// this will only be called when the gameplay screen is active.
        /// </summary>
        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            // Look up inputs for the active player profile.
            int playerIndex = (int)ControllingPlayer.Value;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

            // The game pauses either if the user presses the pause button, or if
            // they unplug the active gamepad. This requires us to keep track of
            // whether a gamepad was ever plugged in, because we don't want to pause
            // on PC if they are playing with a keyboard and have no gamepad at all!
            bool gamePadDisconnected = !gamePadState.IsConnected &&
                                       input.GamePadWasConnected[playerIndex];

            if (input.IsPauseGame(ControllingPlayer) || gamePadDisconnected)
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
        }


        /// <summary>
        /// Draws the gameplay screen.
        /// </summary>

        public override void Draw(GameTime gameTime)
        {

            // This game has a blue background. Why? Because!
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target,
                                               Color.CornflowerBlue, 0, 0);

            my_game.Pub_Draw(gameTime);
          
            // render player
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont gameFont = content.Load<SpriteFont>("gamefont");
            Vector2 playerPosition = new Vector2(200, 200);


            spriteBatch.Begin();

            spriteBatch.DrawString(gameFont, "Move", playerPosition, Color.Green);

            spriteBatch.End();

            // If the game is transitioning on or off, fade it out to black.
            if (TransitionPosition > 0 || pauseAlpha > 0)
            {
                float alpha = MathHelper.Lerp(1f - TransitionAlpha, 1f, pauseAlpha / 2);

                ScreenManager.FadeBackBufferToBlack(alpha);
            }



        }


        #endregion
    }
}

