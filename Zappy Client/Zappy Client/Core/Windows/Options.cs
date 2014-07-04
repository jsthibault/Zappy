﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zappy_Client.Interface;

/*--------------------------------------------------------
 * Options.cs - Options window
 * 
 * Version: 1.0
 * Author: ouache_s
 * Created: 03/07/2014 13:36:05
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core.Windows
{
    public class Options : Container
    {

        #region FIELDS

        private Texture2D Background { get; set; }

        private Label Message { get; set; }

        private Button Save { get; set; }
        private Button Quit { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Options(UI engine)
            : base(engine, "Options")
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
            this.Background = this.Engine.Content.Load<Texture2D>("Theme//window");
            this.Message = new Label(this.Engine, "LabelMessage", 140, 13, "Options");
            this.Width = this.Background.Width;
            this.Height = this.Background.Height;
            this.X = Zappy.Width / 2 - this.Background.Width / 2;
            this.Y = Zappy.Height / 2 - this.Background.Height / 2;
            this.Save = new Button(this.Engine, "SaveButton", 52, 160, 110, 0, "Sauvegarder");
            this.Save.OnClick += Save_OnClick;
            this.Quit = new Button(this.Engine, "QuitButton", 185, 160, 110, 0, "Annuler");
            this.Quit.OnClick += Quit_OnClick;
            this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 37));
            this.AddControl(this.Save);
            this.AddControl(this.Quit);
            this.AddControl(this.Message);
            base.Initialize();
        }

        void Quit_OnClick(object sender)
        {
            this.Visible = false;
        }

        void Save_OnClick(object sender)
        {
            
        }

        /// <summary>
        /// Update the Viewer window
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 37));
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

        #endregion

    }
}
