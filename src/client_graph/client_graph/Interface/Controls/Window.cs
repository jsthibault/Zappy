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

        public event MonoGameEventHandler OnClose;
        private Rectangle CloseButtonRectangle { get; set; }
        private ControlState CloseButtonState { get; set; }

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
            this.Initialize();
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
            this.Initialize();
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
            this.Initialize();
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
            this.Initialize();
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
            this.Initialize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the Window
        /// </summary>
        public override void Initialize()
        {
            this.CloseButtonState = ControlState.Normal;
            this.CloseButtonRectangle = new Rectangle(this.Rectangle.Right - (this.Engine.Textures["WindowCloseButton"].Width / 2), this.Rectangle.Top + 9,
                            this.Engine.Textures["WindowCloseButton"].Width / 4, this.Engine.Textures["WindowCloseButton"].Height);
            this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 25));
            base.Initialize();
        }

        /// <summary>
        /// Update the Window
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            if (Mouse.GetState().IsInRectangle(this.Rectangle) == true && Mouse.GetState().IsInRectangle(this.Engine.CurrentContainer.Rectangle) == false ||
                this == this.Engine.CurrentContainer)
            {
                this.CloseButtonRectangle = new Rectangle(this.Rectangle.Right - (this.Engine.Textures["WindowCloseButton"].Width / 2), this.Rectangle.Top + 9,
                            this.Engine.Textures["WindowCloseButton"].Width / 4, this.Engine.Textures["WindowCloseButton"].Height);
                if (Mouse.GetState().IsInRectangle(this.CloseButtonRectangle) == true)
                {
                    this.CloseButtonState = ControlState.Hover;
                    if (Mouse.GetState().MouseDown(MouseButton.LeftButton) == true)
                    {
                        this.CloseButtonState = ControlState.Press;
                    }
                    if (Mouse.GetState().MouseClick(MouseButton.LeftButton) == true)
                    {
                        this.OnCloseWindow();
                        return;
                    }
                }
                else
                {
                    this.CloseButtonState = ControlState.Normal;
                }
                this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 25));
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the window
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Color _winColor = Color.White * 0.9f;

            if (this.Enabled == false)
            {
                _winColor = Color.SlateGray; // provisoire
            }
            else if (this != this.Engine.CurrentContainer)
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
                spriteBatch.DrawCenteredText(this.Engine.Fonts["TrebuchetMSBold"], new Rectangle(this.X, this.Y + 2, this.Width, 25), this.Text, Color.FromNonPremultiplied(238, 221, 130, 255));
            }

            this.DrawExitButton(spriteBatch);

            base.Draw(spriteBatch);
        }

        private void DrawExitButton(SpriteBatch spriteBatch)
        {
            if (this.CloseButton == true)
            {
                Rectangle _source = new Microsoft.Xna.Framework.Rectangle(0, 0, 
                    this.Engine.Textures["WindowCloseButton"].Width / 4, this.Engine.Textures["WindowCloseButton"].Height);
                if (this.CloseButtonState == ControlState.Hover)
                {
                    _source.X = this.Engine.Textures["WindowCloseButton"].Width / 4;
                }
                else if (this.CloseButtonState == ControlState.Press)
                {
                    _source.X = this.Engine.Textures["WindowCloseButton"].Width / 2;
                }
                else if (this.Enabled == false)
                {
                    _source.X = (this.Engine.Textures["WindowCloseButton"].Width / 4) * 3;
                }
                spriteBatch.Draw(this.Engine.Textures["WindowCloseButton"], this.CloseButtonRectangle, _source, Color.White);
            }
        }

        #endregion

        #region EVENTS

        public virtual void OnCloseWindow()
        {
            if (this.OnClose != null)
            {
                this.OnClose(this);
            }
            this.Engine.DeleteControl(this.Name);
        }

        #endregion
    }
}
