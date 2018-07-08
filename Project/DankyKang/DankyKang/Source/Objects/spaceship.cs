using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DankyKang.Source.Objects {
    class Spaceship : GameObject {

        private Vector2 _position = new Vector2(0, 0);

        private Texture2D _spaceshipTexture;
        private float _angle = 0;
        public Rectangle _boundingBox { get; private set; }

        public Spaceship(Vector2 startPos) {
            _position = startPos;
        }

        public override void Start() {
            _spaceshipTexture = Main.Instance.Content.Load<Texture2D>("Spaceships/spaceship");

            _boundingBox = new Rectangle((int)_position.X - _spaceshipTexture.Width / 2, (int)_position.Y - _spaceshipTexture.Height / 2, _spaceshipTexture.Width, _spaceshipTexture.Height );
        }

        public override void Update(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.A)) {
                _angle -= 0.035f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D)) {
                _angle += 0.035f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W)) {
                Vector2 vel = Vector2.Zero;

                vel.X = (float)Math.Cos(_angle);
                vel.Y = (float)Math.Sin(_angle);

                _position += vel * Globals.PLAYER_MAX_SPEED;
            }



            _boundingBox = new Rectangle((int)_position.X - _spaceshipTexture.Width / 2, (int)_position.Y - _spaceshipTexture.Height / 2, _spaceshipTexture.Width, _spaceshipTexture.Height);
        }

        public override void Destroy() {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            Vector2 _drawPos = _position;
            Rectangle sourceRectangle = new Rectangle(0, 0, _spaceshipTexture.Width, _spaceshipTexture.Height);
            Vector2 origin = new Vector2(_spaceshipTexture.Width / 2, _spaceshipTexture.Height / 2);

            spriteBatch.Draw(_spaceshipTexture, _drawPos, sourceRectangle, Color.White, _angle - (float)(Math.PI * 270 / 180.0), origin, 1.0f, SpriteEffects.None, 1);
        }

    }
}
