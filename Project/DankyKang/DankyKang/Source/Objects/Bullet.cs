using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DankyKang.Source.Objects
{
    class Bullet : GameObject
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 angularVelocity;

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        public Bullet(Texture2D bulletTexture, Vector2 bulletOrigin, float bulletSpeed, float bulletAngle)
        {
            texture = bulletTexture;
            position = bulletOrigin;
            // create our angle from the passed in angle
            Vector2 angleVector = new Vector2((float)Math.Cos(bulletAngle), -(float)Math.Sin(bulletAngle));
            // multiply the angle vector by the bullet to get its angular velocity (velocity on some angle*)
            angularVelocity = angleVector * bulletSpeed;
        }

        public override void Start()
        {
         
        }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += angularVelocity * delta;
        }
    }
}
