using Microsoft.Xna.Framework;

namespace Shooter
{
    class MainMenuScreen : MenuScreen
    {
        public MainMenuScreen()
            : base("Main Menu")
            {
                // Create our menu entries.
                MenuEntry playGameMenuEntry = new MenuEntry("Play Game");
                MenuEntry optionsMenuEntry = new MenuEntry("Options");
                MenuEntry exitMenuEntry = new MenuEntry("Exit");

                // Hook up menu event handlers.
                playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
                optionsMenuEntry.Selected += OptionsMenuEntrySelected;
                exitMenuEntry.Selected += OnCancel;

                // Add entries to the menu.
                
                MenuEntries.Add(playGameMenuEntry);
                MenuEntries.Add(optionsMenuEntry);
                MenuEntries.Add(exitMenuEntry);
            }

        void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex, new GameplayScreen());
        }


        void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new OptionsScreen(), e.PlayerIndex);
        }

        protected override void OnCancel(PlayerIndex playerIndex)
        {
            const string message = "Voulez-vous quitter le jeu ?";

            MessageBoxScreen confirmExitMessageBox = new MessageBoxScreen(message);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmExitMessageBox, playerIndex);
        }

        void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }
    }
}
