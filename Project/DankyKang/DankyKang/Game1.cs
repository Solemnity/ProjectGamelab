using System.Collections.Generic;
using DankyKang.Camera;
using DankyKang.Models;
using DankyKang.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DankyKang
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private SpriteFont fontlol;
        private int poop = 0;

        private List<Sprite> _sprites;
        private Camera2D _camera2D;
        private Game _game;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _camera2D = new Camera2D(_game);
            
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to loadwas
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            fontlol = Content.Load<SpriteFont>("font");

            var animations = new Dictionary<string, Animations>() {
                { "walkUp", new Animations(Content.Load<Texture2D>("Player/climb"), 4)},
                { "walkDown", new Animations(Content.Load<Texture2D>("Player/spritesheet"), 4)},
                { "walkLeft", new Animations(Content.Load<Texture2D>("Player/walkLeft"), 3)},
                { "walkRight", new Animations(Content.Load<Texture2D>("Player/walkRight"), 3)}
                
            };
            
            _sprites = new List<Sprite>() {
                new Sprite(animations) {
                    Position = new Vector2(100,100),
                    Input = new Input() {   
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D
                    }
                },
                
                new Sprite(animations) {
                    Position = new Vector2(150,100),
                    Input = new Input() {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Left = Keys.Left,
                        Right = Keys.Right
                    }
                }
            };
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (var sprite in _sprites) {
                sprite.Update(gameTime, _sprites);
            }
            
            
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.Begin();
            foreach (var sprite in _sprites) {
                sprite.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
