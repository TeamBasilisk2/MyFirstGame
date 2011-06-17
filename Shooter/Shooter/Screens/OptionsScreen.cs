using Microsoft.Xna.Framework;

namespace Shooter
{
    class OptionsScreen : MenuScreen
    {
        MenuEntry MusicMenuEntry;
        MenuEntry SoundMenuEntry;

        MenuEntry VolumeMusicMenuEntry;
        MenuEntry VolumeSoundMenuEntry;

        static bool Music = true;
        static bool Sound = true;

        static int VolumeMusic = 20;
        static int VolumeSound = 20;

        /// <summary>
        /// Constructor.
        /// </summary>
        public OptionsScreen()
            : base("Options")
        {
            // Create our menu entries.
            MusicMenuEntry = new MenuEntry(string.Empty);
            SoundMenuEntry = new MenuEntry(string.Empty);


            VolumeMusicMenuEntry = new MenuEntry(string.Empty);
            VolumeSoundMenuEntry = new MenuEntry(string.Empty);

            SetMenuEntryText();

            MenuEntry back = new MenuEntry("Back");

            // Hook up menu event handlers.
            MusicMenuEntry.Selected += MusicMenuEntrySelected;
            SoundMenuEntry.Selected += SoundMenuEntrySelected;

            VolumeMusicMenuEntry.Left += VolumeMusicMenuEntryLeft;
            VolumeMusicMenuEntry.Right += VolumeMusicMenuEntryRight;

            VolumeSoundMenuEntry.Left += VolumeSoundMenuEntryLeft;
            VolumeSoundMenuEntry.Right += VolumeSoundMenuEntryRight;

            back.Selected += OnCancel;
            
            // Add entries to the menu.
            MenuEntries.Add(MusicMenuEntry);
            MenuEntries.Add(SoundMenuEntry);

            MenuEntries.Add(VolumeMusicMenuEntry);
            MenuEntries.Add(VolumeSoundMenuEntry);

            MenuEntries.Add(back);
        }

        /// <summary>
        /// Fills in the latest values for the options screen menu text.
        /// </summary>
        void SetMenuEntryText()
        {
            MusicMenuEntry.Text = "Musique : " + (Music ? "on" : "off");
            SoundMenuEntry.Text = "Son : " + (Sound ? "on" : "off");
            VolumeMusicMenuEntry.Text = "Volume Musique : " + VolumeMusic;
            VolumeSoundMenuEntry.Text = "Volume Son : " + VolumeSound;
        }

        void MusicMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            Music = !Music;
            Game1.WithMusic = Music;

            SetMenuEntryText();
        }

        void SoundMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            Sound = !Sound;
            Game1.WithSound = Sound;
            SetMenuEntryText();
        }

        void VolumeSoundMenuEntryLeft(object sender, PlayerIndexEventArgs e)
        {
            VolumeSound -= 5;
            if (VolumeSound < 0) VolumeSound = 0;
            Game1.VolumeSound = VolumeSound;
            SetMenuEntryText();
        }
        void VolumeSoundMenuEntryRight(object sender, PlayerIndexEventArgs e)
        {
            VolumeSound += 5;
            if (VolumeSound > 100) VolumeSound = 100;
            Game1.VolumeSound = VolumeSound;
            SetMenuEntryText();
        }

        void VolumeMusicMenuEntryLeft(object sender, PlayerIndexEventArgs e)
        {
            VolumeMusic -= 5;
            if (VolumeMusic < 0) VolumeMusic = 0;
            Game1.VolumeMusic = VolumeMusic;
            SetMenuEntryText();
        }
        void VolumeMusicMenuEntryRight(object sender, PlayerIndexEventArgs e)
        {
            VolumeMusic += 5;
            if (VolumeMusic > 100) VolumeMusic = 100;
            Game1.VolumeMusic = VolumeMusic;
            SetMenuEntryText();
        }
    }
}
