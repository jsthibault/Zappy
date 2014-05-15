using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Control.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 14/05/2014 13:27:11
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public abstract class Control
    {
        #region FIELDS

        public Boolean Enabled { get; set; }
        public Boolean Visible { get; set; }
        public Boolean Focus { get; set; }
        public Int32 X { get; protected set; }
        public Int32 Y { get; protected set; }
        public Int32 Width { get; protected set; }
        public Int32 Height { get; protected set; }
        public String Name { get; protected set; }
        public String Text { get; set; }

        public Control ParentControl { get; set; }
        protected UI Engine { get; set; }
        protected ControlState State { get; set; }

        public event MonoGameEventHandler OnHover;
        public event MonoGameEventHandler OnClick;
        public event MonoGameEventHandler OnPress;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the current control rectangle
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                if (this.ParentControl == null)
                {
                    return new Rectangle(this.X, this.Y, this.Width, this.Height);
                }
                else
                {
                    return new Rectangle(this.X + this.ParentControl.X,
                        this.Y + this.ParentControl.Y,
                        this.Width,
                        this.Height);
                }
            }
        }

        /// <summary>
        /// Gets the control position
        /// </summary>
        public Vector2 Position
        {
            get
            {
                if (this.ParentControl == null)
                {
                    return new Vector2(this.X, this.Y);
                }
                else
                {
                    return new Vector2(this.X + this.ParentControl.X + 10, this.Y + this.ParentControl.Y + 25);
                }
            }
        }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a basic control
        /// </summary>
        /// <param name="uiPtr"></param>
        /// <param name="name"></param>
        public Control(UI uiPtr, String name)
        {
            this.Engine = uiPtr;
            this.Enabled = true;
            this.Visible = true;
            this.Focus = false;
            this.Name = name;
        }

        ~Control() { }

        #endregion

        #region METHODS

        /// <summary>
        /// Abstract initialize method
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Virtual base update method
        /// </summary>
        public virtual void Update()
        {
            if (Mouse.GetState().IsInRectangle(this.Rectangle) == true)
            {
                this.MouseHover();
                if (Mouse.GetState().IsMouseDown() == true)
                {
                    this.MousePress();
                }
                if (Mouse.GetState().MouseClick(MouseButton.LeftButton) == true || Mouse.GetState().MouseClick(MouseButton.RightButton) == true ||
                    Mouse.GetState().MouseClick(MouseButton.MiddleButton) == true)
                {
                    this.MouseClick();
                }
            }
        }

        /// <summary>
        /// Abstract draw method
        /// </summary>
        /// <param name="spriteBatch"></param>
        public abstract void Draw(SpriteBatch spriteBatch);

        #endregion

        #region VIRTUAL

        /// <summary>
        /// Mouse hover event
        /// </summary>
        public virtual void MouseHover()
        {
            this.State = ControlState.Hover;
            if (this.OnHover != null)
            {
                this.OnHover(this);
            }
        }

        /// <summary>
        /// Mouse press event
        /// </summary>
        public virtual void MousePress()
        {
            this.State = ControlState.Press;
            if (this.OnPress != null)
            {
                this.OnPress(this);
            }
        }

        /// <summary>
        /// Mouse click event
        /// </summary>
        public virtual void MouseClick()
        {
            if (this.OnClick != null)
            {
                this.OnClick(this);
            }
        }

        #endregion
    }

    public enum ControlState
    {
        Normal = 0,
        Hover,
        Press
    }
}
