using System;
using System.Linq;
using DungeonsandDonuts.Animations;
using DungeonsandDonuts.Characters;
using DungeonsandDonuts.Enemies;
using DungeonsandDonuts.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
// ReSharper disable PossibleLossOfFraction

namespace DungeonsandDonuts
{
    public class Game1 : Game
    {
        /// <summary>
        /// Basically the window
        /// </summary>
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _background;
        private Texture2D _obstacle;
        private Random _rnd = new Random();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            GameManager.Render = new RenderContext();
            GameManager.SetupWindow(ref _graphics, GraphicsDevice);
            GameManager.LoadSettings(Content);
            GameManager.CreateCharacter(GameEnums.Character.Wizard, ref _graphics);
            GameManager.AddAnemy(GameEnums.Enemies.Zombie, ref _graphics, 3, _rnd);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GameManager.Render.SpriteBatch = _spriteBatch;
            GameManager.Render.GraphicsDevice = GraphicsDevice;
            GameManager.Character.IdleTexture = GameManager.LoadIdleContent(Content, GameEnums.Character.Wizard);
            GameManager.Character.RunningTexture = GameManager.LoadRunningContent(Content, GameEnums.Character.Wizard);
            GameManager.Character.BasicHitTexture = GameManager.LoadBasicHitContent(Content, GameEnums.Character.Wizard);
            GameManager.LoadUiElements(Content, GraphicsDevice);
            _background = Content.Load<Texture2D>("background");
            _obstacle = Content.Load<Texture2D>("rock");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var keyState = Keyboard.GetState();

            if(keyState.GetPressedKeys().Any(a => a == Keys.Up || a == Keys.Down || a == Keys.Left || a == Keys.Right))
                CharacterManager.MoveMainCharacter(keyState.GetPressedKeys().ToList(), gameTime, _graphics);

            CharacterManager.Hit(keyState);

            EnemyManager.MoveEnemies(gameTime);

            GameManager.Render.GameTime = gameTime;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            InterfaceManager.DrawBackground(_spriteBatch, ref _graphics, _background, _obstacle);
            EnemyManager.DrawEnemies(ref _graphics, _spriteBatch, gameTime);
            CharacterManager.DrawMainCharacter(_spriteBatch, Keyboard.GetState(), CharacterManager.Direction);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}