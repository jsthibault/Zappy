using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Map.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 18/06/2014 18:34:48
 * 
 * Notes:
 * Map2D is my own implementation of maps and objects
 * It contains :
 * - LayerManager (Add, Get, Delete)
 * - ObjectManager (Add, Get, Delete)
 * - CharacterManager (Add, Get, Delete)
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class Map2D
    {
        #region FIELDS

        public Int32 Width { get; set; }
        public Int32 Height { get; set; }

        private List<Layer> Layers { get; set; }

        private Game GameInstance { get; set; }

        internal Texture2D Grass { get; set; }
        internal Texture2D Water { get; set; }
        internal Texture2D Moutain { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Map initialisation
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Map2D(Game instance, Int32 width, Int32 height)
        {
            this.GameInstance = instance;
            this.Width = width;
            this.Height = height;
            this.Layers = new List<Layer>();
            // Create player list
            // Create object list
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize and load the map assets
        /// </summary>
        /// <returns></returns>
        public Boolean Initialize()
        {
            this.InitializeTexture();
            this.InitializeWaterLayer();
            return true;
        }

        /// <summary>
        /// Update the layers, players and objets
        /// </summary>
        public void Update()
        {
            foreach (Layer layer in this.Layers)
            {
                layer.Update();
            }
        }

        /// <summary>
        /// Draw the layers, players and objects
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (Layer layer in this.Layers)
            {
                layer.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        /// <summary>
        /// Initialize the textures
        /// </summary>
        private void InitializeTexture()
        {
            this.Grass = this.GameInstance.Content.Load<Texture2D>("TexturesMap//grass.png");
            this.Water = this.GameInstance.Content.Load<Texture2D>("TexturesMap//water.png");
            this.Moutain = this.GameInstance.Content.Load<Texture2D>("TexturesMap//moutain.png");
        }

        /// <summary>
        /// Initialize the first layer (water)
        /// </summary>
        private void InitializeWaterLayer()
        {
            Layer _layer = new Layer(this);
            _layer.Initialize();
            for (Int32 i = 0; i < this.Width; ++i)
            {
                for (Int32 j = 0; j < this.Height; ++j)
                {
                    _layer.TileMap[i, j] = 0;
                }
            }
            this.AddLayer(_layer);
        }

        #endregion

        #region LAYER MANAGER

        /// <summary>
        /// Add a new layer
        /// </summary>
        /// <param name="layer"></param>
        public void AddLayer(Layer layer)
        {
            if (this.Layers.Contains(layer) == false)
            {
                this.Layers.Add(layer);
            }
        }

        /// <summary>
        /// Remove a layer
        /// </summary>
        /// <param name="layer"></param>
        public void RemoveLayer(Layer layer)
        {
            if (this.Layers.Contains(layer) == true)
            {
                this.Layers.Remove(layer);
            }
        }

        #endregion
    }
}
