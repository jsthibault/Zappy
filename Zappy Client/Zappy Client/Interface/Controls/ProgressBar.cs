using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * ProgressBar.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 21/05/2014 08:58:08
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class ProgressBar : Control
    {
        #region FIELDS

        public Int32 Value { get; set; }

        public ProgressBarColor ProgressBarColor
        {
            get
            {
                return this.color;
            }
            set
            {
                this.SetProgressBarColor(value);
                this.color = value;
            }
        }

        private ProgressBarColor color;

        private Texture2D Texture { get; set; }

        #endregion

        #region CONSTRUCTORS

        public ProgressBar(UI engine, String name)
            : base(engine, name)
        {
            this.ProgressBarColor = ProgressBarColor.Blue;
            this.Width = 50;
            this.Height = this.Engine.Textures["ProgressBarBg"].Height;
            this.Value = 0;
        }

        public ProgressBar(UI engine, String name, Int32 x, Int32 y)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.ProgressBarColor = ProgressBarColor.Blue;
            this.Width = 50;
            this.Height = this.Engine.Textures["ProgressBarBg"].Height;
            this.Value = 0;
        }

        public ProgressBar(UI engine, String name, Int32 x, Int32 y, Int32 width)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.ProgressBarColor = ProgressBarColor.Blue;
            this.Width = width;
            this.Height = this.Engine.Textures["ProgressBarBg"].Height;
            this.Value = 0;
        }

        public ProgressBar(UI engine, String name, Int32 x, Int32 y, Int32 width, ProgressBarColor color)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.ProgressBarColor = color;
            this.Width = width;
            this.Height = this.Engine.Textures["ProgressBarBg"].Height;
            this.Value = 0;
        }

        public ProgressBar(UI engine, String name, Int32 x, Int32 y, Int32 width, ProgressBarColor color, Int32 startValue)
            : base(engine, name)
        {
            this.X = x;
            this.Y = y;
            this.ProgressBarColor = color;
            this.Width = width;
            this.Height = this.Engine.Textures["ProgressBarBg"].Height;
            this.Value = startValue;
        }

        #endregion

        #region METHODS

        public override void Initialize() { }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            /* Draw background */
            spriteBatch.Draw(this.Engine.Textures["ProgressBarBg"], this.Position, new Rectangle(0, 0, 5, this.Height), Color.White);
            spriteBatch.Draw(this.Engine.Textures["ProgressBarBg"], 
                new Rectangle((Int32)this.Position.X + 5, (Int32)this.Position.Y, this.Width - 10, this.Height),
                new Rectangle(5, 0, 1, this.Height), Color.White);
            spriteBatch.Draw(this.Engine.Textures["ProgressBarBg"],
                new Rectangle((Int32)this.Position.X + this.Width - 5, (Int32)this.Position.Y, 5, this.Height),
                new Rectangle(this.Engine.Textures["ProgressBarBg"].Width - 5, 0, 5, this.Height), Color.White);
            if (this.Value > 0)
            {
                Int32 _posX = (Int32)this.Position.X + 1;
                Int32 _posY = (Int32)this.Position.Y + 1;
                /* Draw first piece of pgb */
                spriteBatch.Draw(this.Texture, new Vector2(_posX, _posY), new Rectangle(0, 0, 4, this.Height), Color.White);

                /* Draw main */
                Int32 _prct = (this.Width * this.Value) / 100;
                spriteBatch.Draw(this.Texture, 
                    new Rectangle(_posX + 4, _posY, _prct - (4 * 2), this.Height),
                    new Rectangle(4, 0, 1, this.Height), Color.White);

                /* Draw last piece of pgb */
                spriteBatch.Draw(this.Texture, new Rectangle(_posX + _prct - 5, _posY, 4, this.Height),
                    new Rectangle(this.Texture.Width - 4, 0, 4, this.Height), Color.White);
            }
        }

        private void SetProgressBarColor(ProgressBarColor c)
        {
            switch (c)
            {
                case ProgressBarColor.Red: this.Texture = this.Engine.Textures["ProgressBarRed"]; break;
                case ProgressBarColor.Green: this.Texture = this.Engine.Textures["ProgressBarGreen"]; break;
                case ProgressBarColor.Blue: this.Texture = this.Engine.Textures["ProgressBarBlue"]; break;
                default: this.Texture = this.Engine.Textures["ProgressBarBlue"]; break;
            }
        }

        #endregion
    }

    public enum ProgressBarColor
    {
        Red,
        Green,
        Blue
    }
}
