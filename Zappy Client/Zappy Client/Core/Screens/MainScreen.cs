using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;

/*--------------------------------------------------------
 * MainScreen.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 18/06/2014 15:55:37
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class MainScreen : AScreen
    {
        #region FIELDS

        private Texture2D Background { get; set; }

        private Interface.UI InterfaceEngine { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize the main screen
        /// </summary>
        public MainScreen(Interface.UI interfaceEngine)
            : base()
        {
            this.InterfaceEngine = interfaceEngine;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize function
        /// </summary>
        /// <returns></returns>
        public override Boolean Initialize()
        {
            this.Background = this.ScreenManagerInstance.GameInstance.Content.Load<Texture2D>("Background.png");
            return base.Initialize();
        }

        /// <summary>
        /// Update the MainScreen components
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Draw the MainScreen components
        /// </summary>
        public override void Draw()
        {
            this.SpriteBatch.Begin();
            this.SpriteBatch.Draw(this.Background, Vector2.Zero, Color.White);
            this.SpriteBatch.End();
        }

        /// <summary>
        /// Called when the screen changes
        /// </summary>
        public override void OnChangeScreen()
        {
            this.InterfaceEngine.GetContainer("LoginWindow").Visible = false;
            this.InterfaceEngine.GetContainer("PlayerList").Visible = true;
            this.InterfaceEngine.GetContainer("Inventory").Visible = true;
            //Mouse.GetState().Update(); // UPDATE MOUSE STATES
        }

        #endregion
    }
}
