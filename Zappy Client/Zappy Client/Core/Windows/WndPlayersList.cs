using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;

/*--------------------------------------------------------
 * PlayerList.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 25/06/2014 19:02:43
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class WndPlayersList : Window
    {
        #region FIELDS

        private ListBox Players { get; set; }

        private Button ShowInventory { get; set; }

        #endregion

        #region CONSTRUCTORS

        public WndPlayersList(UI engine)
            : base(engine, "PlayersListWindow", 50, 460, 250, 330, "Players List")
        {
            this.Initialize();
        }

        #endregion

        #region METHODS

        public override void Initialize()
        {
            this.CloseButton = false;
            this.Players = new ListBox(this.Engine, "PlayersList", 15, 30, 220, 250);
            //this.Players.AddItem(new ListBoxItem("gomesp_f", null));
            //this.Players.AddItem(new ListBoxItem("ouache_s", null));
            //this.Players.AddItem(new ListBoxItem("lefloc_l", null));
            //this.Players.AddItem(new ListBoxItem("canque_r", null));
            //this.Players.AddItem(new ListBoxItem("drain_a", null));
            //this.Players.AddItem(new ListBoxItem("thibau_j", null));
            this.AddControl(this.Players);

            this.ShowInventory = new Button(this.Engine, "ShowInventoryButton", 25, 290, 200, 0, "Select a player");
            this.ShowInventory.Enabled = false;
            this.ShowInventory.OnClick += ShowInventory_OnClick;
            this.Players.OnSelectedItem += Players_OnSelectedItem;
            this.AddControl(this.ShowInventory);
            base.Initialize();
        }

        /// <summary>
        /// Clear all items of the object
        /// </summary>
        public override void Clear()
        {
            this.Players.Items.Clear();
        }

        void Players_OnSelectedItem(object sender)
        {
            this.ShowInventory.Enabled = true;
            this.ShowInventory.Text = "Show " + (sender as ListBox).SelectedItem.ItemText + "'s inventory";
        }

        private void ShowInventory_OnClick(object sender)
        {
            Inventory inventory = this.Engine.GetContainer("Inventory") as Inventory;

            inventory.SetLevel(1, ControlState.Hover);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void AddItem(String name, Object obj)
        {
            this.Players.AddItem(new ListBoxItem(name, obj));
        }

        #endregion
    }
}
