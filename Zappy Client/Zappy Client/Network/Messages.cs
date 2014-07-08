using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Messages.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 05/07/2014 17:19:20
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client
{
    public partial class Network
    {
        private delegate Boolean CmdFunction(List<String> items);

        private Dictionary<String, CmdFunction> AnswerFunctions;
        private Dictionary<String, CmdFunction> AskFunctions;

        /// <summary>
        /// Initialize all messages
        /// </summary>
        private void InitializeMessages()
        {
            this.AnswerFunctions = new Dictionary<String, CmdFunction>()
            {
                {"msz", Network.Instance.AnswerMsz},
                {"bct", Network.Instance.AnswerBct},
                {"tna", Network.Instance.AnswerTna},
                {"pnw", Network.Instance.AnswerPnw},
                {"ppo", Network.Instance.AnswerPpo},
                {"plv", Network.Instance.AnswerPlv},
                {"pin", Network.Instance.AnswerPin},
                {"pex", Network.Instance.AnswerPex},
                {"pbc", Network.Instance.AnswerPbc},
                {"pic", Network.Instance.AnswerPic},
                {"pie", Network.Instance.AnswerPie},
                {"pfk", Network.Instance.AnswerPfk},
                {"pdr", Network.Instance.AnswerPdr},
                {"pgt", Network.Instance.AnswerPgt},
                {"pdi", Network.Instance.AnswerPdi},
                {"enw", Network.Instance.AnswerEnw},
                {"eht", Network.Instance.AnswerEht},
                {"ebo", Network.Instance.AnswerEbo},
                {"edi", Network.Instance.AnswerEdi},
                {"sgt", Network.Instance.AnswerSgt},
                {"seg", Network.Instance.AnswerSeg},
                {"smg", Network.Instance.AnswerSmg},
                {"suc", Network.Instance.AnswerSuc},
                {"sbp", Network.Instance.AnswerSbp},
                {"BIENVENUE", Network.Instance.AnswerWelcome}
            };
            this.AskFunctions = new Dictionary<String, CmdFunction>()
            {
                {"msz", Network.Instance.AskMsz},
                {"bct", Network.Instance.AskBct},
                {"mct", Network.Instance.AskMct},
                {"tna", Network.Instance.AskTna},
                {"ppo", Network.Instance.AskPpo},
                {"plv", Network.Instance.AskPlv},
                {"pin", Network.Instance.AskPin},
                {"sgt", Network.Instance.AskSgt},
                {"sst", Network.Instance.AskSst}
            };
        }
    }
}
