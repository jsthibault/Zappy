using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * Pikachu.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 11/07/2014 02:56:14
 * 
 * Notes:
 * PIKACHU <3
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public enum PikachuAnimation
    {
        Surf,
        Run
    }

    public class PikachuSurf
    {
        #region FIELDS

        private Map2D Map { get; set; }

        private Vector2 Position { get; set; }

        private PikachuAnimation State { get; set; }

        private Boolean FirstSurfDone { get; set; }

        private Boolean RunDone { get; set; }

        private Boolean DoSurf { get; set; }

        private Animation Run { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates the pikachu
        /// </summary>
        /// <param name="map"></param>
        public PikachuSurf(Map2D map)
        {
            this.Map = map;
            this.Position = new Vector2(-70, this.Map.OffsetY + (this.Map.Height / 2) * 32);
            this.State = PikachuAnimation.Surf;
            this.FirstSurfDone = false;
            this.RunDone = false;
            this.DoSurf = false;
            this.Run = new Animation(1, 4, TextureManager.Instance["PikachuRun"], 5);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Update pikachu
        /// </summary>
        public void Update()
        {
            if (this.DoSurf == true)
            {
                if (this.FirstSurfDone == false)
                {
                    if (this.Position.X >= this.Map.OffsetX - 32)
                    {
                        this.FirstSurfDone = true;
                        this.State = PikachuAnimation.Run;
                        this.Run.Play(this.Map.OffsetX, this.Map.OffsetY + (this.Map.Height / 2) * 32, true);
                    }
                    else
                    {
                        this.Position += new Vector2(2, 0);
                    }
                }
                else if (this.FirstSurfDone == true && this.RunDone == false)
                {
                    if (this.Run.Position.X >= this.Map.OffsetX + (Map2D.Case * this.Map.Width))
                    {
                        this.State = PikachuAnimation.Surf;
                        this.Position = this.Run.Position;
                        this.Run.Playing = false;
                        this.RunDone = true;
                    }
                    else
                    {
                        this.Run.Position += new Vector2(2, 0);
                        this.Run.Update();
                    }
                }
                else
                {
                    if (this.Position.X >= this.Map.OffsetX * 2 + (Map2D.Case * this.Map.Width))
                    {
                        this.DoSurf = false;
                    }
                    else
                    {
                        this.Position += new Vector2(2, 0);
                    }
                }
            }
        }

        /// <summary>
        /// Draw pikachu
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (this.State)
            {
                case PikachuAnimation.Surf: spriteBatch.Draw(TextureManager.Instance["PikachuSurf"], this.Position, Color.White); break;
                case PikachuAnimation.Run: this.Run.Draw(spriteBatch); break;
            }
        }

        /// <summary>
        /// Execute surf
        /// </summary>
        public void Surf()
        {
            this.DoSurf = true;
        }

        #endregion
    }
}
