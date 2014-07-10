using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Egg.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 10/07/2014 10:47:20
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public enum EggState
    {
        Alive = 0,
        Full,
        Dead,
        Open
    }

    public class Egg
    {
        #region FIELDS

        private Map2D Map { get; set; }

        public String Name { get; private set; }

        public Vector2 Position { get; set; }
        public Int32 X { get { return (Int32)this.Position.X; } }
        public Int32 Y { get { return (Int32)this.Position.Y; } }

        public Character Character { get; set; }

        public EggState State { get; set; }

        public Boolean HasCharacter { get; set; }

        private Int32 Time { get; set; }
        private const Int32 TimeLimit = 175;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a new Egg
        /// </summary>
        /// <param name="map">Map reference</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public Egg(Map2D map, String name, Int32 x, Int32 y)
        {
            this.Map = map;
            this.Name = name;
            this.Position = new Vector2(x, y);
            this.State = EggState.Alive;
            this.HasCharacter = false;
            this.Time = 0;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the egg
        /// </summary>
        public void Initialize() { }

        /// <summary>
        /// Update the egg
        /// </summary>
        public void Update()
        {
            if (this.State == EggState.Dead || this.State == EggState.Open)
            {
                if (this.Time < TimeLimit)
                {
                    ++this.Time;
                }
                else
                {
                    this.Map.RemoveEgg(this);
                }
            }
        }

        /// <summary>
        /// Draw the egg
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (this.State)
            {
                case EggState.Alive: spriteBatch.Draw(this.Map.EggEmpty, new Vector2(this.X * Map2D.Case + this.Map.OffsetX + 3, this.Y * Map2D.Case + this.Map.OffsetY + 1), Color.White); break;
                case EggState.Full: spriteBatch.Draw(this.Map.Egg, new Vector2(this.X * Map2D.Case + this.Map.OffsetX + 3, this.Y * Map2D.Case + this.Map.OffsetY + 1), Color.White); break;
                case EggState.Dead: spriteBatch.Draw(this.Map.EggDead, new Vector2(this.X * Map2D.Case + this.Map.OffsetX + 3, this.Y * Map2D.Case + this.Map.OffsetY + 1), Color.White); break;
                case EggState.Open: spriteBatch.Draw(this.Map.EggOpen, new Vector2(this.X * Map2D.Case + this.Map.OffsetX + 3, this.Y * Map2D.Case + this.Map.OffsetY + 1), Color.White); break;
            }
        }

        #endregion
    }
}
