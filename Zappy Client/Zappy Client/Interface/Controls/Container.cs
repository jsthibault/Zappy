using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Window.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 14/05/2014 13:30:23
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class Container : Control
    {
        #region FIELDS

        /// <summary>
        /// Container controls list
        /// </summary>
        protected List<Control> Controls { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a basic container
        /// </summary>
        /// <param name="engine">UI Engine pointer</param>
        /// <param name="name">Control name</param>
        public Container(UI engine, String name) :
            base(engine, name)
        {
            this.Controls = new List<Control>();
            this.X = 0;
            this.Y = 0;
            this.Width = 50;
            this.Height = 50;
        }

        /// <summary>
        /// Initialize a new container with size and position
        /// </summary>
        /// <param name="engine">UI Engine pointer</param>
        /// <param name="name">Control name</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Container(UI engine, String name, Int32 x, Int32 y, Int32 width, Int32 height)
            : base(engine, name)
        {
            this.Controls = new List<Control>();
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Clear the container
        /// </summary>
        ~Container()
        {
            this.Controls.Clear();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the container
        /// </summary>
        public override void Initialize() { }
        
        /// <summary>
        /// Update the controls of the container
        /// </summary>
        public override void Update()
        {
            foreach (Control control in this.Controls)
            {
                if (control.Visible == true && control.Enabled == true)
                {
                    control.Update();
                }
            }
            base.Update();
        }

        /// <summary>
        /// Draw the controls of the container
        /// </summary>
        /// <param name="spriteBatch">Engine spriteBatch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Visible == true)
                {
                    control.Draw(spriteBatch);
                }
            }
        }

        /// <summary>
        /// Add a control to the container
        /// </summary>
        /// <param name="control">Control to add</param>
        public void AddControl(Control control)
        {
            if (this.Controls.Contains(control) == false)
            {
                control.ParentControl = this;
                this.Controls.Add(control);
            }
        }

        /// <summary>
        /// Remove a control from the container
        /// </summary>
        /// <param name="control">Control to remove</param>
        public void RemoveControl(Control control)
        {
            if (this.Controls.Contains(control) == true)
            {
                this.Controls.Remove(control);
            }
        }

        /// <summary>
        /// Remove a control from the container by his name
        /// </summary>
        /// <param name="controlName">Control name to remove</param>
        public void RemoveControl(String controlName)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Name == controlName)
                {
                    this.Controls.Remove(control);
                    break;
                }
            }
        }

        #endregion
    }
}
