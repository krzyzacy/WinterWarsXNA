#region File Description
//-----------------------------------------------------------------------------
// OptionsMenuScreen.cs
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
    /// The options screen is brought up over the top of the main menu
    /// screen, and gives the user a chance to configure the game
    /// in various hopefully useful ways.
    /// </summary>
    class OptionsMenuScreen : MenuScreen
    {
        #region Fields

        MenuEntry option1MenuEntry;
        MenuEntry option2MenuEntry;
        MenuEntry option3MenuEntry;
        MenuEntry option4MenuEntry;

        enum Ungulate
        {
            enum1,
            enum2,
            enum3,
        }

        static Ungulate currentUngulate = Ungulate.enum1;

        static string[] languages = { "string1", "string2", "string3" };
        static int currentLanguage = 0;

        static bool frobnicate = true;

        static int elf = 23;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public OptionsMenuScreen()
            : base("Options")
        {
            // Create our menu entries.
            option1MenuEntry = new MenuEntry(string.Empty);
            option2MenuEntry = new MenuEntry(string.Empty);
            option3MenuEntry = new MenuEntry(string.Empty);
            option4MenuEntry = new MenuEntry(string.Empty);

            SetMenuEntryText();

            MenuEntry back = new MenuEntry("Back");

            // Hook up menu event handlers.
            option1MenuEntry.Selected += UngulateMenuEntrySelected;
            option2MenuEntry.Selected += LanguageMenuEntrySelected;
            option3MenuEntry.Selected += FrobnicateMenuEntrySelected;
            option4MenuEntry.Selected += ElfMenuEntrySelected;
            back.Selected += OnCancel;
            
            // Add entries to the menu.
            MenuEntries.Add(option1MenuEntry);
            MenuEntries.Add(option2MenuEntry);
            MenuEntries.Add(option3MenuEntry);
            MenuEntries.Add(option4MenuEntry);
            MenuEntries.Add(back);
        }


        /// <summary>
        /// Fills in the latest values for the options screen menu text.
        /// </summary>
        void SetMenuEntryText()
        {
            option1MenuEntry.Text = "Option1: " + currentUngulate;
            option2MenuEntry.Text = "Option2: " + languages[currentLanguage];
            option3MenuEntry.Text = "Option3: " + (frobnicate ? "on" : "off");
            option4MenuEntry.Text = "Option4: " + elf;
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Ungulate menu entry is selected.
        /// </summary>
        void UngulateMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            currentUngulate++;

            if (currentUngulate > Ungulate.enum3)
                currentUngulate = 0;

            SetMenuEntryText();
        }


        /// <summary>
        /// Event handler for when the Language menu entry is selected.
        /// </summary>
        void LanguageMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            currentLanguage = (currentLanguage + 1) % languages.Length;

            SetMenuEntryText();
        }


        /// <summary>
        /// Event handler for when the Frobnicate menu entry is selected.
        /// </summary>
        void FrobnicateMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            frobnicate = !frobnicate;

            SetMenuEntryText();
        }


        /// <summary>
        /// Event handler for when the Elf menu entry is selected.
        /// </summary>
        void ElfMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            elf++;

            SetMenuEntryText();
        }


        #endregion
    }
}
