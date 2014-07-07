using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * ClientFunctions.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 05/07/2014 17:16:39
 * 
 * Notes:
 * Clients messages goes here
 * -------------------------------------------------------*/

namespace Zappy_Client
{
    public partial class Network
    {
        /// <summary>
        /// Ask Msz from server
        /// Ask map size
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AskMsz(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Ask bct from server
        /// Ask place content from server's map
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AskBct(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Ask mct from server
        /// Get map content
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AskMct(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Ask tna from server
        /// Ask teams names
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AskTna(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Ask ppo from server
        /// Ask player's position
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AskPpo(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Ask plv from server
        /// Ask player's level
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AskPlv(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Ask pin from server
        /// Ask player's inventory
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AskPin(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Ask sgt from server
        /// Ask current server's time unity
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AskSgt(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Ask sst from server
        /// Ask to change server's time unity
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AskSst(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }
    }
}
