using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zappy_Client.Interface;
using Zappy_Client.Core;
using Microsoft.Xna.Framework.Input;
using Zappy_Client.Core.Windows;
using Microsoft.Xna.Framework.Media;

namespace Zappy_Client
{
    public class Zappy : Game
    {
        public static Zappy instance;
        public const Int32 Width = 1310;
        public const Int32 Height = 930;

        public Int32 TimeUnit;

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
        private Popup PopupWindow;

        public Zappy()
            : base()
        {
            instance = this;
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize window parameters
            this.InitializeWindow();

            // Initialize the interface
            this.InitializeInterface();

            // Initialize the ScreenManager
            this.ScreenManager = new ScreenManager(this);
            // Initialize the MainScreen
            this.ScreenManager["MainScreen"] = new MainScreen(this.InterfaceEngine);
            // Initialize the GameScreen
            this.ScreenManager["GameScreen"] = new GameScreen(this.InterfaceEngine);

            // Creates the network instance
            Network.Instance.Create();

            // Set the Current screen to "GameScreen"
            this.ScreenManager.SetCurrentScreen("GameScreen");
            (this.ScreenManager["GameScreen"] as GameScreen).InitializeMap(20, 20);

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
            AudioManager.Instance["main"] = this.Content.Load<Song>("Music//login.wav");
            AudioManager.Instance["game"] = this.Content.Load<Song>("Music//game.wav");
            AudioManager.Instance["main"].Play();
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            // Update network
            Network.Instance.Update();
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

        private void InitializeWindow()
        {
            // Set correct window size
            this.graphics.PreferredBackBufferWidth = Width;
            this.graphics.PreferredBackBufferHeight = Height;
            this.graphics.ApplyChanges();
            this.Window.Title = "Final Zappy";

            // Set event Exit delegate
            this.Exiting += Zappy_Exiting;
        }

        /// <summary>
        /// Initialize the interface engine
        /// </summary>
        private void InitializeInterface()
        {
            // Initialize the InterfaceEngine
            this.InterfaceEngine = new UI(this.Content, this.GraphicsDevice, this.graphics.PreferredBackBufferWidth, this.graphics.PreferredBackBufferHeight);
            // Create the Login Window
            this.LoginWindow = new LoginWnd(this.InterfaceEngine, this);
            // Create the player list window
            this.PlayerList = new WndPlayerList(this.InterfaceEngine);
            this.PlayerList.Visible = false;
            // Create the popup window
            this.PopupWindow = new Popup(this.InterfaceEngine);
            this.PopupWindow.Visible = false;
            // Create the ressources viewer
            this.RessourcesViewer = new Viewer(this.InterfaceEngine);
            this.RessourcesViewer.Visible = false;
            // Create the ressources viewer
            this.PanelWindow = new Panel(this.InterfaceEngine);
            this.PanelWindow.Visible = true;
            // Create the options window
            this.OptionsWindow = new Options(this.InterfaceEngine);
            this.OptionsWindow.Visible = false;
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
            // Add the Options to the InterfaceEngine
            this.InterfaceEngine.AddContainer(this.OptionsWindow);
            // Add the Popup Window to the InterfaceEngine
            this.InterfaceEngine.AddContainer(this.PopupWindow);
        }
    }
}
