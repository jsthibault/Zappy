using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zappy_Client.Interface;

/*--------------------------------------------------------
 * Map.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 18/06/2014 18:34:48
 * 
 * Notes:
 * Map2D is my own implementation of maps and objects
 * It contains :
 * - ObjectManager (Add, Get, Delete)
 * - CharacterManager (Add, Get, Delete)
 * -------------------------------------------------------*/

namespace Zappy_Client.Core._2DEngine
{
    public partial class Map2D
    {
        #region FIELDS

        public const Int32 Case = 32;

        public Int32 Width { get; set; }
        public Int32 Height { get; set; }

        public Single CursorX { get; set; }
        public Single CursorY { get; set; }

        public event Interface.MonoGameEventHandler OnCursorClick;

        public Dictionary<String, Team> Teams { get; private set; }
        public List<FrameContent> Frames { get; private set; }
        public List<Egg> Eggs { get; private set; }
        private List<Animation> Portals { get; set; }

        public Int32 OffsetX { get; set; }
        public Int32 OffsetY { get; set; }

        private Game GameInstance { get; set; }
        private Camera Camera { get; set; }

        private Int32 WaterWidth { get; set; }
        private Int32 WaterHeight { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Map initialisation
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Map2D(Game instance, Int32 width, Int32 height, Camera camera)
        {
            this.GameInstance = instance;
            this.Width = width;
            this.Height = height;
            this.WaterWidth = (Zappy.Width / 32) * 2 + this.Width;
            this.WaterHeight = (Zappy.Height / 32) * 2 + this.Height;
            this.OffsetX = ((this.WaterWidth * Case) / 2) - ((this.Width * Case) / 2);
            this.OffsetY = ((this.WaterHeight * Case) / 2) - ((this.Height * Case) / 2);
            this.CursorX = -1;
            this.CursorY = -1;
            this.Camera = camera;
            this.Camera.SetPosition(new Vector2(this.OffsetX + (Zappy.Width / 4), this.OffsetX));
            this.Teams = new Dictionary<String, Team>();
            this.Frames = new List<FrameContent>();
            this.Eggs = new List<Egg>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize and load the map assets
        /// </summary>
        /// <returns></returns>
        public Boolean Initialize()
        {
            this.InitializeTexture();
            this.InitializePortals();
            return true;
        }

        /// <summary>
        /// Initialize the textures
        /// </summary>
        private void InitializeTexture()
        {
            for (Int32 i = 0, j = 7; i < 7; ++i, --j)
            {
                TextureManager.Instance["Cristal" + i.ToString()] = this.GameInstance.Content.Load<Texture2D>("Characters//items//cristal_" + (j).ToString() + ".png");
            }
            TextureManager.Instance["Grass"] = this.GameInstance.Content.Load<Texture2D>("TexturesMap//grass.png");
            TextureManager.Instance["Water"] = this.GameInstance.Content.Load<Texture2D>("TexturesMap//water.png");
            TextureManager.Instance["Moutain"] = this.GameInstance.Content.Load<Texture2D>("TexturesMap//moutain.png");
            TextureManager.Instance["Cursor"] = this.GameInstance.Content.Load<Texture2D>("TexturesMap//cursor.png");
            TextureManager.Instance["Grid"] = this.GameInstance.Content.Load<Texture2D>("TexturesMap//grid.png");
            TextureManager.Instance["Chocobo"] = this.GameInstance.Content.Load<Texture2D>("Characters//chocobo.png");
            TextureManager.Instance["Cast"] = this.GameInstance.Content.Load<Texture2D>("Characters//cast.png");
            TextureManager.Instance["Die"] = this.GameInstance.Content.Load<Texture2D>("Characters//die.png");
            TextureManager.Instance["Egg"] = this.GameInstance.Content.Load<Texture2D>("Characters//eggs//egg.png");
            TextureManager.Instance["EggDead"] = this.GameInstance.Content.Load<Texture2D>("Characters//eggs//egg_dead.png");
            TextureManager.Instance["EggOpen"] = this.GameInstance.Content.Load<Texture2D>("Characters//eggs//egg_eclos.png");
            TextureManager.Instance["EggEmpty"] = this.GameInstance.Content.Load<Texture2D>("Characters//eggs//egg_empty.png");
            TextureManager.Instance["EggDeadOpen"] = this.GameInstance.Content.Load<Texture2D>("Characters//eggs//egg_eclos_dead.png");
        }

        /// <summary>
        /// Initialize portals
        /// </summary>
        private void InitializePortals()
        {
            Texture2D _portalTexture = this.GameInstance.Content.Load<Texture2D>("TexturesMap//portal.png");
            this.Portals = new List<Animation>();

            // top
            for (Int32 i = 0; i < this.Width; ++i)
            {
                Animation _portal = new Animation(1, 4, _portalTexture, 5);
                _portal.Play(i * Case + this.OffsetX, this.OffsetY - (Case + 16), true);
                this.Portals.Add(_portal);
            }

            // bottom
            for (Int32 i = 0; i < this.Width; ++i)
            {
                Animation _portal = new Animation(1, 4, _portalTexture, 5);
                _portal.Play(i * Case + this.OffsetX, this.OffsetY + (Case * this.Height) + 16, true);
                this.Portals.Add(_portal);
            }

            // left
            for (Int32 i = 0; i < this.Height; ++i)
            {
                Animation _portal = new Animation(1, 4, _portalTexture, 5);
                _portal.Play(this.OffsetX - (Case + 16), i * Case + this.OffsetY, true);
                this.Portals.Add(_portal);
            }

            // right
            for (Int32 i = 0; i < this.Height; ++i)
            {
                Animation _portal = new Animation(1, 4, _portalTexture, 5);
                _portal.Play(this.OffsetX + (Case * this.Width + 16), i * Case + this.OffsetY, true);
                this.Portals.Add(_portal);
            }
        }

        /// <summary>
        /// Update the layers, players and objets
        /// </summary>
        public void Update()
        {
            this.UpdateKeyboard();
            this.UpdateMouse();
            
            // Update teams and characters
            foreach (Team team in this.Teams.Values)
            {
                for (Int32 i = 0; i < team.Characters.Count; ++i)
                {
                    team.Characters[i].Update();
                }
            }

            // Update eggs
            for (Int32 i = 0; i < this.Eggs.Count; ++i)
            {
                this.Eggs[i].Update();
            }

            // Update portals
            foreach (Animation portal in this.Portals)
            {
                portal.Update();
            }
        }

        /// <summary>
        /// Draw the layers, players and objects
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
            this.DrawWater(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
            this.DrawMountain(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
            this.DrawGround(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
            this.DrawGrid(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
            this.DrawCursor(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
            this.DrawItems(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
            foreach (Team team in this.Teams.Values)
            {
                foreach (Character character in team.Characters)
                {
                    character.Draw(spriteBatch);
                }
            }
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
            for (Int32 i = 0; i < this.Eggs.Count; ++i)
            {
                this.Eggs[i].Draw(spriteBatch);
            }
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, this.Camera.GetTransformation());
            this.DrawPortals(spriteBatch);
            spriteBatch.End();
        }

        /// <summary>
        /// Update keyboard input
        /// </summary>
        private void UpdateKeyboard()
        {
            // Update camera
            this.Camera.Update();
            KeyboardState _state = Keyboard.GetState();

            if (_state.IsKeyDown(Keys.Up) == true && this.Camera.Position.Y >= Zappy.Height / 2)
            {
                this.Camera.Move(new Vector2(0, -10));
            }
            else if (_state.IsKeyDown(Keys.Down) == true && this.Camera.Position.Y < (this.WaterHeight * 32) - (Zappy.Height / 2))
            {
                this.Camera.Move(new Vector2(0, 10));
            }
            else if (_state.IsKeyDown(Keys.Left) == true && this.Camera.Position.X >= Zappy.Width / 2)
            {
                this.Camera.Move(new Vector2(-10, 0));
            }
            else if (_state.IsKeyDown(Keys.Right) == true && this.Camera.Position.X <= (this.WaterWidth * 32) - (Zappy.Width / 2))
            {
                this.Camera.Move(new Vector2(10, 0));
            }
        }

        /// <summary>
        /// Update mouse input
        /// </summary>
        private void UpdateMouse()
        {
            MouseState _mouseState = Mouse.GetState();
            
            this.Camera.Zoom = _mouseState.ScrollWheelValue / 100;

            // Update mouse click
            Vector2 vec = Vector2.Transform(new Vector2(_mouseState.GetPosition().X, _mouseState.GetPosition().Y), Matrix.Invert(this.Camera.GetTransformation()));
            this.CursorX = (Convert.ToInt32(vec.X) - this.OffsetX) / Case;
            this.CursorY = (Convert.ToInt32(vec.Y) - this.OffsetY) / Case;
            if (_mouseState.MouseClick(MouseButton.LeftButton) == true)
            {
                if (this.CursorX >= 0 && this.CursorY >= 0 && this.CursorX < this.Width && this.CursorY < this.Height)
                {
                    this.ClickMap();
                }
            }
        }

        /// <summary>
        /// Fire the delegate if not null
        /// </summary>
        private void ClickMap()
        {
            if (this.OnCursorClick != null)
            {
                this.OnCursorClick(this);
            }
        }

        #endregion
    }
}
