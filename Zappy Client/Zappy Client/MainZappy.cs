using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zappy_Client.Interface;
using Zappy_Client.Core;
using Microsoft.Xna.Framework.Input;

namespace Zappy_Client
{
    public class Zappy : Game
    {
        public const Int32 Width = 1024;
        public const Int32 Height = 728;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public UI InterfaceEngine;
        private LoginWnd LoginWindow;
        private Inventory InventoryWindow;
        private WndPlayerList PlayerList;
        private ScreenManager ScreenManager;

        public Zappy()
            : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = Width;
            this.graphics.PreferredBackBufferHeight = Height;
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize the InterfaceEngine
            this.InterfaceEngine = new UI(this.Content, this.GraphicsDevice, this.graphics.PreferredBackBufferWidth, this.graphics.PreferredBackBufferHeight);
            // Create the Login Window
            this.LoginWindow = new LoginWnd(this.InterfaceEngine);
            // Create the player list window
            this.PlayerList = new WndPlayerList(this.InterfaceEngine);
            // Create the player list window
            this.InventoryWindow = new Inventory(this.InterfaceEngine);
            // Add the Login Window to the InterfaceEngine
            //this.InterfaceEngine.AddContainer(this.LoginWindow);
            // Add the Player List Window to the InterfaceEngine
            //this.InterfaceEngine.AddContainer(this.PlayerList);
            // Add the Player inventory to the InterfaceEngine
            this.InterfaceEngine.AddContainer(this.InventoryWindow);

            // Initialize the ScreenManager
            this.ScreenManager = new ScreenManager(this);
            // Initialize the MainScreen
            this.ScreenManager["MainScreen"] = new MainScreen();
            // Initialize the GameScreen
            this.ScreenManager["GameScreen"] = new GameScreen();
            // Set the Current screen to "GameScreen"
            this.ScreenManager.SetCurrentScreen("GameScreen");

            base.Initialize();
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
