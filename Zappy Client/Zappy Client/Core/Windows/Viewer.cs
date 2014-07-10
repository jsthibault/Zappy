using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;
using Zappy_Client.Core._2DEngine;

/*--------------------------------------------------------
 * Viewer.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 15/05/2014 17:56:34
 * 
 * Notes:
 * Viewer for Samy and another test of the full power
 * of the Inteface
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class Viewer : Container
    {
        #region FIELDS

        private Texture2D Background { get; set; }
        public Label Message { get; set; }
        public Label Phiras { get; set; }
        public Label Sibur { get; set; }
        public Label Mendiane { get; set; }
        public Label Thystame { get; set; }
        public Label Deraumere { get; set; }
        public Label Linemate { get; set; }
        private Label Players { get; set; }
        public Button close { get; set; }
        private ImageBox Circle { get; set; }
        private ImageBox Legend { get; set; }
        public Int32 MapX { get; set; }
        public Int32 MapY { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize the custom Viewer window
        /// </summary>
        /// <param name="engine"></param>
        public Viewer(UI engine)
            : base(engine, "Viewer")
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
            close = new Button(this.Engine, "CloseButton", 344, 320, 100, 0, "Fermer");
            close.OnClick += this.onClickClose;
            this.Background = this.Engine.Content.Load<Texture2D>("Theme//viewer.png");
            this.Width = this.Background.Width;
            this.Height = this.Background.Height;
            this.X = Zappy.Width - this.Background.Width;
            this.Y = 200;
            this.Circle = new ImageBox(this.Engine, "Circle", this.Engine.Content.Load<Texture2D>("Theme//Viewer//circle.png"), 35, 70);
            this.Legend = new ImageBox(this.Engine, "Legend", this.Engine.Content.Load<Texture2D>("Theme//Viewer//legend.png"), 40, 250);
            this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 37));
            this.Message = new Label(this.Engine, "LabelMessage", 185, 13, "Viewer");
            this.Players = new Label(this.Engine, "LabelPlayers", 255, 65, "");
            this.AddControl(this.Circle);
            this.AddControl(this.Legend);
            this.AddControl(this.Players);

            // Ressources label
            this.Phiras = new Label(this.Engine, "Phiras", 88, 254, "0");
            this.Deraumere = new Label(this.Engine, "Deraumere", 115, 296, "0");
            this.Mendiane = new Label(this.Engine, "Mendiane", 110, 275, "0");
            this.Sibur = new Label(this.Engine, "Sibur", 180, 254, "0");
            this.Thystame = new Label(this.Engine, "Thystame", 203, 275, "0");
            this.Linemate = new Label(this.Engine, "Linemate", 201, 296, "0");
            this.AddControl(this.Phiras);
            this.AddControl(this.Sibur);
            this.AddControl(this.Mendiane);
            this.AddControl(this.Thystame);
            this.AddControl(this.Deraumere);
            this.AddControl(this.Linemate);
            this.AddControl(this.Message);
            this.AddControl(this.close);
            base.Initialize();
        }

        /// <summary>
        /// Clear all items of the object
        /// </summary>
        public override void Clear()
        {
            this.Linemate.Text = "0";
            this.Deraumere.Text = "0";
            this.Sibur.Text = "0";
            this.Mendiane.Text = "0";
            this.Phiras.Text = "0";
            this.Thystame.Text = "0";
            this.Players.Text = "";
        }

        /// <summary>
        /// Update the Viewer window
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            this.UpdatePlayersLabel();
            this.UpdateFramesContent();
            this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 37));
            base.Update(gameTime);
        }

        /// <summary>
        /// Update players's Label of players on the selected position
        /// </summary>
        public void UpdatePlayersLabel()
        {
            GameScreen Screen = Zappy.Instance.ScreenManager["GameScreen"] as GameScreen;

           this.Players.Text = "";
           foreach (Team team in (Zappy.Instance.ScreenManager["GameScreen"] as GameScreen).Map.Teams.Values)
           {
               foreach (Character character in team.Characters)
               {
                   if (character.X == this.MapX && character.Y == this.MapY)
                   {
                       this.Players.Text += character.Id.ToString();
                   }
               }
           }
        }

        public void UpdateFramesContent()
        {
            GameScreen Screen = Zappy.Instance.ScreenManager["GameScreen"] as GameScreen;

            foreach (FrameContent frame in Screen.Map.Frames)
            {
                if (frame.X == this.MapX && frame.Y == this.MapY)
                {
                    this.Linemate.Text = frame.GetItemValue(ItemType.LINEMATE).ToString();
                    this.Deraumere.Text = frame.GetItemValue(ItemType.DERAUMERE).ToString();
                    this.Sibur.Text = frame.GetItemValue(ItemType.SIBUR).ToString();
                    this.Mendiane.Text = frame.GetItemValue(ItemType.MENDIANE).ToString();
                    this.Phiras.Text = frame.GetItemValue(ItemType.PHIRAS).ToString();
                    this.Thystame.Text = frame.GetItemValue(ItemType.THYSTAME).ToString();
                }
            }
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

        /// <summary>
        /// Close event of close button
        /// </summary>
        /// <param name="sender"></param>
        private void onClickClose(object sender)
        {
            this.Visible = false;
        }

        #endregion
    }
}
