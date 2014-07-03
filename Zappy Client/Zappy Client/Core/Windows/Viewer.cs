using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;

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
        public Button close { get; set; }
        private ImageBox Circle { get; set; }
        private ImageBox Legend { get; set; }

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
            this.X = 150;
            this.Y = 50;
            this.Circle = new ImageBox(this.Engine, "Circle", this.Engine.Content.Load<Texture2D>("Theme//Viewer//circle.png"), 35, 70);
            this.Legend = new ImageBox(this.Engine, "Legend", this.Engine.Content.Load<Texture2D>("Theme//Viewer//legend.png"), 40, 250);
            this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 37));
            this.Message = new Label(this.Engine, "LabelMessage", 185, 13, "Viewer");
            this.AddControl(this.Circle);
            this.AddControl(this.Legend);

            // Ressources label
            this.Phiras = new Label(this.Engine, "Phiras", 88, 254, "0");
            this.Deraumere = new Label(this.Engine, "Deraumere", 115, 296, "1");
            this.Mendiane = new Label(this.Engine, "Mendiane", 110, 275, "2");
            this.Sibur = new Label(this.Engine, "Sibur", 180, 254, "3");
            this.Thystame = new Label(this.Engine, "Thystame", 203, 275, "4");
            this.Linemate = new Label(this.Engine, "Linemate", 201, 296, "5");
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
        /// Update the Viewer window
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 37));
            //this.Circle.Rec = new Vector2(this.X + 35, this.Y + 70);
            //this.Legend.Rec = new Vector2(this.X + 40, this.Y + 250);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the Viewer window
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Background, this.Rectangle, Color.White);
            spriteBatch.Draw(this.Circle.Texture, this.Circle.Rectangle, Color.White);
            spriteBatch.Draw(this.Legend.Texture, this.Legend.Rectangle, Color.White);
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
