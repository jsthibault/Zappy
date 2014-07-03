using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * ImageBox.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 25/06/2014 15:08:22
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class ImageBox : Control
    {
        #region FIELDS

        public Texture2D Texture { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a new ImageBox
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="name"></param>
        /// <param name="texture"></param>
        public ImageBox(UI engine, String name, Texture2D texture)
            : base(engine, name)
        {
            this.Texture = texture;
            this.State = ControlState.Normal;
        }

        /// <summary>
        /// Creates a new ImageBox
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="name"></param>
        /// <param name="texture"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public ImageBox(UI engine, String name, Texture2D texture, Int32 x, Int32 y)
            : base(engine, name)
        {
            this.Texture = texture;
            this.State = ControlState.Normal;
            this.X = x;
            this.Y = y;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize method
        /// </summary>
        public override void Initialize() { }

        /// <summary>
        /// Update the ImageBox
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the ImageBox
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.Texture != null)
            {
                spriteBatch.Draw(this.Texture, this.Position, Color.White);
            }
        }

        #endregion
    }
}
