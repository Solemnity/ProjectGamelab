using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DankyKang.Source.Objects {
    class Bullet : GameObject {
        private Vector2 _position;
        private double _angle;
        private double _timeToDestroy = Double.MaxValue;
        private Texture2D _bulletTexture;

        public Rectangle _boundingBox { get; private set; }

        public Action<Bullet> destroy;

        public Bullet(Vector2 startPos, double angle) {
            _position = startPos;
            _angle = angle;

        }

        public override void Start() {
            _bulletTexture = Main.Instance.Content.Load<Texture2D>("bullet");
            _timeToDestroy = Globals.BULLET_LIFE_TIME;

            _boundingBox = new Rectangle((int)_position.X - _bulletTexture.Width / 2, (int)_position.Y - _bulletTexture.Height / 2, _bulletTexture.Width, _bulletTexture.Height);
        }

        public override void Update(GameTime gameTime) {
            if (_timeToDestroy <= 0) {
                destroy?.Invoke(this);
            } else {
                _timeToDestroy -= gameTime.ElapsedGameTime.Milliseconds;
            }

            Vector2 vel = Vector2.Zero;

            vel.X = (float)Math.Cos(_angle);
            vel.Y = (float)Math.Sin(_angle);

            _position += vel * Globals.BULLET_SPEED;

            _boundingBox = new Rectangle((int)_position.X - _bulletTexture.Width / 2, (int)_position.Y - _bulletTexture.Height / 2, _bulletTexture.Width, _bulletTexture.Height);

        }

        public override void Destroy() {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            Vector2 _drawPos = _position;
            Rectangle sourceRectangle = new Rectangle(0, 0, _bulletTexture.Width, _bulletTexture.Height);
            Vector2 origin = new Vector2(_bulletTexture.Width / 2, _bulletTexture.Height / 2);

            spriteBatch.Draw(_bulletTexture, _drawPos, sourceRectangle, Color.White, (float)_angle - (float)(Math.PI * 270 / 180.0), origin, new Vector2(.1f, .1f), SpriteEffects.None, 0f);

        }
    }
}
