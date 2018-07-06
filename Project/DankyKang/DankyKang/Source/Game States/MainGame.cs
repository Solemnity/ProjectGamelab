using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DankyKang.Source.Game_States {
    public class MainGame : GameState {
        private SpriteFont _font;
        private string MainText = "Main Game Boi";
        
        public override void Initialize() {
            base.Initialize();
            _font = Main.Instance.Content.Load<SpriteFont>("MainFont");
            
            Debugger.Debug("MainGame :: Initialized");
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            base.Draw(spriteBatch, gameTime);
            
            spriteBatch.DrawString(_font, MainText,
                new Vector2(x: Main.Instance.GraphicsDevice.Viewport.Bounds.Width/2 - _font.MeasureString(MainText).X/2, y: Main.Instance.GraphicsDevice.Viewport.Height/2 - _font.MeasureString(MainText).Y/2 ), Color.White);
        }

        public override void Update(GameTime gameTime) {

            base.Update(gameTime);
        }
    }
}