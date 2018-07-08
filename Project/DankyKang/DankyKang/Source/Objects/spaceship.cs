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

        public Vector2 _position { get; private set; } = new Vector2(0, 0);

        private Texture2D _spaceshipTexture;
        public float Angle { get; private set; } = 0;
        public Rectangle _boundingBox { get; private set; }
        private int _health;
        private float _healthCooldown = 0;

        public Action died;

        public Spaceship(Vector2 startPos) {
            _position = startPos;
            _health = Globals.PLAYER_HEALTH;

        }

        public override void Start() {
            _spaceshipTexture = Main.Instance.Content.Load<Texture2D>("Spaceships/spaceship");

            _boundingBox = new Rectangle((int)_position.X - _spaceshipTexture.Width / 2, (int)_position.Y - _spaceshipTexture.Height / 2, _spaceshipTexture.Width, _spaceshipTexture.Height);
        }

        public override void Update(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.A)) {
                Angle -= 0.035f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D)) {
                Angle += 0.035f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W)) {
                Vector2 vel = Vector2.Zero;

                vel.X = (float)Math.Cos(Angle);
                vel.Y = (float)Math.Sin(Angle);

                _position += vel * Globals.PLAYER_MAX_SPEED;
            }

            if (_healthCooldown >= 0) {
                _healthCooldown -= gameTime.ElapsedGameTime.Milliseconds;
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

            Color col = Color.White;
            if (_healthCooldown > 0)
                col = Color.Red;

            spriteBatch.Draw(_spaceshipTexture, _drawPos, sourceRectangle, col, Angle - (float)(Math.PI * 270 / 180.0), origin, 1.0f, SpriteEffects.None, 1);
        }

        public void Hit() {
            if (_healthCooldown <= 0) {
                Debugger.Log("Spaceship :: Hit");
                _healthCooldown = Globals.PLAYER_HIT_COOLDOWN;
                _health -= 1;

                if (_health <= 0) {
                    // We ded
                    died?.Invoke();
                    Debugger.CustomColor("Spaceship :: Ded", ConsoleColor.DarkMagenta);
                }
            }
        }

    }
}
