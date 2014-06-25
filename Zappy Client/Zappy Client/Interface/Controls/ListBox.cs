using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * ListBox.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 25/06/2014 15:11:28
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class ListBox : Control
    {
        #region FIELDS

        private List<ListBoxItem> Items { get; set; }

        #endregion

        #region CONSTRUCTORS

        public ListBox(UI engine, String name)
            : base(engine, name)
        {
            this.Items = new List<ListBoxItem>();
            this.X = 0;
            this.Y = 0;
            this.Width = 100;
            this.Height = 100;
        }

        public ListBox(UI engine, String name, Int32 x, Int32 y)
            : base(engine, name)
        {
            this.Items = new List<ListBoxItem>();
            this.X = x;
            this.Y = y;
            this.Width = 100;
            this.Height = 100;
        }

        public ListBox(UI engine, String name, Int32 x, Int32 y, Int32 width, Int32 height)
            : base(engine, name)
        {
            this.Items = new List<ListBoxItem>();
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        #endregion

        #region METHODS

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ListBoxItem
    {
        public Object ItemObject { get; set; }
        public String ItemText { get; set; }

        public ListBoxItem(String itemText, Object itemObject)
        {
            this.ItemObject = itemObject;
            this.ItemText = itemText;
        }
    }
}
