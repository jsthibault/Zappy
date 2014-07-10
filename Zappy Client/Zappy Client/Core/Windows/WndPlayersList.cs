using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;
using Zappy_Client.Core._2DEngine;

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

        private static Int32 Count = 0;

        private Character LastPlayer { get; set; }

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
            this.LastPlayer = null;
            this.Players = new ListBox(this.Engine, "PlayersList", 15, 30, 220, 250);
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
            if ((this.Players.SelectedItem.ItemObject as Character) != this.LastPlayer)
            {
                Character player = this.Players.SelectedItem.ItemObject as Character;
                this.LastPlayer = player;
                Network.Instance.SendMessage("pin " + player.Id.ToString() + "\n");
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Count >= 130)
            {
                if (LastPlayer != null)
                {
                    Network.Instance.SendMessage("pin " + LastPlayer.Id.ToString() + "\n");
                }
                Count = 0;
            }
            Count++;
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
