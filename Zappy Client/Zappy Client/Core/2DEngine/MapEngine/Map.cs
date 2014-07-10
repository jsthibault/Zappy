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

        public Int32 Width { get; set; }
        public Int32 Height { get; set; }

        public Single CursorX { get; set; }
        public Single CursorY { get; set; }

        public event Interface.MonoGameEventHandler OnCursorClick;

        public Dictionary<String, Team> Teams { get; private set; }
        public List<FrameContent> Frames { get; private set; }
        public List<Egg> Eggs { get; private set; }

        private Game GameInstance { get; set; }
        private Camera Camera { get; set; }

        private Texture2D Grass { get; set; }
        private Texture2D Water { get; set; }
        private Texture2D Moutain { get; set; }
        private Texture2D Cursor { get; set; }
        private Texture2D Character { get; set; }
        private Texture2D Grid { get; set; }
        private Texture2D CastAnim { get; set; }
        private Texture2D DeadAnim { get; set; }
        public Texture2D Egg { get; set; }
        public Texture2D EggDead { get; set; }
        public Texture2D EggOpen { get; set; }
        public Texture2D EggEmpty { get; set; }
        public Texture2D EggDeadOpen { get; set; }
        private Texture2D[] Cristals { get; set; }
        private SpriteFont Debug { get; set; }
        private List<Animation> Portals { get; set; }

        public const Int32 Case = 32;

        private Int32 WaterWidth { get; set; }
        private Int32 WaterHeight { get; set; }

        public Int32 OffsetX { get; set; }
        public Int32 OffsetY { get; set; }

        private Int32 CurrentCursorX { get; set; }
        private Int32 CurrentCursorY { get; set; }

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
            this.CurrentCursorX = 0;
            this.CurrentCursorY = 0;
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
            this.AddEgg(new Egg(this, "1", 5, 5));
            return true;
        }

        /// <summary>
        /// Initialize the textures
        /// </summary>
        private void InitializeTexture()
        {
            this.Grass = this.GameInstance.Content.Load<Texture2D>("TexturesMap//grass.png");
            this.Water = this.GameInstance.Content.Load<Texture2D>("TexturesMap//water.png");
            this.Moutain = this.GameInstance.Content.Load<Texture2D>("TexturesMap//moutain.png");
            this.Cursor = this.GameInstance.Content.Load<Texture2D>("TexturesMap//cursor.png");
            this.Character = this.GameInstance.Content.Load<Texture2D>("Characters//chocobo.png");
            this.Grid = this.GameInstance.Content.Load<Texture2D>("TexturesMap//grid.png");
            this.CastAnim = this.GameInstance.Content.Load<Texture2D>("Characters//cast.png");
            this.DeadAnim = this.GameInstance.Content.Load<Texture2D>("Characters//die.png");
            this.Egg = this.GameInstance.Content.Load<Texture2D>("Characters//eggs//egg.png");
            this.EggDead = this.GameInstance.Content.Load<Texture2D>("Characters//eggs//egg_dead.png");
            this.EggOpen = this.GameInstance.Content.Load<Texture2D>("Characters//eggs//egg_eclos.png");
            this.EggEmpty = this.GameInstance.Content.Load<Texture2D>("Characters//eggs//egg_empty.png");
            this.EggDeadOpen = this.GameInstance.Content.Load<Texture2D>("Characters//eggs//egg_eclos_dead.png");
            this.Cristals = new Texture2D[7];
            Int32 _j = 7;
            for (Int32 i = 0; i < 7; ++i)
            {
                this.Cristals[i] = this.GameInstance.Content.Load<Texture2D>("Characters//items//cristal_" + (_j).ToString() + ".png");
                --_j;
            }
            this.Debug = this.GameInstance.Content.Load<SpriteFont>("Theme//Font//TrebuchetMS10");
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
        /// Fire the delegate if not null
        /// </summary>
        private void ClickMap()
        {
            if (this.OnCursorClick != null)
            {
                this.OnCursorClick(this);
            }
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
            if (_state.IsKeyDown(Keys.A) == true)
            {
            }
        }

        /// <summary>
        /// Update mouse input
        /// </summary>
        private void UpdateMouse()
        {
            MouseState _mouseState = Mouse.GetState();
            
            // Camera zoom
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

        #endregion
    }
}
