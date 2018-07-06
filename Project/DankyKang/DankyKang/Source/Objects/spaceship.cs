using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DankyKang.Source.Objects {
    class spaceship : GameObject {

        private Vector2 _position = new Vector2(0,0);

        private Texture2D _spaceshipTexture;

        public override void Start() {
            _spaceshipTexture = Main.Instance.Content.Load<Texture2D>("spaceship");
        }

        public override void Update(GameTime gameTime) {
            throw new NotImplementedException();
        }

        public override void Destroy() {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            
        }

    }
}
