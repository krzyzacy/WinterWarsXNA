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

using WWxna.Code.Environment;
using WWxna.Code.MVC;
using WWxna.Code.Game_Objects;

namespace WWxna
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Play_State : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private double TimeStep;

        List<Controls> controllers;
        List<Team> teams;

        public Play_State()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            IsFixedTimeStep = false;
            

            controllers = new List<Controls>();
            teams = new List<Team>();

            controllers.Add(new Controls(PlayerIndex.One));
            controllers.Add(new Controls(PlayerIndex.Two));
            controllers.Add(new Controls(PlayerIndex.Three));
            controllers.Add(new Controls(PlayerIndex.Four));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Standard_Model.Instance.start_up(graphics, Content);
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

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            TimeStep = gameTime.ElapsedGameTime.Milliseconds;
            Standard_Model.Instance.Time_Step = TimeStep;
            UpdateInput();

            Standard_Model.Instance.Update();

            

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //  modelRotation += (float)gameTime.ElapsedGameTime.TotalMilliseconds *
            //          MathHelper.ToRadians(0.1f);

            base.Update(gameTime);
        }

        
        protected void UpdateInput()
        {
            foreach (Controls con in controllers)
            {
                con.UpdateInput();
            }




        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Standard_Model.Instance.draw();

            base.Draw(gameTime);
        }
    }
}
