using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zappy_Client.Interface;

/*--------------------------------------------------------
 * Options.cs - Options window
 * 
 * Version: 1.0
 * Author: ouache_s
 * Created: 03/07/2014 13:36:05
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core.Windows
{
    public class Options : Container
    {

        #region FIELDS

        private Texture2D Background { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Options(UI engine)
            : base(engine, "Options")
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
            this.Background = this.Engine.Content.Load<Texture2D>("Theme//APP_NEWCOLOMASSAGE.png");
            this.Width = this.Background.Width;
            this.Height = this.Background.Height;
            this.X = 150;
            this.Y = 50;
            this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 37));
            base.Initialize();
        }

        /// <summary>
        /// Update the Viewer window
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 37));
            base.Update(gameTime);
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

        #endregion

    }
}
