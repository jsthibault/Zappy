using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer bct from server
        /// Get X/Y block content from map
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerBct(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer tna from server
        /// Get team name
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerTna(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer pnw from server
        /// New player connected
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPnw(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer ppo from server
        /// Get position of a player
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPpo(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer plv from server
        /// Get level of a player
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPlv(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer pin from server
        /// Get player inventory
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPin(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer pex from server
        /// Player kicked from server
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPex(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer pbc from server
        /// Player did a broadcast
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPbc(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer pic from server
        /// player did a cast for all other player of his place
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPic(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer pie from server
        /// Cast of a player in a place ended
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPie(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer pfk from server
        /// Player got an egg
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPfk(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer pdr from server
        /// Player drop a ressource
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPdr(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer pgt from server
        /// Player picked up a ressource
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPgt(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer pdi from server
        /// Player died of hungry
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerPdi(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer enw from server
        /// Player put an egg in a place
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerEnw(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer eht from server
        /// Egg hatched
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerEht(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer ebo from server
        /// A player connected for egg
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerEbo(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer edi from server
        /// Hatched egg died of hungry
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerEdi(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer sgt from server
        /// Get server's time unity
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerSgt(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer seg from server
        /// End of game, given team won
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerSeg(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer smg from server
        /// Message from server
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerSmg(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer suc from server
        /// Unknown command
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerSuc(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }

        /// <summary>
        /// Answer sbp from server
        /// Bad parameter for command
        /// </summary>
        /// <param name="items">List of command's items</param>
        /// <returns>true if success, false in the other case</returns>
        private Boolean AnswerSbp(List<String> items)
        {
            foreach (String item in items)
            {
                Console.Write(item + " ");
            }
            return false;
        }
    }
}
