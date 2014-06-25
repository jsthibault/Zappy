using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Zappy_Client.Interface;
using Zappy_Client.Core;

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
            // Add the Login Window to the InterfaceEngine
            this.InterfaceEngine.AddContainer(this.LoginWindow);

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
