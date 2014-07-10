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
        public static Zappy Instance = null;
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
        private WndTeamsList TeamsList;
        private WndPlayersList PlayerList;
        private Options OptionsWindow;
        private Panel PanelWindow;
        private Popup PopupWindow;

        /// <summary>
        /// Creates the zappy game instance
        /// </summary>
        public Zappy()
            : base()
        {
            Instance = this;
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Initialize all components
        /// </summary>
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
            Zappy.Instance.Exit();
        }

        /// <summary>
        /// Load all content
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            AudioManager.Instance["main"] = this.Content.Load<Song>("Music//login.wav");
            AudioManager.Instance["game"] = this.Content.Load<Song>("Music//game.wav");
            AudioManager.Instance["main"].Play();
        }

        /// <summary>
        /// Useless ?
        /// </summary>
        protected override void UnloadContent() { }
        
        /// <summary>
        /// Update all components
        /// </summary>
        /// <param name="gameTime"></param>
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

        /// <summary>
        /// Draw all components
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); // Clear screen

            // Draw the current screen
            this.ScreenManager.Draw();

            // Draw the engine controls
            this.InterfaceEngine.Draw();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Initialize window parameters
        /// </summary>
        private void InitializeWindow()
        {
            // Set correct window size
            this.graphics.PreferredBackBufferWidth = Width;
            this.graphics.PreferredBackBufferHeight = Height;
            this.graphics.ApplyChanges();
            this.Window.Title = "Final Zappy";
            this.CenterWindow();

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

            // Create the teams list window
            this.TeamsList = new WndTeamsList(this.InterfaceEngine);
            this.TeamsList.Visible = false;

            // Create the players list window
            this.PlayerList = new WndPlayersList(this.InterfaceEngine);
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

            // Create the player list window
            this.InventoryWindow = new Inventory(this.InterfaceEngine);
            this.InventoryWindow.Visible = false;

            // Add the Login Window to the InterfaceEngine
            this.InterfaceEngine.AddContainer(this.LoginWindow);

            // Add the Teams List Window to the InterfaceEngine
            this.InterfaceEngine.AddContainer(this.TeamsList);

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

        /// <summary>
        /// Center window
        /// </summary>
        private void CenterWindow()
        {
            this.Window.SetPosition(new Point(50, 50));
        }
    }

    public static class GameExtention
    {
        public static void SetPosition(this GameWindow window, Point position)
        {
            OpenTK.GameWindow OTKWindow = GetForm(window);
            if (OTKWindow != null)
            {
                OTKWindow.X = position.X;
                OTKWindow.Y = position.Y;
            }
        }

        public static OpenTK.GameWindow GetForm(this GameWindow gameWindow)
        {
            Type type = typeof(OpenTKGameWindow);
            System.Reflection.FieldInfo field = type.GetField("window", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (field != null)
                return field.GetValue(gameWindow) as OpenTK.GameWindow;
            return null;
        }
    }
}
