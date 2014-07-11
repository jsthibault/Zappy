using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;
using Zappy_Client.Core._2DEngine;

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

        // Items count
        private Label Phiras { get; set; }
        private Label Linemate { get; set; }
        private Label Deraumere { get; set; }
        private Label Sibur { get; set; }
        private Label Mendiane { get; set; }
        private Label Thystame { get; set; }

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
            this.LevelsBar = new ImageBox(this.Engine, "LevelBar", Bar, Zappy.Width / 2 - Bar.Width / 2 - 130, Zappy.Height - Bar.Height);
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
                this.Levels[i].Visible = false;
                this.AddControl(this.Levels[i]);
            }

            // Loading and initializing dynamic items
            this.Food = new ProgressBar(this.Engine, "Food",
                this.LevelsBar.Rectangle.X + 413,
                this.LevelsBar.Rectangle.Y + 31,
                131, ProgressBarColor.Green, 0);
            this.Xp = new ProgressBar(this.Engine, "Xp",
                this.LevelsBar.Rectangle.X + 413,
                this.LevelsBar.Rectangle.Y + 45,
                131, ProgressBarColor.Blue, 0);
            this.Cast = new ProgressBar(this.Engine, "Cast",
                this.LevelsBar.Rectangle.X + 413,
                this.LevelsBar.Rectangle.Y + 59,
                131, ProgressBarColor.Red, 0);
            this.AddControl(this.Food);
            this.AddControl(this.Xp);
            this.AddControl(this.Cast);

            
            // Loading Items count
            this.Phiras = new Label(this.Engine, "LabelPhiras", this.LevelsBar.Rectangle.X + 623, this.LevelsBar.Rectangle.Y - 53, "0", "TrebuchetMSBold");
            this.AddControl(this.Phiras);
            this.Sibur = new Label(this.Engine, "LabelSibur", this.LevelsBar.Rectangle.X + 668, this.LevelsBar.Rectangle.Y - 28, "0", "TrebuchetMSBold");
            this.AddControl(this.Sibur);
            this.Mendiane = new Label(this.Engine, "LabelMendiane", this.LevelsBar.Rectangle.X + 668, this.LevelsBar.Rectangle.Y + 23, "0", "TrebuchetMSBold");
            this.AddControl(this.Mendiane);
            this.Thystame = new Label(this.Engine, "LabelThystame", this.LevelsBar.Rectangle.X + 623, this.LevelsBar.Rectangle.Y + 49, "0", "TrebuchetMSBold");
            this.AddControl(this.Thystame);
            this.Deraumere = new Label(this.Engine, "LabelDeraumere", this.LevelsBar.Rectangle.X + 578, this.LevelsBar.Rectangle.Y + 23, "0", "TrebuchetMSBold");
            this.AddControl(this.Deraumere);
            this.Linemate = new Label(this.Engine, "LabelSibur", this.LevelsBar.Rectangle.X + 578, this.LevelsBar.Rectangle.Y - 28, "0", "TrebuchetMSBold");
            this.AddControl(this.Linemate);
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
        /// Clear all items of the object
        /// </summary>
        public override void Clear()
        {
            this.Cast.Value = 0;
            this.Food.Value = 0;
            this.Xp.Value = 0;
            this.Thystame.Text = "0";
            this.Sibur.Text = "0";
            this.Mendiane.Text = "0";
            this.Deraumere.Text = "0";
            this.Linemate.Text = "0";
            this.Phiras.Text = "0";
            this.SetLevel(0);
        }

        /// <summary>
        /// Draw the Inventory window
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            for (Int32 i = 0; i < 8; i++)
            {
                spriteBatch.Draw(this.Levels[i].Texture, this.Levels[i].Position, GetOffset(this.Levels[i]), Color.White);
            }
        }

        public void UpdateInfos(Character character)
        {
            this.updateControl<Label>("LabelPhiras", character.Items[(int)ItemType.PHIRAS]);
            this.updateControl<Label>("LabelSibur", character.Items[(int)ItemType.SIBUR]);
            this.updateControl<Label>("LabelMendiane", character.Items[(int)ItemType.MENDIANE]);
            this.updateControl<Label>("LabelThystame", character.Items[(int)ItemType.THYSTAME]);
            this.updateControl<Label>("LabelMendiane", character.Items[(int)ItemType.MENDIANE]);
            this.updateControl<Label>("LabelSibur", character.Items[(int)ItemType.SIBUR]);
            this.updateControl<ProgressBar>("Food", character.Items[(int)ItemType.FOOD]);
            this.SetLevel(character.Level);
        }

        public void SetLevel(Int32 level)
        {
            for (Int32 i = 0; i < 8; i++)
            {
                this.Levels[i].State = ControlState.Normal;
            }
            for (Int32 i = 0; i < level; i++)
            {
                this.Levels[i].State = ControlState.Hover;
            }
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
