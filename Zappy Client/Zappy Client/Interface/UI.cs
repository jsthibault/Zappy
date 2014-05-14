using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * UI.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 14/05/2014 11:28:45
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Interface
{
    public class UI
    {
        #region FIELDS

        public GraphicsDevice GraphicsDevice { get; private set; }
        private ContentManager Content { get; set; }
        private SpriteBatch SpriteBatch { get; set; }

        public Int32 ClientWidth { get; private set; }
        public Int32 ClientHeight { get; private set; }

        public SpriteFont Font { get; internal set; }

        internal TextureManager Textures { get; set; }

        internal List<Container> Contrainers { get; set; }

        internal Window CurrentWindow { get; set; }
        internal Window CurrentMovingWindow { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a new UI Engine
        /// </summary>
        /// <param name="content">Game Content</param>
        /// <param name="graphics">Game GraphicsDevice</param>
        /// <param name="gameWidth">Game width</param>
        /// <param name="gameHeight">Game height</param>
        public UI(ContentManager content, GraphicsDevice graphics, Int32 gameWidth, Int32 gameHeight)
        {
            this.Content = content;
            this.GraphicsDevice = graphics;
            this.ClientWidth = gameWidth;
            this.ClientHeight = gameHeight;
            this.Textures = new TextureManager();
            this.Contrainers = new List<Container>();
            this.Initialize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the UI Engine
        /// </summary>
        public void Initialize()
        {
            /* Initialize spriteBatch */
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);

            /* Load window tiles */
            for (Int32 i = 0; i < 12; ++i)
            {
                this.Textures["Window" + i.ToString()] = this.Content.Load<Texture2D>(@"Theme\Window\WndTile" + i.ToString("00") + ".png");
            }
        }

        /// <summary>
        /// Update the visible containers
        /// </summary>
        public void Update()
        {
            Mouse.GetState().Update();
            if (Mouse.GetState().IsInRectangle(new Rectangle(0, 0, this.ClientWidth, this.ClientHeight)) == false)
            {
                this.CurrentMovingWindow = null;
            }
            if (this.CurrentMovingWindow != null)
            {
                (this.CurrentMovingWindow as Window).ProcessMoves();
            }
            foreach (Container container in this.Contrainers)
            {
                if (container.Visible == true)
                {
                    container.Update();
                }
            }
        }

        /// <summary>
        /// Draw the visible containers
        /// </summary>
        public void Draw()
        {
            this.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);
            this.SpriteBatch.Begin();
            foreach (Window window in this.Contrainers)
            {
                if (window.Visible == true && window != this.CurrentWindow)
                {
                    window.Draw(this.SpriteBatch);
                }
            }
            this.CurrentWindow.Draw(this.SpriteBatch);
            this.SpriteBatch.End();
        }

        /// <summary>
        /// Add a container to the UI Engine
        /// </summary>
        /// <param name="container">Container</param>
        public void AddContainer(Container container)
        {
            foreach (Container c in this.Contrainers)
            {
                if (c.Name == container.Name)
                {
                    throw new Exception("Duplicate control name");
                }
            }
            this.CurrentWindow = container as Window;
            this.Contrainers.Add(container);
        }

        /// <summary>
        /// Removes a control from the UI Engine
        /// </summary>
        /// <param name="name">Control name</param>
        public void DeleteControl(String name)
        {
            foreach (Control control in this.Contrainers)
            {
                if (control.Name == name)
                {
                    this.Contrainers.Remove(control as Container);
                    break;
                }
            }
        }

        #endregion
    }
}
