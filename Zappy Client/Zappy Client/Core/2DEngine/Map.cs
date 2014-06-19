﻿using Microsoft.Xna.Framework;
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

        private Game GameInstance { get; set; }

        internal Texture2D Grass { get; set; }
        internal Texture2D Water { get; set; }
        internal Texture2D Moutain { get; set; }
        internal SpriteFont Debug { get; set; }

        const Int32 Case = 32;

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
            return true;
        }

        /// <summary>
        /// Update the layers, players and objets
        /// </summary>
        public void Update()
        {
            
        }

        /// <summary>
        /// Draw the layers, players and objects
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            this.DrawWater(spriteBatch);
            this.DrawMountain(spriteBatch);
            this.DrawGround(spriteBatch);
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
            this.Debug = this.GameInstance.Content.Load<SpriteFont>("Theme//Font//TrebuchetMS10");
        }

        /// <summary>
        /// Draw water layer
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawWater(SpriteBatch spriteBatch)
        {
            Int32 _waterWidth = Zappy.Width / 32 + 2;
            Int32 _waterHeight = Zappy.Height / 32 + 2;

            for (Int32 i = 0; i < _waterWidth; ++i)
            {
                for (Int32 j = 0; j < _waterHeight; ++j)
                {
                    spriteBatch.Draw(this.Water, new Vector2(i * 32, j * 32), Color.White);
                }
            }
        }

        /// <summary>
        /// Draw moutain
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawMountain(SpriteBatch spriteBatch)
        {
            // Top part
            Rectangle _sourceLeftTop = new Rectangle(0, 0, 16, 16);
            Rectangle _sourceMidTop = new Rectangle(16, 0, 16, 16);
            Rectangle _sourceRightTop = new Rectangle(32, 0, 16, 16);

            spriteBatch.Draw(this.Moutain, new Vector2((10 * Case) - 16, (10 * Case) - 16), _sourceLeftTop, Color.White);
            for (Int32 i = 1; i < (this.Width * 2) + 1; ++i)
            {
                spriteBatch.Draw(this.Moutain, new Vector2((10 * Case + (i * 16)) - 16, (10 * Case) - 16), _sourceMidTop, Color.White);
            }
            spriteBatch.Draw(this.Moutain, new Vector2((10 * Case + (this.Width * 32 + 16)) - 16, (10 * Case) - 16), _sourceRightTop, Color.White);

            // mid part
            Rectangle _sourceLeftMid = new Rectangle(0, 16, 16, 16);
            Rectangle _sourceRightMid = new Rectangle(32, 16, 16, 16);
            for (Int32 i = 1; i < (this.Height * 2) + 1; ++i)
            {
                spriteBatch.Draw(this.Moutain, new Vector2((10 * Case) - 16, (10 * Case + (i * 16)) - 16), _sourceLeftMid, Color.White); // Left
                spriteBatch.Draw(this.Moutain, new Vector2((10 * Case + (this.Width * 32 + 16)) - 16, (10 * Case + (i * 16)) - 16), _sourceRightMid, Color.White); // Right
            }

            // Bottom part
            Rectangle _sourceLeftBot = new Rectangle(0, 32, 16, 16);
            Rectangle _sourceMidBot = new Rectangle(16, 32, 16, 16);
            Rectangle _sourceRightBot = new Rectangle(32, 32, 16, 16);

            spriteBatch.Draw(this.Moutain, new Vector2((10 * Case) - 16, (10 * Case + (this.Height * 32 + 16)) - 16), _sourceLeftBot, Color.White);
            for (Int32 i = 1; i < (this.Width * 2) + 1; ++i)
            {
                spriteBatch.Draw(this.Moutain, new Vector2((10 * Case + (i * 16)) - 16, (10 * Case + (this.Height * 32 + 16)) - 16), _sourceMidBot, Color.White);
            }
            spriteBatch.Draw(this.Moutain, new Vector2((10 * Case + (this.Width * 32 + 16)) - 16, (10 * Case + (this.Height * 32 + 16)) - 16), _sourceRightBot, Color.White);

        }

        /// <summary>
        /// Draw ground of grass
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawGround(SpriteBatch spriteBatch)
        {
            for (Int32 i = 10; i < this.Width + 10; ++i)
            {
                for (Int32 j = 10; j < this.Height + 10; ++j)
                {
                    spriteBatch.Draw(this.Grass, new Vector2(i * 32, j * 32), Color.White);
                    spriteBatch.DrawString(this.Debug, (i - 10).ToString() + "," + (j - 10).ToString(), new Vector2(i * 32, j * 32), Color.Black);
                }
            }
        }


        #endregion
    }
}
