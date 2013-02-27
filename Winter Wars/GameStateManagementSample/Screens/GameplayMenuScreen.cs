#region File Description
//-----------------------------------------------------------------------------
// GameplayMenuScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
#endregion

namespace GameStateManagement
{
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    class GameplayMenuScreen : MenuScreen
    {
        #region Initialization


        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public GameplayMenuScreen()
            : base("Winter Wars")
        {
            // Create our menu entries.
            MenuEntry SinglePlayerEntry = new MenuEntry("Single Player");
            MenuEntry MultiPlayerEntry = new MenuEntry("Multi Player");
            MenuEntry exitMenuEntry = new MenuEntry("Main Menu");

            // Hook up menu event handlers.
            SinglePlayerEntry.Selected += SinglePlayerEntrySelected;
            MultiPlayerEntry.Selected += MultiPlayerEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(SinglePlayerEntry);
            MenuEntries.Add(MultiPlayerEntry);
            MenuEntries.Add(exitMenuEntry);
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        void SinglePlayerEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new GameplayScreen(ScreenManager.graphics, ScreenManager.content));
        }


        /// <summary>
        /// Event handler for when the Options menu entry is selected.
        /// </summary>
        void MultiPlayerEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new GameplayScreen(ScreenManager.graphics, ScreenManager.content));
        }


        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            LoadingScreen.Load(ScreenManager, false, null, new BackgroundScreen(),
                                                           new MainMenuScreen());
        }


        #endregion
    }
}
