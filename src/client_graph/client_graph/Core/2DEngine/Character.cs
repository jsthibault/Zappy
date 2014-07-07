using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Character.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 24/06/2014 17:31:06
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public class Character
    {
        #region FIELDS

        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public String Name { get; set; }

        public Texture2D Texture { get; set; }

        public Direction Direction { get; set; }

        public Map2D Map { get; set; }

        private static UInt32 Ids = 0;

        /* Animation */
        private Rectangle HitBox;

        private Int32 Timer { get; set; }
        private readonly Int32 AnimationSpeed = 10;
        private readonly Int32 MovingValue = 2;
        private Boolean Animation { get; set; }

        private Int32 FrameColumn { get; set; }
        private Int32 FrameLine { get; set; }

        private Int32 MoveVal { get; set; }
        private Boolean Moving { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a new Character at position 0, 0
        /// </summary>
        /// <param name="map">Map reference</param>
        public Character(Map2D map)
        {
            this.Map = map;
            this.X = 0;
            this.Y = 0;
            this.Name = "Player #" + (++Ids);
        }

        /// <summary>
        /// Creates a new Character with his position
        /// </summary>
        /// <param name="map">Map reference</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public Character(Map2D map, Int32 x, Int32 y)
        {
            this.Map = map;
            this.X = x;
            this.Y = y;
            this.Name = "Player #" + (++Ids);
        }

        /// <summary>
        /// Creates a new Character with his position and Name
        /// </summary>
        /// <param name="map">Map reference</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="name">Player name</param>
        public Character(Map2D map, Int32 x, Int32 y, String name)
        {
            this.Map = map;
            this.X = x;
            this.Y = y;
            this.Name = name;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the character properties
        /// </summary>
        public void Initialize()
        {
            this.HitBox = new Rectangle(this.X * 32, this.Y * 32, 64, 64);
            this.Direction = Direction.Down;
            this.FrameColumn = 2;
            this.FrameLine = 1;
            this.Timer = 0;
            this.Animation = true;
        }

        /// <summary>
        /// Update the character
        /// </summary>
        public void Update()
        {
            if (this.Moving == true)
            {
                switch (this.Direction)
                {
                    case Direction.Up:
                        this.FrameLine = 4;
                        this.HitBox.Y -= this.MovingValue;
                        this.MoveVal += this.MovingValue;
                        if (this.MoveVal > 32)
                        {
                            --this.Y;
                            this.Moving = false;
                        }
                        break;
                    case Direction.Down:
                        this.FrameLine = 1;
                        this.HitBox.Y += this.MovingValue;
                        this.MoveVal += this.MovingValue;
                        if (this.MoveVal > 32)
                        {
                            ++this.Y;
                            this.Moving = false;
                        }
                        break;
                    case Direction.Left:
                        this.FrameLine = 2;
                        this.HitBox.X -= this.MovingValue;
                        this.MoveVal += this.MovingValue;
                        if (this.MoveVal > 32)
                        {
                            --this.X;
                            this.Moving = false;
                        }
                        break;
                    case Direction.Right:
                        this.FrameLine = 3;
                        this.HitBox.X += this.MovingValue;
                        this.MoveVal += this.MovingValue;
                        if (this.MoveVal > 32)
                        {
                            ++this.X;
                            this.Moving = false;
                        }
                        break;
                }
            }
            else
            {
                this.FrameColumn = 2;
                this.Timer = 0;
                this.MoveVal = 0;
            }
            this.Animate();
        }

        /// <summary>
        /// Draw the character
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, new Rectangle(this.Map.OffsetX +  this.HitBox.X, this.Map.OffsetY + this.HitBox.Y, 32, 32),
                new Rectangle((this.FrameColumn - 1) * 32, (this.FrameLine - 1) * 32, 32, 32), 
                Color.White);
        }

        /// <summary>
        /// Move the character
        /// </summary>
        /// <param name="direction">Direction</param>
        public void Move(Direction direction)
        {
            this.Direction = direction;
            this.Moving = true;
            this.MoveVal = 0;
        }

        /// <summary>
        /// Animate the character
        /// </summary>
        public void Animate()
        {
            this.Timer++;
            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                if (this.Animation)
                {
                    this.FrameColumn++;
                    if (this.FrameColumn > 3)
                    {
                        this.FrameColumn = 2;
                        this.Animation = false;
                    }
                }
                else
                {
                    this.FrameColumn--;
                    if (this.FrameColumn < 1)
                    {
                        this.FrameColumn = 2;
                        this.Animation = true;
                    }
                }
            }
        }

        #endregion
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
