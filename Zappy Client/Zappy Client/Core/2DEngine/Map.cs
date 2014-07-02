﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;

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

namespace Zappy_Client.Core._2DEngine
{
    public class Map2D
    {
        #region FIELDS

        public Int32 Width { get; set; }
        public Int32 Height { get; set; }

        private Game GameInstance { get; set; }
        private Camera Camera { get; set; }

        private Texture2D Grass { get; set; }
        private Texture2D Water { get; set; }
        private Texture2D Moutain { get; set; }
        private Texture2D Cursor { get; set; }
        private SpriteFont Debug { get; set; }

        const Int32 Case = 32;

        private Int32 WaterWidth { get; set; }
        private Int32 WaterHeight { get; set; }

        private Int32 OffsetX { get; set; }
        private Int32 OffsetY { get; set; }


        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Map initialisation
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Map2D(Game instance, Int32 width, Int32 height, Camera camera)
        {
            this.GameInstance = instance;
            this.Width = width;
            this.Height = height;
            this.WaterWidth = (Zappy.Width / 32) * 2 + this.Width;
            this.WaterHeight = (Zappy.Height / 32) * 2 + this.Height;
            this.OffsetX = ((this.WaterWidth * Case) / 2) - ((this.Width * Case) / 2);
            this.OffsetY = ((this.WaterHeight * Case) / 2) - ((this.Height * Case) / 2);
            this.Camera = camera;
            this.Camera.SetPosition(new Vector2(this.OffsetX + (Zappy.Width / 4), this.OffsetX));
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
            this.Camera.Update();
            KeyboardState _state = Keyboard.GetState();

            if (_state.IsKeyDown(Keys.Up) == true && this.Camera.Position.Y >= Zappy.Height / 2)
            {
                this.Camera.Move(new Vector2(0, -10));
            }
            else if (_state.IsKeyDown(Keys.Down) == true && this.Camera.Position.Y < Zappy.Height * 2)
            {
                this.Camera.Move(new Vector2(0, 10));
            }
            else if (_state.IsKeyDown(Keys.Left) == true && this.Camera.Position.X >= Zappy.Width / 2)
            {
                this.Camera.Move(new Vector2(-10, 0));
            }
            else if (_state.IsKeyDown(Keys.Right) == true && this.Camera.Position.X <= Zappy.Width * 2)
            {
                this.Camera.Move(new Vector2(10, 0));
            }

            MouseState _mouseState = Mouse.GetState();

            this.Camera.Zoom = _mouseState.ScrollWheelValue / 100;
        }

        /// <summary>
        /// Draw the layers, players and objects
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
            this.DrawWater(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
            this.DrawMountain(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
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
            this.Cursor = this.GameInstance.Content.Load<Texture2D>("TexturesMap//cursor.png");
            this.Debug = this.GameInstance.Content.Load<SpriteFont>("Theme//Font//TrebuchetMS10");
        }

        /// <summary>
        /// Draw water layer
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawWater(SpriteBatch spriteBatch)
        {
            for (Int32 i = -1; i < this.WaterWidth + 1; ++i)
            {
                for (Int32 j = -1; j < this.WaterHeight + 1; ++j)
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
            spriteBatch.Draw(this.Moutain, new Vector2((this.OffsetX) - 16, (this.OffsetY) - 16), _sourceLeftTop, Color.White);
            for (Int32 i = 1; i < (this.Width * 2) + 1; ++i)
            {
                spriteBatch.Draw(this.Moutain, new Vector2((this.OffsetX + (i * 16)) - 16, (this.OffsetY) - 16), _sourceMidTop, Color.White);
            }
            spriteBatch.Draw(this.Moutain, new Vector2((this.OffsetX + (this.Width * 32 + 16)) - 16, (this.OffsetY) - 16), _sourceRightTop, Color.White);

            // mid part
            Rectangle _sourceLeftMid = new Rectangle(0, 16, 16, 16);
            Rectangle _sourceRightMid = new Rectangle(32, 16, 16, 16);
            for (Int32 i = 1; i < (this.Height * 2) + 1; ++i)
            {
                spriteBatch.Draw(this.Moutain, new Vector2((this.OffsetX) - 16, (this.OffsetY + (i * 16)) - 16), _sourceLeftMid, Color.White); // Left
                spriteBatch.Draw(this.Moutain, new Vector2((this.OffsetX + (this.Width * 32 + 16)) - 16, (this.OffsetY + (i * 16)) - 16), _sourceRightMid, Color.White); // Right
            }

            // Bottom part
            Rectangle _sourceLeftBot = new Rectangle(0, 32, 16, 16);
            Rectangle _sourceMidBot = new Rectangle(16, 32, 16, 16);
            Rectangle _sourceRightBot = new Rectangle(32, 32, 16, 16);

            spriteBatch.Draw(this.Moutain, new Vector2((this.OffsetX) - 16, (this.OffsetY + (this.Height * 32 + 16)) - 16), _sourceLeftBot, Color.White);
            for (Int32 i = 1; i < (this.Width * 2) + 1; ++i)
            {
                spriteBatch.Draw(this.Moutain, new Vector2((this.OffsetX + (i * 16)) - 16, (this.OffsetY + (this.Height * 32 + 16)) - 16), _sourceMidBot, Color.White);
            }
            spriteBatch.Draw(this.Moutain, new Vector2((this.OffsetX + (this.Width * 32 + 16)) - 16, (this.OffsetY + (this.Height * 32 + 16)) - 16), _sourceRightBot, Color.White);

        }

        /// <summary>
        /// Draw ground of grass
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawGround(SpriteBatch spriteBatch)
        {
            for (Int32 i = 0; i < this.Width; ++i)
            {
                for (Int32 j = 0; j < this.Height; ++j)
                {
                    spriteBatch.Draw(this.Grass, new Vector2(this.OffsetX + i * 32, this.OffsetY + j * 32), Color.White);
                }
            }
        }

        #endregion
    }
}