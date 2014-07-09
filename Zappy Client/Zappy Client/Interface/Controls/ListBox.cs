using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        public List<ListBoxItem> Items { get; set; }

        public ListBoxItem SelectedItem { get; set; }

        public event MonoGameEventHandler OnSelectedItem;

        private Int32 MaxItems { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a new ListBox
        /// </summary>
        /// <param name="engine">UI Engine</param>
        /// <param name="name">Control name</param>
        public ListBox(UI engine, String name)
            : base(engine, name)
        {
            this.Items = new List<ListBoxItem>();
            this.X = 0;
            this.Y = 0;
            this.Width = 100;
            this.Height = 100;
            this.Initialize();
        }

        /// <summary>
        /// Creates a new ListBox with position
        /// </summary>
        /// <param name="engine">UI Engine</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        public ListBox(UI engine, String name, Int32 x, Int32 y)
            : base(engine, name)
        {
            this.Items = new List<ListBoxItem>();
            this.X = x;
            this.Y = y;
            this.Width = 100;
            this.Height = 100;
            this.Initialize();
        }

        /// <summary>
        /// Creates a new ListBox with position and size
        /// </summary>
        /// <param name="engine">UI Engine</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="width">Control Width</param>
        /// <param name="height">Control height</param>
        public ListBox(UI engine, String name, Int32 x, Int32 y, Int32 width, Int32 height)
            : base(engine, name)
        {
            this.Items = new List<ListBoxItem>();
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Initialize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the ListBox
        /// </summary>
        public override void Initialize()
        {
            this.MaxItems = (Int32)(this.Height / this.Engine.Fonts["TrebuchetMS"].MeasureString("test").Y);

            Int32 _textureWidth = this.Engine.Textures["ListBoxDown"].Width / 4;
            Int32 _textureHeight = this.Engine.Textures["ListBoxDown"].Height;
        }

        /// <summary>
        /// Update controls
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw controls and items
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.DrawBackground(spriteBatch);
            this.DrawItems(spriteBatch);
            //base.Draw(spriteBatch);
        }

        /// <summary>
        /// Draw the ListBox background
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawBackground(SpriteBatch spriteBatch)
        {
            Texture2D _texture = this.Engine.Textures["ListBoxBackground"];

            // top
            spriteBatch.Draw(_texture, new Rectangle(this.Rectangle.X, this.Rectangle.Y, 16, 16), new Rectangle(0, 0, 16, 16), Color.White);
            spriteBatch.Draw(_texture, new Rectangle(Rectangle.X + 16, Rectangle.Y, Rectangle.Width - 32, 16), new Rectangle(16, 0, 16, 16), Color.White);
            spriteBatch.Draw(_texture, new Rectangle(Rectangle.Right - 16, Rectangle.Y, 16, 16), new Rectangle(_texture.Width - 16, 0, 16, 16), Color.White);

            // mid
            spriteBatch.Draw(_texture, new Rectangle(Rectangle.X, Rectangle.Y + 16, 16, Rectangle.Height - 32), new Rectangle(0, 4, 16, 16), Color.White);
            spriteBatch.Draw(_texture, new Rectangle(Rectangle.X + 16, Rectangle.Y + 16, Rectangle.Width - 32, Rectangle.Height - 32), new Rectangle(16, 4, 16, 16), Color.White);
            spriteBatch.Draw(_texture, new Rectangle(Rectangle.Right - 16, Rectangle.Y + 16, 16, Rectangle.Height - 32), new Rectangle(_texture.Width - 16, 4, 16, 16), Color.White);

            // bot
            spriteBatch.Draw(_texture, new Rectangle(Rectangle.X, Rectangle.Bottom - 16, 16, 16), new Rectangle(0, _texture.Height - 16, 16, 16), Color.White);
            spriteBatch.Draw(_texture, new Rectangle(Rectangle.X + 16, Rectangle.Bottom - 16, Rectangle.Width - 32, 16), new Rectangle(16, _texture.Height - 16, 16, 16), Color.White);
            spriteBatch.Draw(_texture, new Rectangle(Rectangle.Right - 16, Rectangle.Bottom - 16, 16, 16), new Rectangle(_texture.Width - 16, _texture.Height - 16, 16, 16), Color.White);
        
            // Buttons
            //spriteBatch.Draw(this.ButtonDown.Texture, new Vector2(this.Rectangle.X + this.Width - 16, this.Position.Y + this.Height - 16), Color.White);
            //spriteBatch.Draw(this.ButtonUp.Texture, new Vector2(this.Rectangle.X + this.Width - 16, this.Position.Y), Color.White);
        }

        /// <summary>
        /// Draw the ListBox Items
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawItems(SpriteBatch spriteBatch)
        {
            Int32 _offsetX = 5;
            foreach (ListBoxItem item in this.Items)
            {
                if (item == this.SelectedItem)
                {
                    spriteBatch.Draw(this.Engine.Textures["ListBoxSelector"], new Vector2(this.Rectangle.X + 5, this.Position.Y + _offsetX), Color.White);
                } 
                spriteBatch.DrawString(this.Engine.Fonts["TrebuchetMS"], item.ItemText, new Vector2(this.Rectangle.X + 25, this.Position.Y + _offsetX - 4), Color.White);
                _offsetX += 15;
            }
        }

        /// <summary>
        /// Add a new Item
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(ListBoxItem item)
        {
            if (this.Items.Contains(item) == false)
            {
                this.Items.Add(item);
            }
        }

        /// <summary>
        /// Remove an Item
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(ListBoxItem item)
        {
            if (this.Items.Contains(item) == true)
            {
                this.Items.Remove(item);
            }
        }

        /// <summary>
        /// Remove an Item by his name
        /// </summary>
        /// <param name="itemName"></param>
        public void RemvoeItem(String itemName)
        {
            for (Int32 i = 0; i < this.Items.Count; ++i)
            {
                if (this.Items[i].ItemText == itemName)
                {
                    this.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void DoOnSelectedItem()
        {
            if (this.OnSelectedItem != null)
                this.OnSelectedItem(this);
        }

        #endregion

        #region EVENTS

        /// <summary>
        /// Event fired on mouse click
        /// </summary>
        public override void MouseClick()
        {
            Point _mousePosition = Mouse.GetState().GetPosition();
            Int32 _offsetX = 5;

            foreach (ListBoxItem item in this.Items)
            {
                if (_mousePosition.X >= this.Rectangle.X + 5 && _mousePosition.X <= this.Width &&
                    _mousePosition.Y >= this.Position.Y + _offsetX && _mousePosition.Y <= this.Position.Y + _offsetX + 10)
                {
                    this.SelectedItem = item;
                    this.DoOnSelectedItem();
                    break;
                }
                _offsetX += 15;
            }
            base.MouseClick();
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
