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
    public class WndTeamsList : Window
    {
        #region FIELDS

        public ListBox Teams { get; private set; }

        private Button ShowInventory { get; set; }

        #endregion

        #region CONSTRUCTORS

        public WndTeamsList(UI engine)
            : base(engine, "TeamsListWindow", 50, 100, 250, 330, "Teams List")
        {
            this.Initialize();
        }

        #endregion

        #region METHODS

        public override void Initialize()
        {
            this.CloseButton = false;
            this.Teams = new ListBox(this.Engine, "TeamsList", 15, 30, 220, 250);
            this.AddControl(this.Teams);

            this.ShowInventory = new Button(this.Engine, "ShowInventoryButton", 25, 290, 200, 0, "Select a team");
            this.ShowInventory.Enabled = false;
            this.ShowInventory.OnClick += ShowInventory_OnClick;
            this.Teams.OnSelectedItem += Players_OnSelectedItem;
            this.AddControl(this.ShowInventory);
            base.Initialize();
        }

        /// <summary>
        /// Clear all items of the object
        /// </summary>
        public override void Clear()
        {
            this.Teams.Items.Clear();
        }

        void Players_OnSelectedItem(object sender)
        {
            this.ShowInventory.Enabled = true;
            this.ShowInventory.Text = "Show " + (sender as ListBox).SelectedItem.ItemText + "'s members";
            this.Engine.GetContainer("PlayersListWindow").Text = (sender as ListBox).SelectedItem.ItemText + "'s players list";
        }

        private void ShowInventory_OnClick(object sender)
        {
            (this.Engine.GetContainer("PlayersListWindow") as WndPlayersList).Clear();
            foreach (Team team in (Zappy.Instance.ScreenManager["GameScreen"] as GameScreen).Map.Teams.Values)
            {
                if ((this.Engine.GetContainer("TeamsListWindow") as WndTeamsList).Teams.SelectedItem.ItemText == team.Name)
                {
                    foreach (Character character in team.Characters)
                    {
                        (this.Engine.GetContainer("PlayersListWindow") as WndPlayersList).AddItem(character.Id.ToString(), character);
                    }
                }
            }
            this.Engine.GetContainer("PlayersListWindow").Visible = true;
            this.Engine.GetContainer("PlayersListWindow").SetFocus();
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
            this.Teams.AddItem(new ListBoxItem(name, obj));
        }

        #endregion
    }
}
