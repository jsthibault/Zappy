using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * EggManager.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 10/07/2014 18:36:28
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public partial class Map2D
    {
        /// <summary>
        /// Add an egg to the map
        /// </summary>
        /// <param name="egg"></param>
        public void AddEgg(Egg egg)
        {
            if (this.Eggs.Contains(egg) == false)
            {
                this.Eggs.Add(egg);
            }
        }

        /// <summary>
        /// Remove an egg from the map
        /// </summary>
        /// <param name="egg"></param>
        public void RemoveEgg(Egg egg)
        {
            if (this.Eggs.Contains(egg) == true)
            {
                this.Eggs.Remove(egg);
            }
        }

        /// <summary>
        /// Get an egg by name
        /// </summary>
        /// <param name="name">Egg name</param>
        /// <returns></returns>
        public Egg GetEgg(String name)
        {
            foreach (Egg egg in this.Eggs)
            {
                if (egg.Name == name)
                {
                    return egg;
                }
            }
            return null;
        }
    }
}
