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

        public Vector2 Position { get; set; }

        private Boolean AlwaysPlay { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a new animation
        /// </summary>
        /// <param name="frameLineCount">Number of lines on the animation sprite sheet</param>
        /// <param name="frameColumnCount">Number of columns on the animation sprite sheet</param>
        /// <param name="texture">Animation texture</param>
        /// <param name="animationSpeed">Animation speed</param>
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
            this.AlwaysPlay = false;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Update the animation
        /// </summary>
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
                    this.Playing = this.AlwaysPlay == true ? true : false;
                }
            }
        }

        /// <summary>
        /// Draw the animation
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.Playing == true)
            {
                spriteBatch.Draw(this.Texture, this.Position, new Rectangle((this.FrameColumn) * this.FrameWidth,
                    (this.FrameLine) * this.FrameHeight, this.FrameWidth, this.FrameHeight), Color.White);
            }
        }

        /// <summary>
        /// Play the animation at a position
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="alwaysPlay">Play loop</param>
        public void Play(Int32 x, Int32 y, Boolean alwaysPlay = false)
        {
            if (this.Playing == false)
            {
                this.Playing = true;
                this.AlwaysPlay = alwaysPlay;
                this.Position = new Vector2(x, y);
            }
        }

        #endregion
    }
}
