using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

/*--------------------------------------------------------
 * Parser.cs - file description
 * 
 * Version: 1.0
 * Author: ouache_s
 * Created: 14/05/2014 11:39:33
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client
{
    static public class Parser
    {
        #region FIELDS
        static List<Regex> AuthorizedItems;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor
        /// Set default Zappy commands Regex in AuthorizedItems attribute.
        /// </summary>
        static Parser()
        {
            AuthorizedItems = new List<Regex>();
            AuthorizedItems.Add(new Regex("^msz [\\d]* [\\d]*\n$"));
            AuthorizedItems.Add(new Regex("^bct( \\d*){8}\n$"));
            AuthorizedItems.Add(new Regex("^tna \\w*\\n$"));
            AuthorizedItems.Add(new Regex("^pnw #\\d*( \\d*){2} [N|O|S|E]:\\d \\d* \\w*\\n$"));
            AuthorizedItems.Add(new Regex("^ppo #\\d*( \\d*){2} [N|O|S|E]:\\d\\n$"));
            AuthorizedItems.Add(new Regex("^plv #\\d* \\d*\\n$"));
            AuthorizedItems.Add(new Regex("^pin #\\d*( \\d*){9}\\n$"));
            AuthorizedItems.Add(new Regex("^pex #\\d*\\n$"));
            AuthorizedItems.Add(new Regex("^pbc #\\d* .*\\n$"));
            AuthorizedItems.Add(new Regex("^smg .*\\n$"));
            AuthorizedItems.Add(new Regex("^pie( \\d*){2}[0|1]\\n$"));
            AuthorizedItems.Add(new Regex("^pfk #\\d*\\n$"));
            AuthorizedItems.Add(new Regex("^pdr #\\d* \\d*\\n$"));
            AuthorizedItems.Add(new Regex("^pgt #\\d* \\d*\\n$"));
            AuthorizedItems.Add(new Regex("^pdi #\\d*\\n$"));
            AuthorizedItems.Add(new Regex("^enw( #\\d*){2}( \\d*){2}\\n$"));
            AuthorizedItems.Add(new Regex("^eht #\\d*\\n$"));
            AuthorizedItems.Add(new Regex("^ebo #\\d*\\n$"));
            AuthorizedItems.Add(new Regex("^edi #\\d*\\n$"));
            AuthorizedItems.Add(new Regex("^sgt \\d*\\n$"));
            AuthorizedItems.Add(new Regex("^seg \\w*\\n$"));
            AuthorizedItems.Add(new Regex("^pic \\d* \\d* \\d*( #\\d{1,}){1,}\\n$"));
            AuthorizedItems.Add(new Regex("^suc\\n$"));
            AuthorizedItems.Add(new Regex("^sbp\\n$"));
        }

        #endregion

        #region METHODS

        public static List<String> GetCmdItems(String cmd)
        {
            foreach (Regex item in AuthorizedItems)
            {
                if (item.IsMatch(cmd))
                {
                    return cmd.Split(' ').ToList();
                }
            }
            return null;
        }

        #endregion
    }
}
