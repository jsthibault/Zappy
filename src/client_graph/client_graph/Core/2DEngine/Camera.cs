using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Camera.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 24/06/2014 10:27:07
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public class Camera
    {
        #region FIELDS

        private GraphicsDevice GraphicsDevice { get; set; }
        public Vector2 Position { get; private set; }
        private Matrix Transformation { get; set; }

        private Int32 ViewportWidth { get; set; }
        private Int32 ViewportHeight { get; set; }

        public CameraMode Mode { get; set; }

        #endregion

        #region PROPERTIES

        private Single zoom;
        public Single Zoom
        {
            get
            {
                return this.zoom;
            }
            set
            {
                this.zoom = value;
                if (this.zoom < 1f)
                {
                    this.zoom = 1f;
                }
            }
        }

        #endregion

        #region CONSTRUCTORS

        public Camera(GraphicsDevice graphicsDevice, Int32 viewPortWidth, Int32 viewPortHeight)
        {
            this.GraphicsDevice = graphicsDevice;
            this.ViewportWidth = viewPortWidth;
            this.ViewportHeight = viewPortHeight;
            this.Mode = CameraMode.Free;
            this.Zoom = 1f;
            this.Position = new Vector2(0, 0);
        }

        #endregion

        #region METHODS

        public void SetPosition(Vector2 position)
        {
            this.Position = position;
        }

        public void Move(Vector2 amount)
        {
            this.Position += amount;
        }

        public void Update()
        {
            this.Transformation = Matrix.CreateTranslation(new Vector3(-this.Position.X, -this.Position.Y, 0)) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(this.ViewportWidth * 0.5f, this.ViewportHeight * 0.5f, 0));
        }

        public Matrix GetTransformation()
        {
            return this.Transformation;
        }

        #endregion
    }

    public enum CameraMode
    {
        Free,
        Follow
    }
}
