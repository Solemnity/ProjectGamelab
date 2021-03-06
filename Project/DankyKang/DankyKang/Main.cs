﻿using System;
using System.Text;
using DankyKang.Source;
using DankyKang.Source.Game_States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DankyKang {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameState _currentGameState;

        public GameState CurrentGameState {
            get => _currentGameState;
            set {
                _currentGameState?.Destroy();
                _currentGameState = value;
                _currentGameState?.Initialize();
            }
        }

        public RenderTarget2D renderTarget { get; private set; }

        public static Main Instance;

        public Main() {
            Instance = this;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            base.Initialize();

            renderTarget = new RenderTarget2D(GraphicsDevice, Globals.RENDER_TARGET_WIDTH, Globals.RENDER_TARGET_HEIGHT);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Debugger.CustomColor("LoadContent has been called", ConsoleColor.DarkGreen);

            // We initialize the main menu here because we need to wait for the game to initialize its content manager
            CurrentGameState = new MainMenu();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private bool ctrlPressed = false;
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Debug Abilities:
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) {
                if (!ctrlPressed) {
                    ctrlPressed = true;
                    _graphics.PreferredBackBufferWidth = (_graphics.PreferredBackBufferWidth == 800) ? 1920 : 1280;
                    _graphics.PreferredBackBufferHeight = (_graphics.PreferredBackBufferHeight == 600) ? 1080 : 720;
                    _graphics.ApplyChanges();
                }
            } else {
                ctrlPressed = false;
            }


            _currentGameState?.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _currentGameState?.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);

            _spriteBatch.Begin();
            _spriteBatch.Draw(renderTarget, GraphicsDevice.Viewport.TitleSafeArea, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
