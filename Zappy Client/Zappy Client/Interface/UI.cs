﻿using Microsoft.Xna.Framework;
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
        internal ContentManager Content { get; set; }
        private SpriteBatch SpriteBatch { get; set; }

        public Int32 ClientWidth { get; private set; }
        public Int32 ClientHeight { get; private set; }


        internal FontManager Fonts { get; set; }
        internal TextureManager Textures { get; set; }

        internal List<Container> Contrainers { get; set; }

        internal Container CurrentContainer { get; set; }
        internal Container CurrentMovingContainer { get; set; }

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

            /* Load sprite font */
            this.Fonts = new FontManager();
            this.Fonts["TrebuchetMS"] = this.Content.Load<SpriteFont>("Theme//Font//TrebuchetMS10");
            this.Fonts["TrebuchetMSBold"] = this.Content.Load<SpriteFont>("Theme//Font//TrebuchetMS10Bold");
            this.Fonts["ArialBlack"] = this.Content.Load<SpriteFont>("Theme//Font//Arial Black9");

            /* Load window tiles */
            for (Int32 i = 0; i < 12; ++i)
            {
                this.Textures["Window" + i.ToString()] = this.Content.Load<Texture2D>(@"Theme\Window\WndTile" + i.ToString("00") + ".png");
            }
            this.Textures["WindowCloseButton"] = this.Content.Load<Texture2D>("Theme//Window//ButtWndExit.png");

            /* Load buttons */
            this.Textures["Button"] = this.Content.Load<Texture2D>("Theme//Buttons//ButtNormal00.png");

            /* Load checkbox */
            this.Textures["CheckBox"] = this.Content.Load<Texture2D>("Theme//Controls//ButtCheck.png");

            /* Load progressbar */
            this.Textures["ProgressBarBg"] = this.Content.Load<Texture2D>("Theme//ProgressBars//TargetgaugeBg.png");
            this.Textures["ProgressBarRed"] = this.Content.Load<Texture2D>("Theme//ProgressBars//Targetgauge01.png");
            this.Textures["ProgressBarGreen"] = this.Content.Load<Texture2D>("Theme//ProgressBars//Targetgauge03.png");
            this.Textures["ProgressBarBlue"] = this.Content.Load<Texture2D>("Theme//ProgressBars//Targetgauge02.png");
        }

        /// <summary>
        /// Update the visible containers
        /// </summary>
        public void Update()
        {
            Mouse.GetState().Update();
            if (Mouse.GetState().IsInRectangle(new Rectangle(0, 0, this.ClientWidth, this.ClientHeight)) == false)
            {
                this.CurrentMovingContainer = null;
            }
            if (this.CurrentMovingContainer != null)
            {
                this.CurrentMovingContainer.ProcessMoves();
            }
            for (Int32 i = 0; i < this.Contrainers.Count; ++i)
            {
                if (this.Contrainers[i].Visible == true && this.Contrainers[i].Enabled == true)
                {
                    this.Contrainers[i].Update();
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
            foreach (Container container in this.Contrainers)
            {
                if (container.Visible == true && container != this.CurrentContainer)
                {
                    container.Draw(this.SpriteBatch);
                }
            }
            if (this.CurrentContainer != null)
            {
                this.CurrentContainer.Draw(this.SpriteBatch);
            }
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
            this.CurrentContainer = container;
            this.Contrainers.Add(container);
        }

        /// <summary>
        /// Removes a control from the UI Engine
        /// </summary>
        /// <param name="name">Control name</param>
        public void DeleteControl(String name)
        {
            foreach (Container container in this.Contrainers)
            {
                if (container.Name == name)
                {
                    this.Contrainers.Remove(container as Container);
                    if (this.Contrainers.Count > 0)
                    {
                        this.CurrentContainer = this.Contrainers.Last() as Container;
                    }
                    else
                    {
                        this.CurrentContainer = null;
                    }
                    break;
                }
            }
        }

        #endregion
    }
}
