using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;
using Zappy_Client.Interface.Extension;

/*--------------------------------------------------------
 * Inventory.cs - file description
 * 
 * Version: 1.0
 * Author: Samy
 * Created: 02/07/2014 11:15:34
 * 
 * Notes:
 * Inventory to show player's infos
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class Inventory : Container
    {

        #region FIELDS

        // Textures
        private Image ItemsBg { get; set; }
        private Image ItemsSlots { get; set; }
        private Image LevelsBar { get; set; }
        private Image[] Levels { get; set; }

        // Dynamic items
        private ProgressBar Food { get; set; }
        private ProgressBar Cast { get; set; }
        private ProgressBar Xp { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize the custom Inventory window
        /// </summary>
        /// <param name="engine"></param>
        public Inventory(UI engine)
            : base(engine, "Inventory")
        {
            this.Initialize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the Inventory window
        /// </summary>
        public override void Initialize()
        {
            // Loading Inventory images
            this.LevelsBar = new Image(this.Engine.Content.Load<Texture2D>("Theme//Inventory//levelsBar.png"));
            this.ItemsBg = new Image(this.Engine.Content.Load<Texture2D>("Theme//Inventory//itemsBg.png"));
            this.Levels = new Image[8];

            // Setting container's positions
            this.Width = this.ItemsBg.Tex.Width + this.LevelsBar.Tex.Width;
            this.Height = this.ItemsBg.Tex.Height;
            this.X = 0;
            this.Y = 0;

            // Setting Inventory items position
            this.LevelsBar.Rec = new Vector2(Zappy.Width / 2 - this.Width / 2, Zappy.Height - this.LevelsBar.Tex.Height);
            this.ItemsBg.Rec = new Vector2(this.LevelsBar.Rec.X + this.LevelsBar.Tex.Width, this.LevelsBar.Rec.Y - this.LevelsBar.Tex.Height + 14);
            for (Int32 i = 0; i < 8; i++)
            {
                this.Levels[i] = new Image(this.Engine.Content.Load<Texture2D>("Theme//Inventory//ButtNum" + (i + 1) + ".png"));
                this.Levels[i].Rec = new Vector2(this.LevelsBar.Rec.X + 36 + (i * 36), this.LevelsBar.Rec.Y + 35);
            }

            // Loading and initializing dynamic items
            this.Food = new ProgressBar(this.Engine, "Food",
                Int32.Parse(this.LevelsBar.Rec.X.ToString()) + 413,
                Int32.Parse(this.LevelsBar.Rec.Y.ToString()) + 31,
                131, ProgressBarColor.Green, 100);
            this.Xp = new ProgressBar(this.Engine, "Xp",
                Int32.Parse(this.LevelsBar.Rec.X.ToString()) + 413,
                Int32.Parse(this.LevelsBar.Rec.Y.ToString()) + 45,
                131, ProgressBarColor.Blue, 50);
            this.Cast = new ProgressBar(this.Engine, "Cast",
                Int32.Parse(this.LevelsBar.Rec.X.ToString()) + 413,
                Int32.Parse(this.LevelsBar.Rec.Y.ToString()) + 59,
                131, ProgressBarColor.Red, 60);
            this.AddControl(this.Food);
            this.AddControl(this.Xp);
            this.AddControl(this.Cast);
            base.Initialize();
        }

        /// <summary>
        /// Update the Inventory window
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the Inventory window
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.ItemsBg.Tex, this.ItemsBg.Rec, Color.White);
            spriteBatch.Draw(this.LevelsBar.Tex, this.LevelsBar.Rec, Color.White);
            for (Int32 i = 0; i < 8; i++)
            {
                spriteBatch.Draw(this.Levels[i].Tex, this.Levels[i].Rec, this.Levels[i].getOffset(), Color.White);
            }
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Update a control's value
        /// </summary>
        /// <param name="control">control name</param>
        /// <param name="value">control new value</param>
        public void updateControl<T>(String control, Object value)
        {
            foreach (Control item in this.Controls)
            {
                if (item.Name == control)
                {
                    if (typeof(T) == typeof(ProgressBar))
                    {
                        (item as ProgressBar).Value = Convert.ToInt32(value);
                        return;
                    }
                    else if (typeof(T) == typeof(Label))
                    {
                        (item as Label).Text = Convert.ToString(value);
                        return;
                    }
                }
            }
            throw new Exception("Unknown control name \"" + control + "\" in container \"" + this.Name + "\".");
        }

        #endregion
    }
}
