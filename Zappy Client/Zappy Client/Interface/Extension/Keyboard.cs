using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Keyboard.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 23/05/2014 15:42:09
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public static class KeyboardExt
    {
        private static KeyboardState CurrentState { get; set; }
        private static KeyboardState LastState { get; set; }

        /// <summary>
        /// Update the Keyboard
        /// </summary>
        /// <param name="keyboard"></param>
        public static void Update(this KeyboardState keyboard)
        {
            LastState = CurrentState;
            CurrentState = Keyboard.GetState();
        }

        public static Boolean IsKeyTaped(this KeyboardState keyboard, Keys key)
        {
            return LastState.IsKeyDown(key) == true && CurrentState.IsKeyUp(key) == true;
        }
    }
}
