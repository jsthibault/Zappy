using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Draw.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 10/07/2014 18:31:56
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public partial class Map2D
    {
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
                    spriteBatch.Draw(TextureManager.Instance["Water"], new Vector2(i * 32, j * 32), Color.White);
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
            spriteBatch.Draw(TextureManager.Instance["Moutain"], new Vector2((this.OffsetX) - 16, (this.OffsetY) - 16), _sourceLeftTop, Color.White);
            for (Int32 i = 1; i < (this.Width * 2) + 1; ++i)
            {
                spriteBatch.Draw(TextureManager.Instance["Moutain"], new Vector2((this.OffsetX + (i * 16)) - 16, (this.OffsetY) - 16), _sourceMidTop, Color.White);
            }
            spriteBatch.Draw(TextureManager.Instance["Moutain"], new Vector2((this.OffsetX + (this.Width * 32 + 16)) - 16, (this.OffsetY) - 16), _sourceRightTop, Color.White);

            // mid part
            Rectangle _sourceLeftMid = new Rectangle(0, 16, 16, 16);
            Rectangle _sourceRightMid = new Rectangle(32, 16, 16, 16);
            for (Int32 i = 1; i < (this.Height * 2) + 1; ++i)
            {
                spriteBatch.Draw(TextureManager.Instance["Moutain"], new Vector2((this.OffsetX) - 16, (this.OffsetY + (i * 16)) - 16), _sourceLeftMid, Color.White); // Left
                spriteBatch.Draw(TextureManager.Instance["Moutain"], new Vector2((this.OffsetX + (this.Width * 32 + 16)) - 16, (this.OffsetY + (i * 16)) - 16), _sourceRightMid, Color.White); // Right
            }

            // Bottom part
            Rectangle _sourceLeftBot = new Rectangle(0, 32, 16, 16);
            Rectangle _sourceMidBot = new Rectangle(16, 32, 16, 16);
            Rectangle _sourceRightBot = new Rectangle(32, 32, 16, 16);

            spriteBatch.Draw(TextureManager.Instance["Moutain"], new Vector2((this.OffsetX) - 16, (this.OffsetY + (this.Height * 32 + 16)) - 16), _sourceLeftBot, Color.White);
            for (Int32 i = 1; i < (this.Width * 2) + 1; ++i)
            {
                spriteBatch.Draw(TextureManager.Instance["Moutain"], new Vector2((this.OffsetX + (i * 16)) - 16, (this.OffsetY + (this.Height * 32 + 16)) - 16), _sourceMidBot, Color.White);
            }
            spriteBatch.Draw(TextureManager.Instance["Moutain"], new Vector2((this.OffsetX + (this.Width * 32 + 16)) - 16, (this.OffsetY + (this.Height * 32 + 16)) - 16), _sourceRightBot, Color.White);

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
                    spriteBatch.Draw(TextureManager.Instance["Grass"], new Vector2(this.OffsetX + i * 32, this.OffsetY + j * 32), Color.White);
                }
            }
        }

        /// <summary>
        /// Draw the map cursor
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawCursor(SpriteBatch spriteBatch)
        {
            if (this.CursorX >= 0 && this.CursorY >= 0 && this.CursorX < this.Width && this.CursorY < this.Height)
            {
                spriteBatch.Draw(TextureManager.Instance["Cursor"], new Vector2(this.OffsetX + this.CursorX * 32, this.OffsetY + this.CursorY * 32), Color.White);
            }
        }

        /// <summary>
        /// Draw the grid
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawGrid(SpriteBatch spriteBatch)
        {
            if (OptionVal.Instance.ShowGrid == true)
            {
                for (Int32 i = 0; i < this.Width; ++i)
                {
                    for (Int32 j = 0; j < this.Height; ++j)
                    {
                        spriteBatch.Draw(TextureManager.Instance["Grid"], new Vector2(this.OffsetX + i * 32, this.OffsetY + j * 32), Color.White);
                    }
                }
            }
        }

        /// <summary>
        /// Draw items on map
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawItems(SpriteBatch spriteBatch)
        {
            for (Int32 i = 0; i < this.Width; ++i)
            {
                for (Int32 j = 0; j < this.Height; ++j)
                {
                    foreach (FrameContent frame in this.Frames)
                    {
                        if (frame.X == i && frame.Y == j && frame.HasItems() == true)
                        {
                            Int32 _itemsCount = frame.GetItemCount();
                            if (_itemsCount > 0)
                            {
                                spriteBatch.Draw(TextureManager.Instance["Cristal" + (_itemsCount - 1).ToString()], new Vector2(this.OffsetX + i * 32, this.OffsetY + j * 32), Color.White);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Draw portals
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawPortals(SpriteBatch spriteBatch)
        {
            foreach (Animation portal in this.Portals)
            {
                portal.Draw(spriteBatch);
            }
        }
    }
}
