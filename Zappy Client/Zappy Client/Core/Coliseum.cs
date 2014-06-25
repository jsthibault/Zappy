using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;

/*--------------------------------------------------------
 * Coliseum.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 15/05/2014 17:56:34
 * 
 * Notes:
 * Coliseum for Samy and another test of the full power
 * of the Inteface
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class Coliseum : Container
    {
        #region FIELDS

        private Texture2D Background { get; set; }

        private Label Message { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize the custom Coliseum window
        /// </summary>
        /// <param name="engine"></param>
        public Coliseum(UI engine)
            : base(engine, "ColiWindow")
        {
            this.Initialize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the Coliseum window
        /// </summary>
        public override void Initialize()
        {
            this.Background = this.Engine.Content.Load<Texture2D>("Theme//APP_NEWCOLOMASSAGE.png");
            this.Width = this.Background.Width;
            this.Height = this.Background.Height;
            this.X = 150;
            this.Y = 50;
            this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 37));
            this.Message = new Label(this.Engine, "LabelMessage", 100, 13, "Welcome to the Zappy !");
            this.AddControl(this.Message);
            base.Initialize();
        }

        /// <summary>
        /// Update the Coliseum window
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 37));
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the Coliseum window
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
