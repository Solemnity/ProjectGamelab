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
        private readonly List<Asteroid> _asteroids = new List<Asteroid>();
        private readonly List<Asteroid> _deletAsteroidList = new List<Asteroid>();
        private readonly List<Bullet> _bullets = new List<Bullet>();
        private readonly List<Bullet> _deletBulletList = new List<Bullet>();
        private bool _shootPressed = false;
        private int _score = 0;

        public override void Initialize() {
            base.Initialize();
            _font = Main.Instance.Content.Load<SpriteFont>("hyperspace");

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

            asteroid.destroy += ass => _deletAsteroidList.Add(ass);
            Debugger.Log("MainGame :: Spawned Asteroid");
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            base.Draw(spriteBatch, gameTime);

            _bullets.ForEach(bullet => bullet.Draw(spriteBatch, gameTime));
            _asteroids.ForEach(ass => ass.Draw(spriteBatch, gameTime));
            _spaceship.Draw(spriteBatch, gameTime);

            spriteBatch.DrawString(_font, MainText + _score,
                new Vector2(10, 10), Color.White);

        }

        public override void Update(GameTime gameTime) {
            _spaceship.Update(gameTime);
            _asteroidSpawner.Update(gameTime);

            _asteroids.ForEach(a => a?.Update(gameTime));
            _bullets.ForEach(b => b?.Update(gameTime));

            foreach (var a in _asteroids) {
                if (a._boundingBox.Intersects(_spaceship._boundingBox)) {
                    _spaceship.Hit();
                }
            }

            foreach (var bullet in _bullets) {
                foreach (var asteroid in _asteroids) {
                    if (bullet._boundingBox.Intersects(asteroid._boundingBox)) {
                        asteroid.Hit();
                        _deletBulletList.Add(bullet);
                    }
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !_shootPressed) {
                _shootPressed = true;
                Bullet bul = new Bullet(_spaceship._position, _spaceship.Angle);
                bul.destroy += bullet => _deletBulletList.Add(bullet); 
                bul.Start();
                _bullets.Add(bul);

            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
                _shootPressed = false;

            foreach (var ass in _deletAsteroidList) {
                _asteroids.Remove(ass);
                _score += 10;
            }
            _deletAsteroidList.Clear();

            foreach (var bull in _deletBulletList) {
                _bullets.Remove(bull);
            }
            _deletAsteroidList.Clear();

            base.Update(gameTime);


        }
    }
}