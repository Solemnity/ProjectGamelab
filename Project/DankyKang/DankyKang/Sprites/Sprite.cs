using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DankyKang.Managers;
using DankyKang.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DankyKang.Sprites {
    public class Sprite {
        #region Fields
        
        protected AnimationManager _animationManager;
        protected Dictionary<string, Animations> _animationses;
        protected Vector2 _position;
        protected Texture2D _texture;

        #endregion

        #region Properties

        public Input Input;

        public Vector2 Position {
            get { return _position; }
            set {
                _position = value;
                if (_animationManager != null) {
                    _animationManager.Position = _position;
                }
            }
        }
        public float speed = 1;
        public Vector2 Velocity;

        #endregion

        #region Method

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (_texture != null) {
                spriteBatch.Draw(_texture, Position, Color.White);
            } else if (_animationManager != null) {
                _animationManager.Draw(spriteBatch);
            } else throw new Exception("this is bad");
        }

        protected virtual void Move() {
            if (Keyboard.GetState().IsKeyDown(Input.Up)) {
                Velocity.Y = -speed;
            } else if (Keyboard.GetState().IsKeyDown(Input.Down)) {
                Velocity.Y = speed;
            } else if (Keyboard.GetState().IsKeyDown(Input.Left)) {
                Velocity.X = -speed;
            } else if (Keyboard.GetState().IsKeyDown(Input.Right)) {
                Velocity.X = speed;
            }
        }

        public Sprite(Dictionary<string, Animations> animationses) {
            _animationses = animationses;
            _animationManager = new AnimationManager(_animationses.First().Value);
        }

        public Sprite(Texture2D texture) {
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites) {
            Move();

            SetAnimations();
            
            _animationManager.Update(gameTime);
            
            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        protected virtual void SetAnimations() {
            if (Velocity.X > 0) {
                _animationManager.Play(_animationses["walkRight"]);
            }
            else if (Velocity.X < 0) {
                _animationManager.Play(_animationses["walkLeft"]);
            }
            else if (Velocity.Y > 0) {
                _animationManager.Play(_animationses["walkDown"]);
            }
            else if (Velocity.Y < 0) {
                _animationManager.Play(_animationses["walkUp"]);
            }
        }

        #endregion
    }
}
