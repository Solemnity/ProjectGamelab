using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DankyKang.Source.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DankyKang.Source.Game_States {
    class Asteroid : GameObject {

        private Vector2 _position;
        private double _angle;
        private double _timeToDestroy = Double.MaxValue;
        private Texture2D _asteroidTexture;

        public Rectangle _boundingBox { get; private set; }


        public Asteroid(Vector2 startPos, double angle) {
            _position = startPos;
            _angle = angle;

        }

        public override void Start() {
            _asteroidTexture = Main.Instance.Content.Load<Texture2D>("asteroid");
            _timeToDestroy = Globals.ASTEROID_LIFE_TIME;

            _boundingBox = new Rectangle((int)_position.X - _asteroidTexture.Width / 2, (int)_position.Y - _asteroidTexture.Height / 2, _asteroidTexture.Width, _asteroidTexture.Height);
        }

        public override void Update(GameTime gameTime) {
            if (_timeToDestroy <= 0) {
                // Initialize Destruction of this asteroid here
            } else {
                _timeToDestroy -= gameTime.ElapsedGameTime.Milliseconds;
            }

            Vector2 vel = Vector2.Zero;

            vel.X = (float)Math.Cos(_angle);
            vel.Y = (float)Math.Sin(_angle);

            _position += vel * Globals.ASTEROID_SPEED;

            _boundingBox = new Rectangle((int)_position.X - _asteroidTexture.Width / 2, (int)_position.Y - _asteroidTexture.Height / 2, _asteroidTexture.Width, _asteroidTexture.Height);

        }

        public override void Destroy() {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            Vector2 _drawPos = _position;
            Rectangle sourceRectangle = new Rectangle(0, 0, _asteroidTexture.Width, _asteroidTexture.Height);
            Vector2 origin = new Vector2(_asteroidTexture.Width / 2, _asteroidTexture.Height / 2);

            spriteBatch.Draw(_asteroidTexture, _drawPos, sourceRectangle, Color.White, 0, origin, new Vector2(.5f, .5f), SpriteEffects.None, 0f);

        }
    }
}
