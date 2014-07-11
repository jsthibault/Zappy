using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Core;
using Zappy_Client.Core._2DEngine;
using Zappy_Client.Core.Windows;
using Zappy_Client.Interface;

/*--------------------------------------------------------
 * ServerFunctions.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 05/07/2014 17:21:51
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client
{
    public partial class Network
    {
        /// <summary>
        /// Answer Msz from server
        /// Get map size
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerMsz(List<String> items)
        {
            Game.InitializeMap(Int32.Parse(items[1]), Int32.Parse(items[2]));
            (Zappy.Instance.InterfaceEngine.GetContainer("Panel").GetControl("DisconnectButton") as Button).Enabled = true;
            Zappy.Instance.ScreenManager.SetCurrentScreen("GameScreen");
            return true;
        }

        /// <summary>
        /// Answer bct from server
        /// Get X/Y block content from map
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerBct(List<String> items)
        {
            Game.Map.AddInFrame(Int32.Parse(items[1]), Int32.Parse(items[2]), ItemType.FOOD, Int32.Parse(items[3]));
            Game.Map.AddInFrame(Int32.Parse(items[1]), Int32.Parse(items[2]), ItemType.LINEMATE, Int32.Parse(items[4]));
            Game.Map.AddInFrame(Int32.Parse(items[1]), Int32.Parse(items[2]), ItemType.DERAUMERE, Int32.Parse(items[5]));
            Game.Map.AddInFrame(Int32.Parse(items[1]), Int32.Parse(items[2]), ItemType.SIBUR, Int32.Parse(items[6]));
            Game.Map.AddInFrame(Int32.Parse(items[1]), Int32.Parse(items[2]), ItemType.MENDIANE, Int32.Parse(items[7]));
            Game.Map.AddInFrame(Int32.Parse(items[1]), Int32.Parse(items[2]), ItemType.PHIRAS, Int32.Parse(items[8]));
            Game.Map.AddInFrame(Int32.Parse(items[1]), Int32.Parse(items[2]), ItemType.THYSTAME, Int32.Parse(items[9]));
            return true;
        }

        /// <summary>
        /// Answer tna from server
        /// Get team name
        /// tna N
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerTna(List<String> items)
        {
            if (Game.Map.Teams.ContainsKey(items[1]) == false)
            {
                Game.Map.Teams[items[1]] = new Team(items[1]);
                WndTeamsList lst = (Zappy.Instance.InterfaceEngine.GetContainer("TeamsListWindow") as WndTeamsList); 
                lst.AddItem(items[1], Game.Map.Teams[items[1]]);
            }
            return true;
        }

        /// <summary>
        /// Answer pnw from server
        /// New player connected
        /// pnw #n X Y O L N
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPnw(List<String> items)
        {
            Game.Map.AddCharacter(items[6], new Character(Game.Map, Int32.Parse(items[2]), Int32.Parse(items[3]), Int32.Parse(items[1]), (Direction)Int32.Parse(items[4]), Int32.Parse(items[5])));
            return true;
        }

        /// <summary>
        /// Answer ppo from server
        /// Get position of a player
        /// ppo #n X Y O
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPpo(List<String> items)
        {
            foreach (Team team in Game.Map.Teams.Values)
            {
                foreach (Character character in team.Characters)
                {
                    if (character.Id == Int32.Parse(items[1]))
                    {
                        character.MoveTo(Int32.Parse(items[2]), Int32.Parse(items[3]), (Direction)Int32.Parse(items[4]));
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Answer plv from server
        /// Get level of a player
        /// plv #n L
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPlv(List<String> items)
        {
            foreach (Team team in Game.Map.Teams.Values)
            {
                foreach (Character character in team.Characters)
                {
                    if (character.Id == Int32.Parse(items[1]))
                    {
                        character.Level = Int32.Parse(items[2]);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Answer pin from server
        /// Get player inventory
        /// pin #n X Y q q q q q q q
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPin(List<String> items)
        {
            Inventory inventory = Zappy.Instance.InterfaceEngine.GetContainer("Inventory") as Inventory;

            foreach (Team team in Game.Map.Teams.Values)
            {
                foreach (Character character in team.Characters)
                {
                    if (character.Id == Int32.Parse(items[1]))
                    {
                        character.X = Int32.Parse(items[2]);
                        character.Y = Int32.Parse(items[3]);
                        character.Items[0] = Int32.Parse(items[4]);
                        character.Items[1] = Int32.Parse(items[5]);
                        character.Items[2] = Int32.Parse(items[6]);
                        character.Items[3] = Int32.Parse(items[7]);
                        character.Items[4] = Int32.Parse(items[8]);
                        character.Items[5] = Int32.Parse(items[9]);
                        character.Items[6] = Int32.Parse(items[10]);
                        inventory.UpdateInfos(character);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Answer pex from server
        /// Kick other players of the frame
        /// pex #n
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPex(List<String> items)
        {
            foreach (Team team in Game.Map.Teams.Values)
            {
                foreach (Character character in team.Characters)
                {
                    if (character.Id == Int32.Parse(items[1]))
                    {
                        foreach (Team teamToKick in Game.Map.Teams.Values)
                        {
                            foreach (Character characterToKick in teamToKick.Characters)
                            {
                                if (character.X == characterToKick.X && character.Y == characterToKick.Y && characterToKick != character)
                                {
                                    characterToKick.Kick();
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Answer pbc from server
        /// Player did a broadcast
        /// pbc #n M
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPbc(List<String> items)
        {
            return false;
        }

        /// <summary>
        /// Answer pic from server
        /// player did a cast for all other player of his place
        /// pic X Y L (#n -x fois-)
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPic(List<String> items)
        {
            foreach (Team team in Game.Map.Teams.Values)
            {
                foreach (Character character in team.Characters)
                {
                    if (character.X == Convert.ToInt32(items[1]) && character.Y == Convert.ToInt32(items[2]))
                    {
                        for (Int32 i = 4; i < items.Count; i++)
                        {
                            if (character.Id == Int32.Parse(items[i]))
                            {
                                character.StartCast(Int32.Parse(items[3]));
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Answer pie from server
        /// Cast of all players in a frame ended
        /// pie X Y R
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPie(List<String> items)
        {
            foreach (Team team in Game.Map.Teams.Values)
            {
                foreach (Character character in team.Characters)
                {
                    if (character.X == Int32.Parse(items[1]) && character.Y == Int32.Parse(items[2]))
                    {
                        character.EndCast(Int32.Parse(items[3]));
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Answer pfk from server
        /// Player got an egg
        /// pfk #n
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPfk(List<String> items)
        {
            return false;
        }

        /// <summary>
        /// Answer pdr from server
        /// Player drop a ressource
        /// pdr #n i
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPdr(List<String> items)
        {
            foreach (Team team in Game.Map.Teams.Values)
            {
                foreach (Character character in team.Characters)
                {
                    if (character.Id == Int32.Parse(items[1]))
                    {
                        character.DropItem(Int32.Parse(items[2]));
                        (Zappy.Instance.InterfaceEngine.GetContainer("Inventory") as Inventory).UpdateInfos(character);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Answer pgt from server
        /// Player picked up a ressource
        /// pgt #n i
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPgt(List<String> items)
        {
            foreach (Team team in Game.Map.Teams.Values)
            {
                foreach (Character character in team.Characters)
                {
                    if (character.Id == Int32.Parse(items[1]))
                    {
                        character.PickItem(Int32.Parse(items[2]));
                        Game.Map.RetriveItem(character.X, character.Y, (ItemType)Int32.Parse(items[2]));
                        (Zappy.Instance.InterfaceEngine.GetContainer("Inventory") as Inventory).UpdateInfos(character);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Answer pdi from server
        /// Player died of hungry
        /// pdi #n
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPdi(List<String> items)
        {
            foreach (Team team in Game.Map.Teams.Values)
            {
                foreach (Character character in team.Characters)
                {
                    if (character.Id == Int32.Parse(items[1]))
                    {
                        character.Die();
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Answer enw from server
        /// Player put an egg in a place
        /// enw #e #n X Y
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerEnw(List<String> items)
        {
            String _e = items[1];
            Int32 _quantity = Convert.ToInt32(items[2]);
            Int32 _x = Convert.ToInt32(items[3]);
            Int32 _y = Convert.ToInt32(items[4]);

            for (Int32 i = 0; i < _quantity; ++i)
            {
                Egg _egg = new Egg(this.Game.Map, _e, _x, _y);
                this.Game.Map.AddEgg(_egg);
            }
            return false;
        }

        /// <summary>
        /// Answer eht from server
        /// Egg hatched
        /// eht #e
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerEht(List<String> items)
        {
            String _e = items[1];
            Egg _egg = this.Game.Map.GetEgg(_e);

            if (_egg != null)
            {
                _egg.State = EggState.Open;
            }
            return false;
        }

        /// <summary>
        /// Answer ebo from server
        /// A player connected for egg
        /// ebo #e
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerEbo(List<String> items)
        {
            String _e = items[1];
            Egg _egg = this.Game.Map.GetEgg(_e);

            if (_egg != null)
            {
                _egg.HasCharacter = true;
                _egg.State = EggState.Full;
            }
            return false;
        }

        /// <summary>
        /// Answer edi from server
        /// Hatched egg died of hungry
        /// edi #e
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerEdi(List<String> items)
        {
            String _e = items[1];
            Egg _egg = this.Game.Map.GetEgg(_e);

            if (_egg != null)
            {
                _egg.State = EggState.Dead;
            }
            return false;
        }

        /// <summary>
        /// Answer sgt from server
        /// Get server's time unity
        /// sgt T
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerSgt(List<String> items)
        {
            Zappy.Instance.TimeUnit = Int32.Parse(items[1]);
            return true;
        }

        /// <summary>
        /// Answer seg from server
        /// End of game, given team won
        /// seg N
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerSeg(List<String> items)
        {
            (Zappy.Instance.InterfaceEngine.GetContainer("Popup") as Popup).Show("Team '" + items[1] + "' wins !");
            return false;
        }

        /// <summary>
        /// Answer smg from server
        /// Message from server
        /// smg M
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerSmg(List<String> items)
        {
            return false;
        }

        /// <summary>
        /// Answer suc from server
        /// Unknown command
        /// suc
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerSuc(List<String> items)
        {
            return false;
        }

        /// <summary>
        /// Answer sbp from server
        /// Bad parameter for command
        /// sbp
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerSbp(List<String> items)
        {
            return false;
        }

        /// <summary>
        /// Answer welcome from server
        /// First command sent by server to trust the connection
        /// BONJOUR
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private Boolean AnswerWelcome(List<String> items)
        {
            this.SendMessage("GRAPHIC");
            return true;
        }
    }
}
