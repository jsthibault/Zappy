using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zappy_Client.Interface;

/*--------------------------------------------------------
 * Popup.cs - Popup window
 * 
 * Version: 1.0
 * Author: ouache_s
 * Created: 03/07/2014 13:36:05
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core.Windows
{
    public class Popup : Container
    {

        #region FIELDS

        private Texture2D Background { get; set; }

        private Label Content { get; set; }

        private Button Close { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Popup(UI engine)
            : base(engine, "Popup")
        {
            this.Initialize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the Viewer window
        /// </summary>
        public override void Initialize()
        {
            this.Background = this.Engine.Content.Load<Texture2D>("Theme//popup");
            this.Content = new Label(this.Engine, "LabelText", 55, 65, "Default");
            this.Close = new Button(this.Engine, "CloseButton", 185, 130, 110, 0, "Fermer");
            this.Close.OnClick += Close_OnClick;
            this.Width = this.Background.Width;
            this.Height = this.Background.Height;
            this.X = Zappy.Width / 2 - this.Background.Width / 2;
            this.Y = Zappy.Height / 2 - this.Background.Height / 2;
            this.AddControl(this.Content);
            this.AddControl(this.Close);
            base.Initialize();
        }

        void Close_OnClick(object sender)
        {
            this.Hide();
        }

        /// <summary>
        /// Update the Viewer window
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the Viewer window
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Background, this.Rectangle, Color.White);
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Show popup window and set its content
        /// </summary>
        /// <param name="content"></param>
        public void Show(String content)
        {
            this.Content.Text = content;
            this.Visible = true;
        }

        public void Hide()
        {
            this.Visible = false;
        }

        #endregion

    }
}
