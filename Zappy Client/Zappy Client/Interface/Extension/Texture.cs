using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Texture.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 25/06/2014 18:48:21
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public static class TextureExt
    {
        public static void SetNewTexture(this Texture2D texture, Texture2D old, Rectangle source)
        {
            Color[] data = new Color[source.Width * source.Height];
            old.GetData(0, source, data, 0, data.Length);
            texture.SetData(data);
        }
    }
}
