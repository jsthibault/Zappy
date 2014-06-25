using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;

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
    public class LoginWnd : Window
    {
        #region FIELDS

        private Label Host { get; set; }
        private Label Port { get; set; }

        private TextBox HostInput { get; set; }
        private TextBox PortInput { get; set; }

        private CheckBox SaveAccount { get; set; }

        private Button Connect { get; set; }
        private Button Leave { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize my own window
        /// </summary>
        /// <param name="engine"></param>
        public LoginWnd(UI engine)
            : base(engine, "LoginWnd1")
        {
            this.Initialize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the custom window
        /// </summary>
        public override void Initialize()
        {
            this.Text = "Connexion au Zappy";
            this.Width = 275;
            this.Height = 170;
            this.X = this.Engine.ClientWidth / 2 - this.Width / 2;
            this.Y = this.Engine.ClientHeight - this.Height - 75;
            this.Host = new Label(this.Engine, "LabelHost", 20, 35, "Host : ");
            this.HostInput = new TextBox(this.Engine, "InputHost", 60, 35, 150);
            this.Port = new Label(this.Engine, "LabelPort", 20, 65, "Port : ");
            this.PortInput = new TextBox(this.Engine, "PortInput", 60, 65, 150);
            //this.SaveAccount = new CheckBox(this.Engine, "CheckBoxSaveAccount", 85, 80, "Save configuration", false);
            this.Connect = new Button(this.Engine, "ConnectButton", 65, 95, 150, 0, "Connexion");
            this.Connect.OnClick += Connect_OnClick;
            this.Leave = new Button(this.Engine, "LeaveButton", 65, 125, 150, 0, "Quitter");
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
            // HERE CHANGE SCREEN TO GAME
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
            base.Draw(spriteBatch);
        }

        #endregion
    }
}
