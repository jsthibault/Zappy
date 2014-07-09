using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zappy_Client.Core._2DEngine
{
    public class Animation
    {
        #region FIELDS

        public Texture2D Texture { get; set; }

        private Int32 FrameLineCount { get; set; }
        private Int32 FrameColumnCount { get; set; }

        private Int32 FrameLine { get; set; }
        private Int32 FrameColumn { get; set; }

        private Int32 FrameWidth { get; set; }
        private Int32 FrameHeight { get; set; }

        public Boolean Playing { get; set; }

        private Int32 Timer { get; set; }

        public Int32 AnimationSpeed { get; set; }

        private Vector2 Position { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Animation(Int32 frameLineCount, Int32 frameColumnCount, Texture2D texture, Int32 animationSpeed)
        {
            this.Texture = texture;
            this.FrameLineCount = frameLineCount;
            this.FrameColumnCount = frameColumnCount;
            this.AnimationSpeed = animationSpeed;
            this.Playing = false;
            this.FrameColumn = 0;
            this.FrameLine = 0;
            this.Timer = 0;
            this.FrameHeight = this.Texture.Height / this.FrameLineCount;
            this.FrameWidth = this.Texture.Width / this.FrameColumnCount;
        }

        #endregion

        #region METHODS

        public void Update()
        {
            if (this.Playing == true)
            {
                ++this.Timer;
                if (this.Timer >= AnimationSpeed)
                {
                    this.Timer = 0;
                    if (this.FrameLine < this.FrameLineCount)
                    {
                        if (this.FrameColumn < this.FrameColumnCount - 1)
                        {
                            ++this.FrameColumn;
                        }
                        else
                        {
                            this.FrameColumn = 0;
                            ++this.FrameLine;
                        }
                    }
                }
                if (this.FrameLine >= this.FrameLineCount)
                {
                    this.FrameLine = 0;
                    this.FrameColumn = 0;
                    this.Playing = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.Playing == true)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(this.Texture, this.Position, new Rectangle((this.FrameColumn) * this.FrameHeight,
                    (this.FrameLine) * this.FrameWidth, this.FrameWidth, this.FrameHeight), Color.White);
                spriteBatch.End();
            }
            else
            {
            }
        }

        public void Play(Int32 x, Int32 y)
        {
            if (this.Playing == false)
            {
                this.Playing = true;
                this.Position = new Vector2(x, y);
            }
        }

        #endregion
    }
}
