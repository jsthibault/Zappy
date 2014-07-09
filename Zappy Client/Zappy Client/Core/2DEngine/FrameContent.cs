﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Item.cs - file description
 * 
 * Version: 1.0
 * Author: ouache_s
 * Created: 08/07/2014 16:16:24
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public class FrameContent
    {
        #region FIELDS

        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        private Dictionary<ItemType, Int32> Content { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor, need positions in X and Y
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public FrameContent(Int32 X, Int32 Y)
        {
            this.X = X;
            this.Y = Y;
            this.Content = new Dictionary<ItemType, Int32>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Add item 'type' 'value' times to its corresponding value
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void AddItem(ItemType type, Int32 value)
        {
            if (this.Content.ContainsKey(type))
            {
                this.Content[type] += value;
            }
            else
            {
                this.Content[type] = value;
            }
        }

        /// <summary>
        /// Get 'type''s item count
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Int32 GetItemValue(ItemType type)
        {
            if (this.Content.ContainsKey(type))
            {
                return (this.Content[type]);
            }
            return (0);
        }

        /// <summary>
        /// Check if the frame contains items
        /// </summary>
        /// <returns></returns>
        public Boolean HasItems()
        {
            for (Int32 i = 0; i < (Int32)ItemType.THYSTAME; ++i)
            {
                if (this.GetItemValue((ItemType)i) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get item count on frame
        /// </summary>
        /// <returns></returns>
        public Int32 GetItemCount()
        {
            Int32 _count = 0;

            for (Int32 i = 0; i < (Int32)ItemType.THYSTAME; ++i)
            {
                if (this.GetItemValue((ItemType)i) > 0)
                {
                    ++_count;
                }
            }
            return _count;
        }

        #endregion

    }

    public enum ItemType
    {
        FOOD = 0,
        LINEMATE,
        DERAUMERE,
        SIBUR,
        MENDIANE,
        PHIRAS,
        THYSTAME
    }
}
