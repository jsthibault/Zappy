using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * TextBox.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 23/05/2014 15:26:36
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class TextBox : Control
    {
        #region FIELDS

        public Boolean ReadOnly { get; set; }

        private Boolean ShowCursor { get; set; }

        private Int32 CursorPositionX { get; set; }

        private Int64 UpdateCursorTick { get; set; }
        private Double UpdateTextTick { get; set; }

        #endregion

        #region CONSTRUCTORS

        public TextBox(UI engine, String name)
            : base(engine, name)
        {
            this.X = 0;
            this.Y = 0;
            this.Width = 50;
            this.Height = this.Engine.Textures["TextBoxMid"].Height;
            this.Initialize();
        }

        public TextBox(UI engine, String name, Int32 x, Int32 y)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.Width = 50;
            this.Height = this.Engine.Textures["TextBoxMid"].Height;
            this.Initialize();
        }

        public TextBox(UI engine, String name, Int32 x, Int32 y, Int32 width)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = this.Engine.Textures["TextBoxMid"].Height;
            this.Initialize();
        }

        #endregion

        #region METHODS

        public override void Initialize()
        {
            this.Text = "";
            this.UpdateTextTick = 0;
            this.OnKeyDown += TextBox_OnKeyDown;
            this.OnKeyUp += TextBox_OnKeyUp;
            this.OnKeyTaped += TextBox_OnKeyTaped;
            this.CursorPositionX = this.Text.Length;
        }

        void TextBox_OnKeyTaped(object sender, MonoGameKeyboardEventArgs e)
        {
        }

        void TextBox_OnKeyUp(object sender, MonoGameKeyboardEventArgs e)
        {
        }

        void TextBox_OnKeyDown(object sender, MonoGameKeyboardEventArgs e)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (this.Engine.CurrentControl == this)
            {
                this.UpdateCursorTick += gameTime.ElapsedGameTime.Milliseconds;
                if (this.ShowCursor == true && this.UpdateCursorTick >= 400)
                {
                    this.ShowCursor = false;
                    this.UpdateCursorTick = 0;
                }
                else if (this.ShowCursor == false && this.UpdateCursorTick >= 600)
                {
                    this.ShowCursor = true;
                    this.UpdateCursorTick = 0;
                }
                this.UpdateKeyboard(gameTime);
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Engine.Textures["TextBoxLeft"], this.Position, Color.White);
            spriteBatch.Draw(this.Engine.Textures["TextBoxMid"],
                new Rectangle((Int32)this.Position.X + this.Engine.Textures["TextBoxLeft"].Width, (Int32)this.Position.Y, this.Width, this.Height),
                Color.White);
            spriteBatch.Draw(this.Engine.Textures["TextBoxRight"],
                new Vector2(this.Position.X + this.Engine.Textures["TextBoxLeft"].Width + this.Width, this.Position.Y), 
                Color.White);
            if (String.IsNullOrEmpty(this.Text) == false)
            {
                spriteBatch.DrawString(this.Engine.Fonts["ArialBlack"], this.Text, new Vector2(this.Position.X + 3, this.Position.Y), Color.White);
            }
            this.DrawCursor(spriteBatch);
        }

        private void DrawCursor(SpriteBatch spriteBatch)
        {
            if (this.Engine.CurrentControl == this && this.ShowCursor == true) // display cursor
            {
                String _str = null;
                for (Int32 i = 0; i < this.CursorPositionX; i++)
                {
                    _str += this.Text[i];
                }
                Single _cursorPosition = 0;
                if (_str != null)
                {
                    _cursorPosition = this.Engine.Fonts["ArialBlack"].MeasureString(_str).X;
                }
                spriteBatch.Draw(this.Engine.Textures["TextBoxCursor"], 
                    new Vector2(this.Position.X + 5 + _cursorPosition, this.Position.Y + 4), Color.White);
            }
        }

        private void UpdateKeyboard(GameTime gameTime)
        {
            this.UpdateTextTick += gameTime.ElapsedGameTime.Milliseconds;
            if (this.UpdateTextTick >= 100)
            {
                Keys[] _keys = Keyboard.GetState().GetPressedKeys();
                if (_keys.Length > 0)
                {
                    Keys _key = _keys[0];
                    if (Keyboard.GetState().IsKeyDown(_key) == true)
                    {
                        if (_key >= Keys.A && _key <= Keys.Z)
                        {
                            this.Text += _key.ToString();
                            ++this.CursorPositionX;
                            this.UpdateTextTick = 0;
                        }
                        else if ((_key >= Keys.NumPad0 && _key <= Keys.NumPad9) || _key == Keys.Decimal)
                        {
                            this.Text += this.GetNumbers(_key);
                            ++this.CursorPositionX;
                            this.UpdateTextTick = 0;
                        }
                        else if (_key == Keys.Back)
                        {
                            if (this.Text != "")
                            {
                                --this.CursorPositionX;
                                this.Text = this.Text.Remove(this.CursorPositionX, 1);
                                this.UpdateTextTick = 0;
                            }
                        }
                    }
                }
            }
        }

        private String GetNumbers(Keys key)
        {
            switch (key)
            {
                case Keys.NumPad0:
                    return "0";
                case Keys.NumPad1:
                    return "1";
                case Keys.NumPad2:
                    return "2";
                case Keys.NumPad3:
                    return "3";
                case Keys.NumPad4:
                    return "4";
                case Keys.NumPad5:
                    return "5";
                case Keys.NumPad6:
                    return "6";
                case Keys.NumPad7:
                    return "7";
                case Keys.NumPad8:
                    return "8";
                case Keys.NumPad9:
                    return "9";
                case Keys.Decimal:
                    return ".";
                default: return "";
            }
        }

        #endregion
    }
}
