using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;

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
        private ImageBox ItemsBg { get; set; }
        private ImageBox ItemsSlots { get; set; }
        private ImageBox LevelsBar { get; set; }
        private ImageBox[] Levels { get; set; }

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
            Texture2D Bar = this.Engine.Content.Load<Texture2D>("Theme//Inventory//levelsBar.png");
            this.LevelsBar = new ImageBox(this.Engine, "LevelBar", Bar, Zappy.Width / 2 - Bar.Width / 2 - 83, Zappy.Height - Bar.Height);
            this.ItemsBg = new ImageBox(this.Engine, "ItemBg", this.Engine.Content.Load<Texture2D>("Theme//Inventory//itemsBg.png"), this.LevelsBar.Rectangle.X + this.LevelsBar.Texture.Width, this.LevelsBar.Rectangle.Y - this.LevelsBar.Texture.Height + 14);
            this.Levels = new ImageBox[8];
            this.AddControl(this.LevelsBar);
            this.AddControl(this.ItemsBg);

            // Setting container's positions
            this.Width = this.ItemsBg.Texture.Width + this.LevelsBar.Texture.Width;
            this.Height = this.ItemsBg.Texture.Height;
            this.X = 0;
            this.Y = 0;

            // Setting Inventory items position
            for (Int32 i = 0; i < 8; i++)
            {
                this.Levels[i] = new ImageBox(this.Engine, "ButtNum" + (i + 1).ToString(), this.Engine.Content.Load<Texture2D>("Theme//Inventory//ButtNum" + (i + 1) + ".png"), this.LevelsBar.Rectangle.X + 36 + (i * 36), this.LevelsBar.Rectangle.Y + 35);
                this.AddControl(this.Levels[i]);
            }

            // Loading and initializing dynamic items
            this.Food = new ProgressBar(this.Engine, "Food",
                Int32.Parse(this.LevelsBar.Rectangle.X.ToString()) + 413,
                Int32.Parse(this.LevelsBar.Rectangle.Y.ToString()) + 31,
                131, ProgressBarColor.Green, 100);
            this.Xp = new ProgressBar(this.Engine, "Xp",
                Int32.Parse(this.LevelsBar.Rectangle.X.ToString()) + 413,
                Int32.Parse(this.LevelsBar.Rectangle.Y.ToString()) + 45,
                131, ProgressBarColor.Blue, 50);
            this.Cast = new ProgressBar(this.Engine, "Cast",
                Int32.Parse(this.LevelsBar.Rectangle.X.ToString()) + 413,
                Int32.Parse(this.LevelsBar.Rectangle.Y.ToString()) + 59,
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
            spriteBatch.Draw(this.ItemsBg.Texture, this.ItemsBg.Position, Color.White);
            spriteBatch.Draw(this.LevelsBar.Texture, this.LevelsBar.Position, Color.White);
            for (Int32 i = 0; i < 8; i++)
            {
                spriteBatch.Draw(this.Levels[i].Texture, this.Levels[i].Position, GetOffset(this.Levels[i]), Color.White);
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

        /// <summary>
        /// Get Level image offset
        /// </summary>
        /// <returns></returns>
        public Rectangle GetOffset(ImageBox image)
        {
            if (image.State == ControlState.Normal)
                return new Rectangle(32, 0, 32, 32);
            return new Rectangle(0, 0, 32, 32);
        }

        #endregion
    }
}
