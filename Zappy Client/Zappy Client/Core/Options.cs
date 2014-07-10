using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Options.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 10/07/2014 17:35:27
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class OptionVal
    {
        #region SINGLETON

        private static Object objLock = new Object();
        private static OptionVal instance = null;
        public static OptionVal Instance
        {
            get
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new OptionVal();
                    }
                    return instance;
                }
            }
        }

        #endregion
        
        #region FIELDS

        public Boolean ShowGrid { get; set; }

        public Single VolumeSound { get; set; }

        public Single VolumeEffects { get; set; }

        #endregion

        #region CONSTRUTORS

        /// <summary>
        /// Creates the options instance
        /// </summary>
        public OptionVal()
        {
            this.ShowGrid = false;
            this.VolumeEffects = 1f;
            this.VolumeSound = 1f;
        }

        #endregion
    }
}
