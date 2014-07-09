using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Team.cs - file description
 * 
 * Version: 1.0
 * Author: ouache_s
 * Created: 09/07/2014 09:54:35
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public class Team
    {

        #region FIELDS

        public String Name { get; private set; }
        public List<Character> Characters { get; private set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Simple constructor with name
        /// </summary>
        /// <param name="name"></param>
        public Team(String name)
        {
            this.Name = name;
            this.Characters = new List<Character>();
        }

        /// <summary>
        /// Constructor with name and a character
        /// </summary>
        /// <param name="name"></param>
        public Team(String name, Character character)
        {
            this.Name = name;
            this.Characters = new List<Character>();
            this.Characters.Add(character);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Get a character with its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Character GetCharacter(Int32 id)
        {
            foreach (Character character in this.Characters)
            {
                if (character.Id == id)
                {
                    return (character);
                }
            }
            throw new Exception("Cannot find player with id " + id + " in team " + this.Name);
        }

        #endregion

    }
}
