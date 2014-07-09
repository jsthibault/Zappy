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
    public enum ItemType
    {
        FOOD = 0,
        LINEMATE,
        DERAUMERE,
        SIBUR,
        MENDIANE,
        PHIRAS,
        THYSTAME
    }

    public class GameScreen : AScreen
    {
        #region FIELDS

        public Map2D Map { get; private set; }

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
            //this.Map.AddCharacter(new Character(this.Map, 0, 0, "Shyro"));
            return base.Initialize();
        }

        public void InitializeMap(Int32 X, Int32 Y)
        {
            this.Camera = new Camera(this.ScreenManagerInstance.GameInstance.GraphicsDevice, Zappy.Width, Zappy.Height);
            this.Map = new Map2D(this.ScreenManagerInstance.GameInstance, X, Y, this.Camera);
            this.Map.Initialize();
            this.Map.OnCursorClick += Map_OnCursorClick;
        }

        /// <summary>
        /// Update the game screen components
        /// </summary>
        public override void Update()
        {
            if (this.Map != null)
            {
                this.Map.Update();
            }
        }

        /// <summary>
        /// Draw the game screen components
        /// </summary>
        public override void Draw()
        {
            if (this.Map != null)
            {
                this.Map.Draw(this.SpriteBatch);
            }
        }

        /// <summary>
        /// Action when the screen changes
        /// </summary>
        public override void OnChangeScreen()
        {
            AudioManager.Instance.Stop();
            AudioManager.Instance["main"].Play();
            this.InterfaceEngine.GetContainer("Panel").GetControl("DisconnectButton").Enabled = false;
            this.InterfaceEngine.GetContainer("Inventory").Visible = false;
            this.InterfaceEngine.GetContainer("Viewer").Visible = false;
            this.InterfaceEngine.GetContainer("LoginWindow").Visible = true;
            this.InterfaceEngine.GetContainer("PlayerList").Visible = false;
            this.InterfaceEngine.GetContainer("Options").Visible = false;
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
                this.RessourcesViewer.MapX = Convert.ToInt32(_map.CursorX);
                this.RessourcesViewer.MapY = Convert.ToInt32(_map.CursorY);
                this.RessourcesViewer.UpdatePlayersLabel();
                this.RessourcesViewer.Visible = true;
            }
        }

        #endregion
    }
}
