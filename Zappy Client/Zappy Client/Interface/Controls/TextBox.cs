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

        #endregion

        #region CONSTRUCTORS

        public TextBox(UI engine, String name)
            : base(engine, name)
        {
            this.X = 0;
            this.Y = 0;
            this.Width = 50;
            this.Height = this.Engine.Textures["TextBoxMid"].Height;
        }

        public TextBox(UI engine, String name, Int32 x, Int32 y)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.Width = 50;
            this.Height = this.Engine.Textures["TextBoxMid"].Height;
        }

        public TextBox(UI engine, String name, Int32 x, Int32 y, Int32 width)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = this.Engine.Textures["TextBoxMid"].Height;
        }

        #endregion

        #region METHODS

        public override void Initialize() { }

        public override void Update()
        {
            if (this.ParentControl == this.Engine.CurrentContainer && this == this.Engine.CurrentControl)
            {
                Keys _key = Keyboard.GetState().GetPressedKeys().First();
                if (Keyboard.GetState().IsKeyTaped(_key) == true)
                {
                    this.Text += _key.ToString();
                }
            }
            base.Update();
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
        }

        #endregion
    }
}
