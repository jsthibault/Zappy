using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*--------------------------------------------------------
 * Image.cs - file description
 * 
 * Version: 1.0
 * Author: ouache_s
 * Created: 02/07/2014 22:03:12
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface.Extension
{

    public class Image
    {
        #region FIELDS

        public Texture2D Tex { get; set; }
        public Vector2 Rec { get; set; }
        public ControlState State { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Image(Texture2D texture, Vector2 rectangle, ControlState state)
        {
            this.Tex = texture;
            this.Rec = rectangle;
            this.State = state;
        }

        public Image(Texture2D texture, Vector2 rectangle)
        {
            this.Tex = texture;
            this.Rec = rectangle;
            this.State = ControlState.Normal;
        }

        public Image(Texture2D texture, ControlState state)
        {
            this.Tex = texture;
            this.Rec = new Vector2(0, 0);
            this.State = state;
        }

        public Image(Texture2D texture)
        {
            this.Tex = texture;
            this.Rec = new Vector2(0, 0);
            this.State = ControlState.Normal;
        }

        #endregion

        #region METHODS

        public Rectangle getOffset()
        {
            if (this.State == ControlState.Normal)
                return new Rectangle(32, 0, 32, 32);
            return new Rectangle(0, 0, 32, 32);
        }

        #endregion
    }

}
