using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Window.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 14/05/2014 13:48:16
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class Window : Container
    {
        #region FIELDS

        public Boolean CloseButton { get; set; }
        public Boolean Movable { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a new Window
        /// </summary>
        /// <param name="engine">UI engine pointer</param>
        /// <param name="name">Control name</param>
        public Window(UI engine, String name)
            : base(engine, name)
        {
            this.CloseButton = true;
            this.Movable = true;
        }

        /// <summary>
        /// Initialize a new Window with size and position
        /// </summary>
        /// <param name="engine">UI engine pointer</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Window(UI engine, String name, Int32 x, Int32 y, Int32 width, Int32 height)
            : base(engine, name, x, y, width, height) 
        {
            this.CloseButton = true;
            this.Movable = true;
        }

        /// <summary>
        /// Initialize a new Window with size, position and title
        /// </summary>
        /// <param name="engine">UI Engine pointer</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="text">Window title</param>
        public Window(UI engine, String name, Int32 x, Int32 y, Int32 width, Int32 height, String text)
            : base(engine, name, x, y, width, height)
        {
            this.CloseButton = true;
            this.Movable = true;
            this.Text = text;
        }

        /// <summary>
        /// Initialize a new Window with size, position, title, and set if it can be moved or not
        /// </summary>
        /// <param name="engine">UI Engine pointer</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="text">Window title</param>
        /// <param name="movable">Can be moved or not</param>
        public Window(UI engine, String name, Int32 x, Int32 y, Int32 width, Int32 height, String text, Boolean movable)
            : base(engine, name, x, y, width, height)
        {
            this.CloseButton = true;
            this.Movable = movable;
            this.Text = text;
        }

        /// <summary>
        /// Initialize a new Window with size, position, title, can move, and close button
        /// </summary>
        /// <param name="engine">UI Engine pointer</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="text">Window title</param>
        /// <param name="movable">Can be moved or not</param>
        /// <param name="closeButton">Have close button</param>
        public Window(UI engine, String name, Int32 x, Int32 y, Int32 width, Int32 height, String text, Boolean movable, Boolean closeButton)
            : base(engine, name, x, y, width, height)
        {
            this.CloseButton = closeButton;
            this.Movable = movable;
            this.Text = text;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the Window
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Update the Window
        /// </summary>
        public override void Update()
        {
            if (Mouse.GetState().IsInRectangle(this.Rectangle) == true && Mouse.GetState().IsInRectangle(this.Engine.CurrentWindow.Rectangle) == false ||
                this == this.Engine.CurrentWindow)
            {
                if (Mouse.GetState().MouseDown(MouseButton.LeftButton) == true)
                {
                    if (Mouse.GetState().IsInRectangle(this.Engine.CurrentWindow.Rectangle) == false)
                    {
                        this.Engine.CurrentWindow = this;
                    }
                    if (Mouse.GetState().X >= this.Rectangle.X && Mouse.GetState().X <= this.Rectangle.X + this.Rectangle.Width &&
                            Mouse.GetState().Y >= this.Rectangle.Y && Mouse.GetState().Y <= this.Rectangle.Y + 25)
                    {
                        this.Engine.CurrentMovingWindow = this;
                    }
                }
            }
            base.Update();
        }

        /// <summary>
        /// Draw the window
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Color _winColor = Color.White * 0.9f;

            if (this != this.Engine.CurrentWindow)
            {
                _winColor = Color.White * 0.8f;
            }

            // top
            spriteBatch.Draw(this.Engine.Textures["Window0"], new Rectangle(this.Rectangle.X, this.Rectangle.Y, 16, 16), _winColor);
            spriteBatch.Draw(this.Engine.Textures["Window1"], new Rectangle(Rectangle.X + 16, Rectangle.Y, Rectangle.Width - 32, 16), _winColor);
            spriteBatch.Draw(this.Engine.Textures["Window2"], new Rectangle(Rectangle.Right - 16, Rectangle.Y, 16, 16), _winColor);

            // top mid
            spriteBatch.Draw(this.Engine.Textures["Window3"], new Rectangle(Rectangle.X, Rectangle.Y + 16, 16, 16), _winColor);
            spriteBatch.Draw(this.Engine.Textures["Window4"], new Rectangle(Rectangle.X + 16, Rectangle.Y + 16, Rectangle.Width - 32, 16), _winColor);
            spriteBatch.Draw(this.Engine.Textures["Window5"], new Rectangle(Rectangle.Right - 16, Rectangle.Y + 16, 16, 16), _winColor);
                
            // mid
            spriteBatch.Draw(this.Engine.Textures["Window6"], new Rectangle(Rectangle.X, Rectangle.Y + 32, 16, Rectangle.Height - 48), _winColor);
            spriteBatch.Draw(this.Engine.Textures["Window7"], new Rectangle(Rectangle.X + 16, Rectangle.Y + 32, Rectangle.Width - 32, Rectangle.Height - 48), _winColor);
            spriteBatch.Draw(this.Engine.Textures["Window8"], new Rectangle(Rectangle.Right - 16, Rectangle.Y + 32, 16, Rectangle.Height - 48), _winColor);
                
            // bot
            spriteBatch.Draw(this.Engine.Textures["Window9"], new Rectangle(Rectangle.X, Rectangle.Bottom - 16, 16, 16), _winColor);
            spriteBatch.Draw(this.Engine.Textures["Window10"], new Rectangle(Rectangle.X + 16, Rectangle.Bottom - 16, Rectangle.Width - 32, 16), _winColor);
            spriteBatch.Draw(this.Engine.Textures["Window11"], new Rectangle(Rectangle.Right - 16, Rectangle.Bottom - 16, 16, 16), _winColor);

            if (String.IsNullOrEmpty(this.Text) == false)
            {
            }

            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Process window moves
        /// </summary>
        public void ProcessMoves()
        {
            if (Mouse.GetState().MouseDown(MouseButton.LeftButton) && this.Enabled == true)
            {
                this.X -= Mouse.GetState().GetLastMouseState().X - Mouse.GetState().X;
                this.Y -= Mouse.GetState().GetLastMouseState().Y - Mouse.GetState().Y;
                if (this.X < 0)
                {
                    this.X = 0;
                }
                if (this.X + this.Width > this.Engine.ClientWidth)
                {
                    this.X = this.Engine.ClientWidth - this.Width;
                }
                if (this.Y < 0)
                {
                    this.Y = 0;
                }
                if (this.Y + this.Height > this.Engine.ClientHeight)
                {
                    this.Y = this.Engine.ClientHeight - this.Height;
                }
            }
            else
            {
                this.Engine.CurrentMovingWindow = null;
            }
        }

        #endregion
    }
}
