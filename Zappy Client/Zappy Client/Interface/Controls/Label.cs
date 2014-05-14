﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Label.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 14/05/2014 19:24:57
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class Label : Control
    {
        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize an empty label
        /// </summary>
        /// <param name="engine">UI engine pointer</param>
        /// <param name="name">Control name</param>
        public Label(UI engine, String name)
            : base(engine, name) { }

        /// <summary>
        /// Initialize a new empty label with his position
        /// </summary>
        /// <param name="engine">UI engine pointer</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public Label(UI engine, String name, Int32 x, Int32 y)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Initialize a new label with text and position
        /// </summary>
        /// <param name="engine">UI engine pointer</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="text">Label text</param>
        public Label(UI engine, String name, Int32 x, Int32 y, String text)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.Text = text;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize label
        /// </summary>
        public override void Initialize() { }

        /// <summary>
        /// Update label
        /// </summary>
        public override void Update()
        {
            base.Update();
        }

        /// <summary>
        /// Draw the label
        /// </summary>
        /// <param name="spriteBatch">Engine spriteBatch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //TODO: load sprite font
            //spriteBatch.DrawString(null, this.Text, this.Position, Color.White);
        }

        #endregion
    }
}
