using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DankyKang.Source.Game_States {
    public class MainMenu : GameState {
        private SpriteFont _font;
        private string MainText = "Press START to play";
        
        public override void Initialize() {
            base.Initialize();
            _font = Main.Instance.Content.Load<SpriteFont>("hyperspace_big");
            
            Debugger.Debug("MainMenu :: Initialized");
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
            

            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) 
                Main.Instance.CurrentGameState = new MainGame(); // Eventually this should go to level select or game scene
            
            if(Keyboard.GetState().IsKeyDown(Keys.LeftAlt) && Keyboard.GetState().IsKeyDown(Keys.Enter)) 
                Main.Instance.CurrentGameState = new MainMenu(); // Eventually this should switch to level creation screen

            // Check the device for Player One

            JoystickCapabilities caps = Joystick.GetCapabilities(0);

            if (caps.IsConnected) {
                //Debugger.Debug("Controller Connected");
                // Get the current state of Controller1
                JoystickState state = Joystick.GetState(0);


                if (state.Buttons[9] == ButtonState.Pressed) 
                    Main.Instance.CurrentGameState = new MainGame();
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            base.Draw(spriteBatch, gameTime);
            
            spriteBatch.DrawString(_font, MainText,
                new Vector2(x: Main.Instance.GraphicsDevice.Viewport.Bounds.Width/2 - _font.MeasureString(MainText).X/2, y: Main.Instance.GraphicsDevice.Viewport.Height/2 - _font.MeasureString(MainText).Y/2 ), Color.White);
        }
    }
}