using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        ScreenManager screenManager;

        private static FpsCounter _fpsCounter = null;

        private static bool withMusic = true;
        private static bool withSound = true;

        private static int volumeMusic = 20;
        private static int volumeSound = 20;

        public static bool WithMusic
        {
            get { return Game1.withMusic; }
            set { Game1.withMusic = value; }
        }
        public static bool WithSound
        {
            get { return Game1.withSound; }
            set { Game1.withSound = value; }
        }

        public static int VolumeMusic
        {
            get { return Game1.volumeMusic; }
            set { Game1.volumeMusic = value; }
        }
        public static int VolumeSound
        {
            get { return Game1.volumeSound; }
            set { Game1.volumeSound = value; }
        }
        // By preloading any assets used by UI rendering, we avoid framerate glitches
        // when they suddenly need to be loaded in the middle of a menu transition.
        static readonly string[] preloadAssets =
        {
            "gradient",
        };

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Create the screen manager component.
            screenManager = new ScreenManager(this);

            Components.Add(screenManager);

            // Activate the first screens.
            //screenManager.AddScreen(new BackgroundScreen(), null);
            screenManager.AddScreen(new MainMenuScreen(), null);

            // Init the FpsCounter
            _fpsCounter = new FpsCounter(this);
            Components.Add(_fpsCounter);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            foreach (string asset in preloadAssets)
            {
                Content.Load<object>(asset);
            }

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);

            this.Window.Title = FpsCounter.FPS.ToString();

        }

                /// <summary>
        /// The frames per second counter.
        /// </summary>
        public static FpsCounter FpsCounter
        {
            get { return _fpsCounter; }
        }

    }
}
