using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zappy_Client.Interface;

/*--------------------------------------------------------
 * Panel.cs - Panel window
 * 
 * Version: 1.0
 * Author: ouache_s
 * Created: 03/07/2014 13:36:05
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core.Windows
{
    public class Panel : Container
    {

        #region FIELDS

        private Texture2D Background { get; set; }
        private Button Options { get; set; }
        private Button Disconnect { get; set; }
        private Button Quit { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Panel(UI engine)
            : base(engine, "Panel")
        {
            this.Initialize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the Viewer window
        /// </summary>
        public override void Initialize()
        {
            this.Background = this.Engine.Content.Load<Texture2D>("Theme//panel.png");
            this.Width = this.Background.Width;
            this.Height = this.Background.Height;
            this.X = Zappy.Width - this.Width - 10;
            this.Y = Zappy.Height - this.Height - 10;
            this.Options = new Button(this.Engine, "OptionsButton", 32, 35, 100, 0, "Options");
            this.Disconnect = new Button(this.Engine, "DisconnectButton", 32, 70, 100, 0, "Deconnexion");
            this.Quit = new Button(this.Engine, "CloseButton", 32, 105, 100, 0, "Fermer");
            this.Options.OnClick += onClickOptions;
            this.Quit.OnClick += onClickQuit;
            this.Disconnect.OnClick += onClickDisconnect;
            this.Disconnect.Enabled = false;
            this.AddControl(this.Disconnect);
            this.AddControl(this.Options);
            this.AddControl(this.Quit);
            base.Initialize();
        }

        /// <summary>
        /// Update the Viewer window
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the Viewer window
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Background, this.Rectangle, Color.White);
            base.Draw(spriteBatch);
        }

        private void onClickQuit(object sender)
        {
            Zappy.instance.ExitGame();
        }

        private void onClickDisconnect(object sender)
        {
            Zappy.instance.ScreenManager.SetCurrentScreen("MainScreen");
        }

        private void onClickOptions(object sender)
        {
            this.Engine.GetContainer("Options").Visible = true;
        }
        #endregion

    }
}
