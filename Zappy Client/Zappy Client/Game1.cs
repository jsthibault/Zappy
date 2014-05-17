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
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        UI Engine;
        Window win1, win2;

        /// <summary>
        /// Custom Window
        /// </summary>
        LoginWnd LoginWindow;

        Coliseum ColiseumWindow;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.Engine = new UI(this.Content, this.GraphicsDevice, this.graphics.PreferredBackBufferWidth, this.graphics.PreferredBackBufferHeight);

            this.win1 = new Window(this.Engine, "Hey", 20, 20, 300, 250, "Login");
            this.win1.AddControl(new Label(this.Engine, "Label1", 0, 0, "Connexion"));

            this.win2 = new Window(this.Engine, "Hey2", 50, 50, 300, 250, "Other window");

            //this.Engine.AddContainer(this.win1);
            //this.Engine.AddContainer(this.win2);

            this.LoginWindow = new LoginWnd(this.Engine);
            this.ColiseumWindow = new Coliseum(this.Engine);

            this.Engine.AddContainer(this.ColiseumWindow);
            this.Engine.AddContainer(this.LoginWindow);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // Update engine controls
            this.Engine.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.Engine.Draw();

            base.Draw(gameTime);
        }
    }
}
