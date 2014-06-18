using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * AScreen.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 18/06/2014 11:46:31
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public abstract class AScreen
    {
        #region FIELDS

        internal ScreenManager ScreenManagerInstance { get; set; }

        internal SpriteBatch SpriteBatch { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize the Screen and his components
        /// </summary>
        public AScreen()
        {

        }

        #endregion

        #region METHODS

        public virtual Boolean Initialize()
        {
            this.SpriteBatch = new SpriteBatch(this.ScreenManagerInstance.GameInstance.GraphicsDevice);
            return true;
        }

        public abstract void Update();
        public abstract void Draw();
        public abstract void OnChangeScreen();

        #endregion
    }
}
