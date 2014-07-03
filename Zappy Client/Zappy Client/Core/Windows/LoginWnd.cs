using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;
using Zappy_Client.Core.Windows;

/*--------------------------------------------------------
 * LoginWnd.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 15/05/2014 17:40:33
 * 
 * Notes:
 * This class show the full power of the Interface !
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class LoginWnd : Container
    {
        #region FIELDS

        private Texture2D Background { get; set; }

        private Label Message { get; set; }
        private Label Host { get; set; }
        private Label Port { get; set; }

        private TextBox HostInput { get; set; }
        private TextBox PortInput { get; set; }

        private CheckBox SaveAccount { get; set; }

        private Button Connect { get; set; }
        private Button Leave { get; set; }

        private Zappy Game { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize my own window
        /// </summary>
        /// <param name="engine"></param>
        public LoginWnd(UI engine, Zappy game)
            : base(engine, "LoginWindow")
        {
            this.Game = game;
            this.Initialize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the custom window
        /// </summary>
        public override void Initialize()
        {
            this.Message = new Label(this.Engine, "LabelMessage", 100, 13, "Welcome to Final Zappy !");
            this.AddControl(this.Message);
            this.Background = this.Engine.Content.Load<Texture2D>("Theme//window.png");
            this.Width = this.Background.Width;
            this.Height = this.Background.Height;
            this.X = 150;
            this.Y = 250;
            this.Host = new Label(this.Engine, "LabelHost", 55, 90, "Host : ");
            this.HostInput = new TextBox(this.Engine, "InputHost", 95, 90, 150);
            this.Port = new Label(this.Engine, "LabelPort", 55, 120, "Port : ");
            this.PortInput = new TextBox(this.Engine, "PortInput", 95, 120, 150);
            //this.SaveAccount = new CheckBox(this.Engine, "CheckBoxSaveAccount", 85, 80, "Save configuration", false);
            this.Connect = new Button(this.Engine, "ConnectButton", 52, 160, 110, 0, "Connexion");
            this.Connect.OnClick += Connect_OnClick;
            this.Leave = new Button(this.Engine, "LeaveButton", 185, 160, 110, 0, "Quitter");
            this.Leave.OnClick += Leave_OnClick;
            
            // Add to container
            this.AddControl(this.Host);
            this.AddControl(this.HostInput);
            this.AddControl(this.Port);
            this.AddControl(this.PortInput);
            //this.AddControl(this.SaveAccount);
            this.AddControl(this.Connect);
            this.AddControl(this.Leave);
            base.Initialize();
        }

        /// <summary>
        /// Leave click
        /// </summary>
        /// <param name="sender"></param>
        void Leave_OnClick(object sender)
        {
        }

        /// <summary>
        /// Connect click
        /// </summary>
        /// <param name="sender"></param>
        void Connect_OnClick(object sender)
        {
            (this.Game.InterfaceEngine.GetContainer("Panel").GetControl("DisconnectButton") as Button).Enabled = true;
            this.Game.ScreenManager.SetCurrentScreen("GameScreen");
        }

        /// <summary>
        /// Update the custom window
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the custom window
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Background, this.Rectangle, Color.White);
            base.Draw(spriteBatch);
        }

        #endregion
    }
}
