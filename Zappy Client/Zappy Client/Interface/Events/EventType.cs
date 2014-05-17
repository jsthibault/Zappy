using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * EventType.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 14/05/2014 15:25:09
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public delegate void MonoGameEventHandler(Object sender);

    public delegate void MonoGameCheckBoxEventHandler(Object sender, MonoGameCheckBoxEventArgs e);

    /// <summary>
    /// MonoGame CheckBox Event Args
    /// </summary>
    public class MonoGameCheckBoxEventArgs : EventArgs
    {
        public Boolean State { get; set; }

        public MonoGameCheckBoxEventArgs(Boolean state)
        {
            this.State = state;
        }
    }
}
