using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * ScreenManager.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 18/06/2014 11:41:33
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class ScreenManager
    {
        #region FIELDS

        private Dictionary<String, AScreen> Screens { get; set; }

        internal Zappy GameInstance { get; set; }

        public AScreen CurrentScreen { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize the ScreenManager
        /// </summary>
        public ScreenManager(Zappy instance)
        {
            this.GameInstance = instance;
            this.Screens = new Dictionary<String, AScreen>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Add a screen with his name
        /// </summary>
        /// <param name="screenName">Screen name</param>
        /// <param name="screen">Screen object to add</param>
        private void Add(String screenName, AScreen screen)
        {
            if (this.Screens.ContainsKey(screenName) == true)
            {
                throw new ScreenAlreadyExistException();
            }
            screen.ScreenManagerInstance = this;
            if (screen.Initialize() == false)
            {
                throw new ScreenInitializationFailedException();
            }
            this.Screens.Add(screenName, screen);
        }

        /// <summary>
        /// Get the screen by name
        /// </summary>
        /// <param name="screenName">Screen name</param>
        /// <returns>Screen</returns>
        private AScreen Get(String screenName)
        {
            if (this.Screens.ContainsKey(screenName) == false)
            {
                return null;
            }
            return this.Screens[screenName];
        }

        /// <summary>
        /// Set the current screen
        /// </summary>
        /// <param name="screenName">Screen Name</param>
        public void SetCurrentScreen(String screenName)
        {
            if (this.Screens.ContainsKey(screenName) == true)
            {
                if (this.CurrentScreen != null)
                {
                    this.CurrentScreen.OnChangeScreen();
                }
                this.CurrentScreen = this.Screens[screenName];
            }
            else
            {
                throw new Exception("Cannot find " + screenName + " screen...");
            }
        }

        /// <summary>
        /// Update the current screen
        /// </summary>
        public void Update()
        {
            if (this.CurrentScreen != null)
            {
                this.CurrentScreen.Update();
            }
        }

        /// <summary>
        /// Draw the current screen
        /// </summary>
        public void Draw()
        {
            if (this.CurrentScreen != null)
            {
                this.CurrentScreen.Draw();
            }
        }

        public AScreen this[String name]
        {
            get
            {
                return this.Get(name);
            }
            set
            {
                this.Add(name, value);
            }
        }

        #endregion
    }
}
