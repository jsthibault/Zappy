using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * TextureManager.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 14/05/2014 11:42:14
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class TextureManager
    {
        #region FIELDS

        private Dictionary<String, Texture2D> Textures { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize the Texture manager
        /// </summary>
        public TextureManager()
        {
            this.Textures = new Dictionary<String, Texture2D>();
        }

        #endregion

        #region METHODS

        public Texture2D this[String key]
        {
            get
            {
                if (this.Textures.ContainsKey(key) == true)
                {
                    return this.Textures[key];
                }
                return null;
            }
            set
            {
                if (this.Textures.ContainsKey(key) == true)
                {
                    this.Textures[key] = value;
                }
                else
                {
                    this.Textures.Add(key, value);
                }
            }
        }

        #endregion
    }
}
