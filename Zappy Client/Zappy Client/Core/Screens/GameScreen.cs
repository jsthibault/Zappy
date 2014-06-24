using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Core._2DEngine;

/*--------------------------------------------------------
 * GameScreen.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 19/06/2014 12:41:42
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class GameScreen : AScreen
    {
        #region FIELDS

        private Map2D Map { get; set; }

        private Camera Camera { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// GameScreen initialization
        /// </summary>
        public GameScreen() : base() { }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the GameScreen
        /// </summary>
        /// <returns></returns>
        public override bool Initialize()
        {
            this.Camera = new Camera(this.ScreenManagerInstance.GameInstance.GraphicsDevice, Zappy.Width, Zappy.Height);
            this.Map = new Map2D(this.ScreenManagerInstance.GameInstance, 20, 20, this.Camera);
            this.Map.Initialize();
            return base.Initialize();
        }

        /// <summary>
        /// Update the game screen components
        /// </summary>
        public override void Update()
        {
            this.Map.Update();
        }

        /// <summary>
        /// Draw the game screen components
        /// </summary>
        public override void Draw()
        {
            this.Map.Draw(this.SpriteBatch);
        }

        /// <summary>
        /// Action when the screen changes
        /// </summary>
        public override void OnChangeScreen()
        {
        }

        #endregion
    }
}
