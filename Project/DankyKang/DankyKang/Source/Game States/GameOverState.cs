using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DankyKang.Source.Game_States {
    class GameOverState : GameState {

        private SpriteFont _font;
        private string _mainText = "GAMEOVER";
        private string _scoreText = "";
        private string _resetText = "Press START to go back to main menu";

        public GameOverState(int score) {
            _scoreText = "Your score was " + score;
        }

        public override void Initialize() {
            _font = Main.Instance.Content.Load<SpriteFont>("hyperspace_big");

            base.Initialize();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {

            spriteBatch.DrawString(_font, _mainText,
                new Vector2(x: Globals.RENDER_TARGET_WIDTH / 2, y: Globals.RENDER_TARGET_HEIGHT / 2), Color.White, 0, new Vector2(_font.MeasureString(_mainText).X / 2, _font.MeasureString(_mainText).Y / 2), new Vector2(2f, 2f), SpriteEffects.None, 0);

            spriteBatch.DrawString(_font, _scoreText,
                new Vector2(x: Globals.RENDER_TARGET_WIDTH / 2 , y: Globals.RENDER_TARGET_HEIGHT / 2  - 150), Color.White, 0, new Vector2(_font.MeasureString(_scoreText).X / 2, _font.MeasureString(_scoreText).Y / 2), new Vector2(0.75f, 0.75f), SpriteEffects.None, 0);

            spriteBatch.DrawString(_font, _resetText,
                new Vector2(x: Globals.RENDER_TARGET_WIDTH / 2, y: Globals.RENDER_TARGET_HEIGHT / 2 + 150), Color.White, 0, new Vector2(_font.MeasureString(_resetText).X / 2, _font.MeasureString(_resetText).Y / 2), new Vector2(0.5f, 0.5f), SpriteEffects.None, 0);

            base.Draw(spriteBatch, gameTime);
        }

        public override void Update(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                Main.Instance.CurrentGameState = new MainMenu(); // Eventually this should go to level select or game scene
            base.Update(gameTime);
        }
    }
}
