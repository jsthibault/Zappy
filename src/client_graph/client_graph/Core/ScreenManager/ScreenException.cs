using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * ScreenException.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 18/06/2014 17:11:05
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    /// <summary>
    /// Throw the exception that the screen already exists
    /// </summary>
    public class ScreenAlreadyExistException : Exception
    {
        public ScreenAlreadyExistException()
            : base("Screen already exists") { }
    }

    /// <summary>
    /// Throw the exception when the screen initialization failed
    /// </summary>
    public class ScreenInitializationFailedException : Exception
    {
        public ScreenInitializationFailedException()
            : base("An error occured during the screen initialization.") { }
    }
}
