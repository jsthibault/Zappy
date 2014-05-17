using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Button.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 15/05/2014 19:57:20
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class Button : Control
    {
        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a basic button
        /// </summary>
        /// <param name="engine">UI engine pointer</param>
        /// <param name="name">Control name</param>
        public Button(UI engine, String name)
            : base(engine, name) { }

        /// <summary>
        /// Initialize a new button with position and size
        /// </summary>
        /// <param name="engine">UI engine pointer</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Button(UI engine, String name, Int32 x, Int32 y, Int32 width, Int32 height)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Initialize a new button with position, size and text
        /// </summary>
        /// <param name="engine">UI engine pointer</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="text">Button text</param>
        public Button(UI engine, String name, Int32 x, Int32 y, Int32 width, Int32 height, String text)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Text = text;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the button
        /// </summary>
        public override void Initialize() { }

        /// <summary>
        /// Update the button
        /// </summary>
        public override void Update()
        {
            base.Update();
        }

        /// <summary>
        /// Draw the button
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle _source;
            Int32 _offset = 0;

            if (this.State == ControlState.Normal)
            {
                _offset = 0;
            }
            else if (this.State == ControlState.Hover)
            {
                _offset = this.Engine.Textures["Button"].Width / 4;
            }
            else if (this.State == ControlState.Press)
            {
                _offset = (this.Engine.Textures["Button"].Width / 4) * 2;
            }
            else
            {
                _offset = (this.Engine.Textures["Button"].Width / 4) * 3;
            }
            _source = new Rectangle(_offset, 0, this.Engine.Textures["Button"].Width / 4, this.Engine.Textures["Button"].Height);
            this.Height = this.Engine.Textures["Button"].Height; // Manual for now

            // Draw left
            spriteBatch.Draw(this.Engine.Textures["Button"], this.Position, new Rectangle(_source.X, _source.Y, 10, _source.Height), Color.White);

            // Draw mid
            spriteBatch.Draw(this.Engine.Textures["Button"],
                new Rectangle((Int32)this.Position.X + 10, (Int32)this.Position.Y, this.Width - 20, _source.Height),
                new Rectangle(_source.X + 10, 0, 10, _source.Height),
                Color.White);

            // Draw right
            spriteBatch.Draw(this.Engine.Textures["Button"],
                new Rectangle((Int32)this.Position.X + this.Width - 10, (Int32)this.Position.Y, 10, _source.Height),
                new Rectangle(_offset + _source.Width - 10, 0, 10, _source.Height),
                Color.White);

            if (String.IsNullOrEmpty(this.Text) == false)
            {
                spriteBatch.DrawCenteredText(this.Engine.Fonts["TrebuchetMSBold"], this.Rectangle, this.Text, Color.Black);
            }
        }

        #endregion
    }
}
