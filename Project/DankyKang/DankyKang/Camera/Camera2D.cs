using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DankyKang.Camera {
    public interface IFocusable {
        Vector2 Position { get; }
    }
    
    public interface ICamera2D {
        Vector2 Position { get; set; }
        float MoveSpeed { get; set; }
        float Rotation { get; set; }
        Vector2 Origin { get; }
        float Scale { get; set; }
        Vector2 ScreenCenter { get; }
        Matrix Transform { get; }
        IFocusable Focus { get; set; }
        bool IsInView(Vector2 position, Texture2D texture);
    }
    
    public class Camera2D : GameComponent, ICamera2D {
        private Vector2 _position;
        protected float _viewportHeight;
        protected float _viewportWidth;

        public Camera2D(Game game)
            : base(game)
        {}

        #region Properties

        public Vector2 Position {
            get { return _position; }
            set { _position = value; }
        }
        
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public float Scale { get; set; }
        public Vector2 ScreenCenter { get; protected set; }
        public Matrix Transform { get; set; }
        public IFocusable Focus { get; set; }
        public float MoveSpeed { get; set; }

        #endregion
        
        public override void Initialize() {
            _viewportWidth = Game.GraphicsDevice.Viewport.Width;
            _viewportHeight = Game.GraphicsDevice.Viewport.Height;

            ScreenCenter = new Vector2(_viewportWidth/2, _viewportHeight/2);
            Scale = 1;
            MoveSpeed = 1.25f;

            base.Initialize();
        }
        
        public override void Update(GameTime gameTime) {
            Transform = Matrix.Identity*
                        Matrix.CreateTranslation(-Position.X, -Position.Y, 0)*
                        Matrix.CreateRotationZ(Rotation)*
                        Matrix.CreateTranslation(Origin.X, Origin.Y, 0)*
                        Matrix.CreateScale(new Vector3(Scale, Scale, Scale));

            Origin = ScreenCenter / Scale;

            var delta = (float) gameTime.ElapsedGameTime.TotalSeconds;

            _position.X += (Focus.Position.X - Position.X) * MoveSpeed * delta;
            _position.Y += (Focus.Position.Y - Position.Y) * MoveSpeed * delta;

            base.Update(gameTime);
        }
        
        public bool IsInView(Vector2 position, Texture2D texture) {
            if ( (position.X + texture.Width) < (Position.X - Origin.X) || (position.X) > (Position.X + Origin.X) )
                return false;

            if ((position.Y + texture.Height) < (Position.Y - Origin.Y) || (position.Y) > (Position.Y + Origin.Y))
                return false;

            return true;
        }
    }
}