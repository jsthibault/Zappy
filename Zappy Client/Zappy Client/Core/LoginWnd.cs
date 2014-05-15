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
            this.X = 200;
            this.Y = 100;
            this.Width = 250;
            this.Height = 150;
            this.Host = new Label(this.Engine, "LabelHost", 10, 25, "Host : ");
            this.Port = new Label(this.Engine, "LabelPort", 10, 50, "Port : ");
            this.AddControl(this.Host);
            this.AddControl(this.Port);
            base.Initialize();
        }

        /// <summary>
        /// Update the custom window
        /// </summary>
        public override void Update()
        {
            base.Update();
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
