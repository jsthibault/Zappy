using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * ItemManager.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 10/07/2014 18:37:36
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public partial class Map2D
    {
        /// <summary>
        /// Add an item in a frame
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="index"></param>
        public void AddItem(Int32 x, Int32 y, ItemType index)
        {
            foreach (FrameContent frame in this.Frames)
            {
                if (frame.X == x && frame.Y == y)
                {
                    frame.AddItem(index, 1);
                }
            }
        }

        /// <summary>
        /// Retrive an item from a frame
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="index"></param>
        public void RetriveItem(Int32 x, Int32 y, ItemType index)
        {
            foreach (FrameContent frame in this.Frames)
            {
                if (frame.X == x && frame.Y == y)
                {
                    frame.RetriveItem(index, 1);
                }
            }
        }

        /// <summary>
        /// Add a new item in a frame
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void AddInFrame(Int32 X, Int32 Y, ItemType type, Int32 value)
        {
            foreach (FrameContent frame in this.Frames)
            {
                if (frame.X == X && frame.Y == Y)
                {
                    frame.SetItem(type, value);
                    return;
                }
            }
            FrameContent newFrame = new FrameContent(X, Y);
            newFrame.SetItem(type, value);
            this.Frames.Add(newFrame);
        }
    }
}
