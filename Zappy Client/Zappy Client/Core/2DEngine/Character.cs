using Microsoft.Xna.Framework.Graphics;
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

        private Map2D Map { get; set; }

        private static UInt32 Ids = 0;

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
        /// Update the character
        /// </summary>
        public void Update()
        {
        }

        /// <summary>
        /// Draw the character
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
        }

        /// <summary>
        /// Move the character
        /// </summary>
        /// <param name="direction">Direction</param>
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: break;
                case Direction.Down: break;
                case Direction.Left: break;
                case Direction.Right: break;
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
