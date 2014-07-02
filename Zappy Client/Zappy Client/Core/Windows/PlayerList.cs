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
    public class WndPlayerList : Window
    {
        #region FIELDS

        private ListBox Players { get; set; }

        private Button ShowInventory { get; set; }

        #endregion

        #region CONSTRUCTORS

        public WndPlayerList(UI engine)
            : base(engine, "PlayerList", 50, 100, 250, 330, "Player List")
        {
            this.Initialize();
        }

        #endregion

        #region METHODS

        public override void Initialize()
        {
            this.CloseButton = false;
            this.Players = new ListBox(this.Engine, "PlayerList", 15, 30, 220, 250);
            this.Players.AddItem(new ListBoxItem("gomesp_f", null));
            this.Players.AddItem(new ListBoxItem("ouache_s", null));
            this.Players.AddItem(new ListBoxItem("lefloc_l", null));
            this.Players.AddItem(new ListBoxItem("canque_r", null));
            this.Players.AddItem(new ListBoxItem("drain_a", null));
            this.Players.AddItem(new ListBoxItem("thibau_j", null));
            this.AddControl(this.Players);

            this.ShowInventory = new Button(this.Engine, "ShowInventoryButton", 25, 290, 200, 0, "Show Inventory");
            this.ShowInventory.OnClick += ShowInventory_OnClick;
            this.AddControl(this.ShowInventory);
            base.Initialize();
        }

        private void ShowInventory_OnClick(object sender)
        {
            System.Windows.Forms.MessageBox.Show("Hey du calme ! C'est pas encore au point. Mais tu veux voir l'inventaire de " + this.Players.SelectedItem.ItemText);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        #endregion
    }
}
