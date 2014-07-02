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
        private Texture2D ItemsBg { get; set; }
        private Texture2D ItemsSlots { get; set; }
        private Texture2D LevelsBar { get; set; }

        // Textures position
        private Vector2 ItemsBgRec { get; set; }
        private Vector2 ItemsSlotsRec { get; set; }
        private Vector2 LevelsBarRec { get; set; }

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
            // Loading and initializing static images
            this.ItemsSlots = this.Engine.Content.Load<Texture2D>("Theme//Inventory//itemsSlots.png");
            this.LevelsBar = this.Engine.Content.Load<Texture2D>("Theme//Inventory//levelsBar.png");
            this.ItemsBg = this.Engine.Content.Load<Texture2D>("Theme//Inventory//itemsBg.png");
            this.Width = this.ItemsBg.Width + this.LevelsBar.Width;
            this.Height = this.ItemsBg.Height;
            this.X = 0;
            this.Y = 0;
            this.LevelsBarRec = new Vector2(Zappy.Width / 2 - this.Width / 2, Zappy.Height - this.LevelsBar.Height);
            this.ItemsBgRec = new Vector2(this.LevelsBarRec.X + this.LevelsBar.Width, this.LevelsBarRec.Y - this.LevelsBar.Height + 14);
            this.ItemsSlotsRec = new Vector2(this.LevelsBarRec.X + this.LevelsBar.Width, this.LevelsBarRec.Y - this.LevelsBar.Height + 14);

            // Loading and initializing dynamic items
            this.Food = new ProgressBar(this.Engine, "Food",
                Int32.Parse(this.LevelsBarRec.X.ToString()) + 413,
                Int32.Parse(this.LevelsBarRec.Y.ToString()) + 31,
                131, ProgressBarColor.Green, 100);
            this.Xp = new ProgressBar(this.Engine, "Xp",
                Int32.Parse(this.LevelsBarRec.X.ToString()) + 413,
                Int32.Parse(this.LevelsBarRec.Y.ToString()) + 45,
                131, ProgressBarColor.Blue, 50);
            this.Cast = new ProgressBar(this.Engine, "Cast",
                Int32.Parse(this.LevelsBarRec.X.ToString()) + 413,
                Int32.Parse(this.LevelsBarRec.Y.ToString()) + 59,
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
            spriteBatch.Draw(this.ItemsBg, this.ItemsBgRec, Color.White);
            spriteBatch.Draw(this.LevelsBar, this.LevelsBarRec, Color.White);
            spriteBatch.Draw(this.ItemsSlots, this.ItemsSlotsRec, Color.White);
            base.Draw(spriteBatch);
        }

        #endregion
    }
}
