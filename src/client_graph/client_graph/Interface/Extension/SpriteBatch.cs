using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * SpriteBatch.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 15/05/2014 17:34:54
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public static class SpriteBatchExt
    {
        /// <summary>
        /// Draw centered text in rectangle
        /// </summary>
        /// <param name="batch">SpriteBatch</param>
        /// <param name="font">Font</param>
        /// <param name="rectangle">Dest rectangle</param>
        /// <param name="text">Text</param>
        /// <param name="color">Text color</param>
        public static void DrawCenteredText(this SpriteBatch batch, SpriteFont font, Rectangle rectangle, String text, Color color)
        {
            Vector2 _size = font.MeasureString(text);
            Vector2 _topLeft = new Vector2(rectangle.Center.X, rectangle.Center.Y) - (_size * 0.5f);

            batch.DrawString(font, text, _topLeft, color);
        }
    }
}
