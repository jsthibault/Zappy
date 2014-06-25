using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * CheckBox.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 17/05/2014 12:15:09
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class CheckBox : Control
    {
        #region FIELDS

        public Boolean Checked { get; set; }

        public event MonoGameCheckBoxEventHandler OnCheck;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a basic checkbox
        /// </summary>
        /// <param name="engine">UI engine</param>
        /// <param name="name">Control name</param>
        public CheckBox(UI engine, String name)
            : base(engine, name)
        {
            this.X = 0;
            this.Y = 0;
            this.Checked = false;
        }

        /// <summary>
        /// Initialize a CheckBox with his position
        /// </summary>
        /// <param name="engine">UI engine</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public CheckBox(UI engine, String name, Int32 x, Int32 y)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.Checked = false;
        }

        /// <summary>
        /// Initialize a CheckBox with his position and text
        /// </summary>
        /// <param name="engine">UI engine</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="text">CheckBox text</param>
        public CheckBox(UI engine, String name, Int32 x, Int32 y, String text)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.Checked = false;
            this.Text = text;
        }

        /// <summary>
        /// Initialize a CheckBox with position, Text, and default state
        /// </summary>
        /// <param name="engine">UI engine</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="text">CheckBox text</param>
        /// <param name="check">CheckBox default state</param>
        public CheckBox(UI engine, String name, Int32 x, Int32 y, String text, Boolean check)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.Checked = check;
            this.Text = text;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the checkbox
        /// </summary>
        public override void Initialize()
        {
        }

        /// <summary>
        /// Update the CheckBox
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            this.UpdateCheckBoxSize();
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the CheckBox
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D _checkBoxTexture = this.Engine.Textures["CheckBox"];
            spriteBatch.Draw(_checkBoxTexture, this.Position, this.GetSourceRectangle(), Color.White);

            if (String.IsNullOrEmpty(this.Text) == false)
            {
                spriteBatch.DrawString(this.Engine.Fonts["ArialBlack"],
                    this.Text,
                    new Vector2(this.Position.X + (_checkBoxTexture.Width / 6) + 3, this.Position.Y - 3),
                    Color.White);
            }
        }

        /// <summary>
        /// Get the correct rectangle from the texture
        /// </summary>
        /// <returns></returns>
        private Rectangle GetSourceRectangle()
        {
            Int32 _checkWidth = this.Engine.Textures["CheckBox"].Width / 6;
            Int32 _checkHeight = this.Engine.Textures["CheckBox"].Height;

            if (this.Enabled == false && this.Checked == true)
            {
                return new Rectangle(_checkWidth * 5, 0, _checkWidth, _checkHeight);
            }
            else if (this.Enabled == false && this.Checked == false)
            {
                return new Rectangle(_checkWidth * 4, 0, _checkWidth, _checkHeight);
            }
            else if (this.Checked == true && this.State == ControlState.Normal)
            {
                return new Rectangle(_checkWidth * 3, 0, _checkWidth, _checkHeight);
            }
            else if (this.Checked == true && this.State != ControlState.Normal)
            {
                return new Rectangle(_checkWidth * 2, 0, _checkWidth, _checkHeight);
            }
            else if (this.Checked == false && this.State == ControlState.Normal)
            {
                return new Rectangle(_checkWidth, 0, _checkWidth, _checkHeight);
            }
            else if (this.Checked == false && this.State != ControlState.Normal)
            {
                return new Rectangle(0, 0, _checkWidth, _checkHeight);
            }
            return new Rectangle();
        }

        /// <summary>
        /// Set the CheckBox size with the text length
        /// </summary>
        private void UpdateCheckBoxSize()
        {
            Texture2D _check = this.Engine.Textures["CheckBox"];
            Int32 _textLength = (Int32)this.Engine.Fonts["ArialBlack"].MeasureString(this.Text).X;
            this.Width = (_check.Width / 6) + _textLength;
            this.Height = _check.Height;
        }

        /// <summary>
        /// Process check box states
        /// </summary>
        private void ProcessCheck()
        {
            this.Checked = this.Checked == true ? false : true;
        }

        #endregion

        #region EVENTS

        /// <summary>
        /// On mouse click event
        /// </summary>
        public override void MouseClick()
        {
            this.ProcessCheck();
            base.MouseClick();
        }

        /// <summary>
        /// On check change
        /// </summary>
        public virtual void OnCheckChange()
        {
            if (this.OnCheck != null)
            {
                this.OnCheck(this, new MonoGameCheckBoxEventArgs(this.Checked));
            }
        }

        #endregion
    }
}
