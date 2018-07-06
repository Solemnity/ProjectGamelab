using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DankyKang.Source.Objects {
    abstract class GameObject {

        public abstract void Start();
        public abstract void Update(GameTime gameTime);
        public abstract void Destroy();
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
