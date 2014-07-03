using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

        private Interface.UI InterfaceEngine { get; set; }

        private Viewer RessourcesViewer { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// GameScreen initialization
        /// </summary>
        public GameScreen(Interface.UI interfaceEngine)
            : base()
        {
            this.InterfaceEngine = interfaceEngine;
            this.RessourcesViewer = this.InterfaceEngine.GetContainer("Viewer") as Viewer;
        }

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
            this.Map.OnCursorClick += Map_OnCursorClick;
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

        /// <summary>
        /// Fired when we click on the map
        /// </summary>
        /// <param name="sender"></param>
        void Map_OnCursorClick(Object sender)
        {
            Map2D _map = sender as Map2D;

            if (this.RessourcesViewer.State != Interface.ControlState.Hover)
            {
                this.RessourcesViewer.Message.Text = "Viewer on [" + _map.CursorX + ", " + _map.CursorY + "]";
                this.RessourcesViewer.Visible = true;
                //MessageBox.Show("X: " + _map.CursorX + "\nY: " + _map.CursorY, "Cursor position");
            }
        }

        #endregion
    }
}
