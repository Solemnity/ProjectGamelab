using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DankyKang.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DankyKang.Managers {
    public class AnimationManager {
        private Animations _animations;
        private float _timer;
        public Vector2 Position { get; set; }

        public AnimationManager(Animations animations) {
            _animations = animations;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_animations.Texture, Position, new Rectangle(_animations.CurrentFrame * _animations.FrameWidth, 0, 
                             _animations.FrameWidth, _animations.FrameHeight), Color.White);
        }
        

        public void Play(Animations animations) {
            if (_animations == animations) {
                return;
            }

            _animations = animations;
            _animations.CurrentFrame = 0;
            _timer = 0f;
        }

        public void Stop() {
            _timer = 0f;
            _animations.CurrentFrame = 0;
        }

        public void Update(GameTime gameTime) {
            _timer += (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > _animations.FrameSpeed) {
                _timer = 0f;
                _animations.CurrentFrame++;
            }

            if (_animations.CurrentFrame >= _animations.FrameCount) {
                _animations.CurrentFrame = 0;
            }
        }
    }
}