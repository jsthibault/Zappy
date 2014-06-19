using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Layer.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 18/06/2014 18:42:54
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class Layer
    {
        #region FIELDS

        private Map2D Map { get; set;}

        public Int32[,] TileMap { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a new Layer
        /// </summary>
        /// <param name="map"></param>
        public Layer(Map2D map)
        {
            this.Map = map;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the layer
        /// </summary>
        public void Initialize()
        {
            this.TileMap = new Int32[this.Map.Width, this.Map.Height];
            for (Int32 i = 0; i < this.Map.Width; ++i)
            {
                for (Int32 j = 0; j < this.Map.Height; ++j)
                {
                    this.TileMap[i, j] = -1;
                }
            }
        }

        /// <summary>
        /// Update the layer components
        /// </summary>
        public void Update() { }

        /// <summary>
        /// Draw the layer
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            for (Int32 i = 0; i < this.Map.Width; ++i)
            {
                for (Int32 j = 0; j < this.Map.Height; ++j)
                {
                    if (this.TileMap[i, j] == 0)
                    {
                        spriteBatch.Draw(this.Map.Water, new Vector2(i * 32, j * 32), Color.White);
                    }
                }
            }
        }

        #endregion
    }
}
