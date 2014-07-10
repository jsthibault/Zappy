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
 * Created: 10/07/2014 18:45:23
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public class TextureManager
    {
        #region SINGLETON

        private static Object objLock = new Object();
        private static TextureManager instance = null;
        public static TextureManager Instance
        {
            get
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new TextureManager();
                    }
                    return instance;
                }
            }
        }

        #endregion

        #region FIELDS

        private Dictionary<String, Texture2D> Textures { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates the texture manager
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
                if (this.Textures.ContainsKey(key) == false)
                {
                    this.Textures.Add(key, value);
                }
                else
                {
                    this.Textures[key] = value;
                }
            }
        }

        #endregion
    }
}
