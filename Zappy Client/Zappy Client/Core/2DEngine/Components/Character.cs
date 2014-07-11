﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;

/*--------------------------------------------------------
 * Character.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 24/06/2014 17:31:06
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public class Character
    {
        #region FIELDS

        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public Int32 Level { get; set; }

        public Boolean Dead { get; set; }

        public Int32 []Items;

        public Texture2D Texture { get; set; }

        public Direction Direction { get; set; }

        public Map2D Map { get; set; }

        public Int32 Id { get; private set; }

        public Int32 CurrentCast { get; private set; }

        /* Animation */
        private Rectangle HitBox;

        private Int32 Timer { get; set; }
        private readonly Int32 AnimationSpeed = 10;
        private readonly Int32 MovingValue = 2;
        private Boolean Animation { get; set; }

        private Int32 FrameColumn { get; set; }
        private Int32 FrameLine { get; set; }

        private Int32 MoveVal { get; set; }
        private Boolean Moving { get; set; }

        private Animation[] Animations { get; set; }

        private Boolean Casting { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a new Character at position 0, 0
        /// </summary>
        /// <param name="map">Map reference</param>
        public Character(Map2D map)
        {
            this.Map = map;
            this.X = 0;
            this.Y = 0;
            this.Level = 0;
            this.Items = new Int32[7];
            this.Casting = false;
            this.Dead = false;
        }

        /// <summary>
        /// Creates a new Character with his position
        /// </summary>
        /// <param name="map">Map reference</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public Character(Map2D map, Int32 x, Int32 y)
        {
            this.Map = map;
            this.X = x;
            this.Y = y;
            this.Level = 0;
            this.Items = new Int32[7];
            this.Casting = false;
            this.Dead = false;
        }

        /// <summary>
        /// Creates a new Character with his position and Name
        /// </summary>
        /// <param name="map">Map reference</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="name">Player name</param>
        public Character(Map2D map, Int32 x, Int32 y, Int32 id, Direction orientation, Int32 level)
        {
            this.Map = map;
            this.X = x;
            this.Y = y;
            this.Id = id;
            this.Direction = orientation;
            this.Level = level;
            this.Items = new Int32[7];
            this.Casting = false;
            this.Dead = false;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the character properties
        /// </summary>
        public void Initialize()
        {
            this.HitBox = new Rectangle(this.X * 32, this.Y * 32, 64, 64);
            this.ChangeDirection(this.Direction);
            this.Timer = 0;
            this.CurrentCast = 0;
            this.Texture = TextureManager.Instance["Chocobo"];
            this.Animation = true;
            this.Animations = new Animation[2];
            this.Animations[(Int32)AnimationType.Cast] = new Animation(4, 5, TextureManager.Instance["Cast"], 3);
            this.Animations[(Int32)AnimationType.Die] = new Animation(8, 5, TextureManager.Instance["Die"], 3);
        }

        /// <summary>
        /// Update the character
        /// </summary>
        public void Update()
        {
            if (this.Casting == true && this.Animations[(Int32)AnimationType.Cast].Playing == false)
            {
                this.PlayAnimation(AnimationType.Cast);
            }
            if (this.Dead == true && this.Animations[(Int32)AnimationType.Die].Playing == false)
            {
                WndTeamsList window = Zappy.Instance.InterfaceEngine.GetContainer("TeamsListWindow") as WndTeamsList;
                Map.RemoveCharacter(this);
                window.UpdatePlayersContent();
                return;
            }
            this.Animations[(Int32)AnimationType.Cast].Update();
            this.Animations[(Int32)AnimationType.Die].Update();
            if (this.Moving == true)
            {
                switch (this.Direction)
                {
                    case Direction.Up:
                        this.FrameLine = 4;
                        this.HitBox.Y -= this.MovingValue;
                        this.MoveVal += this.MovingValue;
                        if (this.MoveVal > 32 - 1)
                        {
                            --this.Y;
                            this.Moving = false;
                        }
                        break;
                    case Direction.Down:
                        this.FrameLine = 1;
                        this.HitBox.Y += this.MovingValue;
                        this.MoveVal += this.MovingValue;
                        if (this.MoveVal > 32 - 1)
                        {
                            ++this.Y;
                            this.Moving = false;
                        }
                        break;
                    case Direction.Left:
                        this.FrameLine = 2;
                        this.HitBox.X -= this.MovingValue;
                        this.MoveVal += this.MovingValue;
                        if (this.MoveVal > 32 - 1)
                        {
                            --this.X;
                            this.Moving = false;
                        }
                        break;
                    case Direction.Right:
                        this.FrameLine = 3;
                        this.HitBox.X += this.MovingValue;
                        this.MoveVal += this.MovingValue;
                        if (this.MoveVal > 32 - 1)
                        {
                            ++this.X;
                            this.Moving = false;
                        }
                        break;
                }
            }
            else
            {
                this.FrameColumn = 2;
                this.Timer = 0;
                this.MoveVal = 0;
            }
            this.Animate();
        }

        /// <summary>
        /// Draw the character
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            this.Animations[(Int32)AnimationType.Cast].Draw(spriteBatch);
            this.Animations[(Int32)AnimationType.Die].Draw(spriteBatch);
            spriteBatch.Draw(this.Texture, new Rectangle(this.Map.OffsetX +  this.HitBox.X, this.Map.OffsetY + this.HitBox.Y, 32, 32),
                new Rectangle((this.FrameColumn - 1) * 32, (this.FrameLine - 1) * 32, 32, 32),
                Color.White);
        }

        /// <summary>
        /// Move the character
        /// </summary>
        /// <param name="direction">Direction</param>
        public void Move(Direction direction)
        {
            this.Direction = direction;
            this.Moving = true;
        }

        /// <summary>
        /// Change the character's direction
        /// </summary>
        /// <param name="direction"></param>
        public void ChangeDirection(Direction direction)
        {
            this.Direction = direction;
            switch (this.Direction)
            {
                case Direction.Up: this.FrameLine = 4; break;
                case Direction.Down: this.FrameLine = 1; break;
                case Direction.Left: this.FrameLine = 2; break;
                case Direction.Right: this.FrameLine = 3; break;
            }
            this.FrameColumn = 1;
        }

        /// <summary>
        /// Drop item animation
        /// </summary>
        /// <param name="index"></param>
        public void DropItem(Int32 index)
        {
            this.Items[index] -= 1;
        }

        /// <summary>
        /// pick item animation
        /// </summary>
        /// <param name="index"></param>
        public void PickItem(Int32 index)
        {
            this.Items[index] += 1;
        }

        /// <summary>
        /// Animation of die
        /// </summary>
        public void Die()
        {
            this.Dead = true;
            this.PlayAnimation(AnimationType.Die);
        }

        /// <summary>
        /// Animation of cast start
        /// </summary>
        public void StartCast(Int32 futureLevel)
        {
            this.Casting = true;
            this.PlayAnimation(AnimationType.Cast);
        }

        /// <summary>
        /// Animation of cast end
        /// </summary>
        public void EndCast(Int32 state)
        {
            this.Casting = false;
            this.CurrentCast = 0;
        }

        /// <summary>
        /// Animate the character
        /// </summary>
        public void Animate()
        {
            this.Timer++;
            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                if (this.Animation)
                {
                    this.FrameColumn++;
                    if (this.FrameColumn > 3)
                    {
                        this.FrameColumn = 2;
                        this.Animation = false;
                    }
                }
                else
                {
                    this.FrameColumn--;
                    if (this.FrameColumn < 1)
                    {
                        this.FrameColumn = 2;
                        this.Animation = true;
                    }
                }
            }
        }

        private void PlayAnimation(AnimationType type)
        {
            this.Animations[(Int32)type].Play(this.X * Map2D.Case + this.Map.OffsetX, this.Y * Map2D.Case + this.Map.OffsetY);
        }

        /// <summary>
        /// Move to a frame
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="orientation"></param>
        public void MoveTo(Int32 x, Int32 y, Direction orientation)
        {
            Int32 nbMoves = 0;

            if (orientation == Direction.Up)
            {
                nbMoves = Math.Abs(this.Y - y);
                if (this.Y == 0 && nbMoves > 0)
                {
                    this.Y = this.Map.Height - 1;
                    this.HitBox.Y = this.Y * Map2D.Case;
                    return;
                }
            }
            else if (orientation == Direction.Right)
            {
                nbMoves = Math.Abs(this.X - x);
                if (this.X == this.Map.Width - 1 && nbMoves > 0)
                {
                    this.X = 0;
                    this.HitBox.X = this.X * Map2D.Case;
                    return;
                }
            }
            else if (orientation == Direction.Down)
            {
                nbMoves = Math.Abs(this.Y - y);
                if (this.Y == this.Map.Height - 1 && nbMoves > 0)
                {
                    this.Y = 0;
                    this.HitBox.Y = this.Y * Map2D.Case;
                    return;
                }
            }
            else if (orientation == Direction.Left)
            {
                nbMoves = Math.Abs(this.X - x);
                if (this.X == 0 && nbMoves > 0)
                {
                    this.X = this.Map.Width - 1;
                    this.HitBox.X = this.X * Map2D.Case;
                    return;
                }
            }
            this.ChangeDirection(orientation);
            while (nbMoves > 0)
            {
                this.Move(orientation);
                nbMoves--;
            }
        }

        #endregion
    }

    public enum Direction
    {
        Up = 1,
        Right,
        Down,
        Left
    }

    public enum AnimationType
    {
        Cast = 0,
        Die
    }
}