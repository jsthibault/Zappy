﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zappy_Client.Interface;
using Microsoft.Xna.Framework.Media;

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
        private Label MusicLabel { get; set; }
        private Label EffectsLabel { get; set; }

        private Button Save { get; set; }
        private Button Quit { get; set; }
        private Button MusicPlus { get; set; }
        private Button MusicMin { get; set; }
        private Button EffectsPlus { get; set; }
        private Button EffectsMin { get; set; }

        private ProgressBar MusicBar { get; set; }
        private ProgressBar EffectsBar { get; set; }

        private CheckBox GridBox {get; set; }
        #endregion

        #region CONSTRUCTORS

        public Options(UI engine)
            : base(engine, "Options")
        {
            OptionVal.Instance.ShowGrid = false;
            this.Initialize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the Viewer window
        /// </summary>
        public override void Initialize()
        {
            // Grid
            this.GridBox = new CheckBox(this.Engine, "GridBox",55, 80, "Afficher la grille", false);
            this.AddControl(this.GridBox);

            // Volume Music
            this.MusicLabel = new Label(this.Engine, "MusicLabel", 55, 105, "Vol. Musique:");
            this.MusicMin = new Button(this.Engine, "MusicMin", 145, 100, 20, 0, "-");
            this.MusicMin.OnClick += MusicMin_OnClick;
            this.MusicBar = new ProgressBar(this.Engine, "MusicBar", 168, 107, 100, ProgressBarColor.Blue, 100);
            this.MusicPlus = new Button(this.Engine, "MusicPlus", 271, 100, 20, 0, "+");
            this.MusicPlus.OnClick += MusicPlus_OnClick;
            this.AddControl(this.MusicPlus);
            this.AddControl(this.MusicBar);
            this.AddControl(this.MusicMin);
            this.AddControl(this.MusicLabel);

            // Volume Effects
            this.EffectsLabel = new Label(this.Engine, "EffectsLabel", 55, 135, "Vol. Effets:");
            this.EffectsMin = new Button(this.Engine, "EffectsMin", 145, 130, 20, 0, "-");
            this.EffectsMin.OnClick += EffectsMin_OnClick;
            this.EffectsBar = new ProgressBar(this.Engine, "EffectscBar", 168, 137, 100, ProgressBarColor.Blue, 100);
            this.EffectsPlus = new Button(this.Engine, "EffectsPlus", 271, 130, 20, 0, "+");
            this.EffectsPlus.OnClick += EffectsPlus_OnClick;
            this.AddControl(this.EffectsPlus);
            this.AddControl(this.EffectsBar);
            this.AddControl(this.EffectsMin);
            this.AddControl(this.EffectsLabel);

            // Background
            this.Background = this.Engine.Content.Load<Texture2D>("Theme//window");
            this.Message = new Label(this.Engine, "Message", 140, 13, "Options");
            this.Width = this.Background.Width;
            this.Height = this.Background.Height;
            this.X = Zappy.Width - this.Background.Width;
            this.Y = 250; //Zappy.Height / 2 - this.Background.Height / 2;
            this.Save = new Button(this.Engine, "SaveButton", 52, 160, 110, 0, "Sauvegarder");
            this.Save.OnClick += Save_OnClick;
            this.Quit = new Button(this.Engine, "QuitButton", 185, 160, 110, 0, "Annuler");
            this.Quit.OnClick += Quit_OnClick;
            //this.SetMouvableZone(new Rectangle(this.X, this.Y, this.Width, 37));
            this.AddControl(this.Save);
            this.AddControl(this.Quit);
            this.AddControl(this.Message);
            base.Initialize();
        }

        private void EffectsPlus_OnClick(object sender)
        {
            if (this.EffectsBar.Value < 100)
            {
                this.EffectsBar.Value += 10;
            }
        }

        private void EffectsMin_OnClick(object sender)
        {
            if (this.EffectsBar.Value > 0)
            {
                this.EffectsBar.Value -= 10;
            }
        }

        private void MusicPlus_OnClick(object sender)
        {
            if (this.MusicBar.Value < 100)
            {
                this.MusicBar.Value += 10;
            }
        }

        private void MusicMin_OnClick(object sender)
        {
            if (this.MusicBar.Value > 0)
            {
                this.MusicBar.Value -= 10;
            }
        }

        private void Quit_OnClick(object sender)
        {
            this.Visible = false;
        }

        private void Save_OnClick(object sender)
        {
            OptionVal.Instance.ShowGrid = this.GridBox.Checked;
            OptionVal.Instance.VolumeSound = this.MusicBar.Value / 100f;
            OptionVal.Instance.VolumeEffects = this.EffectsBar.Value / 100f;
            MediaPlayer.Volume = OptionVal.Instance.VolumeSound;
            this.Visible = false;
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