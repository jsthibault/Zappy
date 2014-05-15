using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * FontManager.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 15/05/2014 14:40:44
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class FontManager
    {
        #region FIELDS

        private Dictionary<String, SpriteFont> Fonts { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a new Font manager
        /// </summary>
        public FontManager()
        {
            this.Fonts = new Dictionary<String, SpriteFont>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Gets or set a sprite font by key
        /// </summary>
        /// <param name="key">SpriteFont key</param>
        /// <returns>SpriteFont</returns>
        public SpriteFont this[String key]
        {
            get
            {
                if (this.Fonts.ContainsKey(key) == true)
                {
                    return this.Fonts[key];
                }
                return null;
            }
            set
            {
                if (this.Fonts.ContainsKey(key) == true)
                {
                    this.Fonts[key] = value;
                }
                else
                {
                    this.Fonts.Add(key, value);
                }
            }
        }

        #endregion
    }
}
