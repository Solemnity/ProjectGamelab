using System;
using System.Collections.Generic;
using DankyKang.Source.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DankyKang.Source.Game_States {
    public class MainGame : GameState {
        private SpriteFont _font;
        private string MainText = "Score: ";

        private Spaceship _spaceship;
        private AsteroidSpawner _asteroidSpawner;
        private List<Asteroid> _asteroids = new List<Asteroid>();

        public override void Initialize() {
            base.Initialize();
            _font = Main.Instance.Content.Load<SpriteFont>("font");

            _asteroidSpawner = new AsteroidSpawner();
            _asteroidSpawner.Start();

            _spaceship = new Spaceship(new Vector2(Globals.RENDER_TARGET_WIDTH / 2, Globals.RENDER_TARGET_HEIGHT / 2));
            _spaceship.Start();

            _asteroidSpawner.spawnedAsteroid += SpawnedAsteroid;


            Debugger.Debug("MainGame :: Initialized");
        }

        private void SpawnedAsteroid(Asteroid asteroid) {
            asteroid.Start();
            _asteroids.Add(asteroid);
            Debugger.Log("Spawned Asteroid");
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            base.Draw(spriteBatch, gameTime);
            _spaceship.Draw(spriteBatch, gameTime);

            foreach (var asteroid in _asteroids) {
                asteroid.Draw(spriteBatch, gameTime);
            }

            spriteBatch.DrawString(_font, MainText,
                new Vector2(10, 10), Color.White);

        }

        public override void Update(GameTime gameTime) {
            _spaceship.Update(gameTime);
            _asteroidSpawner.Update(gameTime);

            _asteroids.ForEach(a => a.Update(gameTime));

            foreach (var a in _asteroids) {
                if (a._boundingBox.Intersects(_spaceship._boundingBox)) {
                    Debugger.Log("Asteroid Hit Player");
                }
            }
            base.Update(gameTime);


        }
    }
}