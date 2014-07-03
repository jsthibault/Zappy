using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zappy_Client.Interface;
using Zappy_Client.Core;
using Microsoft.Xna.Framework.Input;
using Zappy_Client.Core.Windows;

namespace Zappy_Client
{
    public class Zappy : Game
    {
        public static Zappy instance;
        public const Int32 Width = 1024;
        public const Int32 Height = 728;

        public UI InterfaceEngine;
        public ScreenManager ScreenManager;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private LoginWnd LoginWindow;
        private Inventory InventoryWindow;
        private Viewer RessourcesViewer;
        private WndPlayerList PlayerList;
        private Options OptionsWindow;
        private Panel PanelWindow;

        public Zappy()
            : base()
        {
            instance = this;
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = Width;
            this.graphics.PreferredBackBufferHeight = Height;
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.Exiting += Zappy_Exiting;
            // Initialize the InterfaceEngine
            this.InterfaceEngine = new UI(this.Content, this.GraphicsDevice, this.graphics.PreferredBackBufferWidth, this.graphics.PreferredBackBufferHeight);
            // Create the Login Window
            this.LoginWindow = new LoginWnd(this.InterfaceEngine, this);
            // Create the player list window
            this.PlayerList = new WndPlayerList(this.InterfaceEngine);
            this.PlayerList.Visible = false;
            // Create the ressources viewer
            this.RessourcesViewer = new Viewer(this.InterfaceEngine);
            this.RessourcesViewer.Visible = false;
            // Create the ressources viewer
            this.PanelWindow = new Panel(this.InterfaceEngine);
            this.PanelWindow.Visible = true;
            // Create the options window
            this.OptionsWindow = new Options(this.InterfaceEngine);
            this.OptionsWindow.Visible = false;
            // Create the player list window
            this.InventoryWindow = new Inventory(this.InterfaceEngine);
            this.InventoryWindow.Visible = false;
            // Add the Login Window to the InterfaceEngine
            this.InterfaceEngine.AddContainer(this.LoginWindow);
            // Add the Player List Window to the InterfaceEngine
            this.InterfaceEngine.AddContainer(this.PlayerList);
            // Add the Player inventory to the InterfaceEngine
            this.InterfaceEngine.AddContainer(this.InventoryWindow);
            // Add the ressources viewer to the InterfaceEngine
            this.InterfaceEngine.AddContainer(this.RessourcesViewer);
            // Add the panel to the InterfaceEngine
            this.InterfaceEngine.AddContainer(this.PanelWindow);

            // Initialize the ScreenManager
            this.ScreenManager = new ScreenManager(this);
            // Initialize the MainScreen
            this.ScreenManager["MainScreen"] = new MainScreen(this.InterfaceEngine);
            // Initialize the GameScreen
            this.ScreenManager["GameScreen"] = new GameScreen(this.InterfaceEngine);
            // Set the Current screen to "GameScreen"
            this.ScreenManager.SetCurrentScreen("MainScreen");

            base.Initialize();
        }

        /// <summary>
        /// Delegate called on Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Zappy_Exiting(object sender, EventArgs e)
        {
            this.ExitGame();
        }

        /// <summary>
        /// Function called manualy or automaticaly when game exited
        /// </summary>
        public void ExitGame()
        {
            Zappy.instance.Exit();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            // Update current screen
            this.ScreenManager.Update();
            // Update engine controls
            this.InterfaceEngine.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); // Clear screen

            // Draw the current screen
            this.ScreenManager.Draw();

            // Draw the engine controls
            this.InterfaceEngine.Draw();

            base.Draw(gameTime);
        }
    }
}
