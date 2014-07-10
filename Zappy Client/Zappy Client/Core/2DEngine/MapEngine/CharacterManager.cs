using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * CharacterManager.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 10/07/2014 18:35:09
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public partial class Map2D
    {
        /// <summary>
        /// Add a new player on the map
        /// </summary>
        /// <param name="character">Character to add</param>
        /// <param name="team">Character's team</param>
        public void AddCharacter(String team, Character character)
        {
            if (this.Teams.ContainsKey(team) == false)
            {
                throw new Exception("Team " + team + " doesn't exist");
            }
            if (this.Teams[team].Characters.Contains(character) == false)
            {
                character.Initialize(this.CastAnim, this.DeadAnim);
                character.Texture = this.Character;
                this.Teams[team].Characters.Add(character);
                if ((Zappy.instance.InterfaceEngine.GetContainer("TeamsListWindow") as WndTeamsList).Teams.SelectedItem != null
                    && (Zappy.instance.InterfaceEngine.GetContainer("TeamsListWindow") as WndTeamsList).Teams.SelectedItem.ItemText == team)
                {
                    (Zappy.instance.InterfaceEngine.GetContainer("PlayersListWindow") as WndPlayersList).AddItem(character.Id.ToString(), character);
                }
            }
        }

        /// <summary>
        /// Remove a character of the map
        /// </summary>
        /// <param name="name">Character name</param>
        public void RemoveCharacter(String team, Int32 id)
        {
            if (this.Teams.ContainsKey(team) == false)
            {
                throw new Exception("Team " + team + " doesn't exist");
            }
            foreach (Character character in this.Teams[team].Characters)
            {
                if (character.Id == id)
                {
                    this.Teams[team].Characters.Remove(character);
                    break;
                }
            }
        }

        /// <summary>
        /// Remove a character of the map
        /// </summary>
        /// <param name="character"></param>
        public void RemoveCharacter(Character character)
        {
            foreach (Team team in this.Teams.Values)
            {
                if (team.Characters.Contains(character))
                {
                    team.Characters.Remove(character);
                    return;
                }
            }
        }
    }
}
