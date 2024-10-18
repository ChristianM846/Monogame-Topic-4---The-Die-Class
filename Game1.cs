using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Monogame_Topic_4___The_Die_Class
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        KeyboardState keyboardState, prevKeyboardState;
        MouseState mouseState, prevMouseState;

        List<Texture2D> dieTextures;
        List<Die> dice;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            dieTextures = new List<Texture2D>();
            dice = new List<Die>();

            for (int x = 0; x <= 7; x ++)
            {
                for (int i = 0; i < 6; i++)
                {
                    dice.Add(new Die(dieTextures, new Rectangle(100 * x + 10, i * 75 + 10, 75, 75)));
                }
            }
            

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            for (int i = 1; i <= 6; i++)
            {
                dieTextures.Add(Content.Load<Texture2D>($"Images/white_die_{i}"));
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            if (keyboardState.IsKeyDown(Keys.Space) && prevKeyboardState.IsKeyUp(Keys.Space))
            {
                foreach (Die die in dice)
                {
                    die.RollDie();
                }

            }

            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                for (int i = 0; i < dice.Count; i++)
                {
                   if (dice[i].Location.Contains(mouseState.Position))
                   {
                        dice.Remove(dice[i]);
                   }
                }

                if (dice.Count == 0)
                {
                    for (int x = 0; x <= 7; x++)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            dice.Add(new Die(dieTextures, new Rectangle(100 * x + 10, i * 75 + 10, 75, 75)));
                        }
                    }
                }

            }

            if (mouseState.RightButton == ButtonState.Pressed && prevMouseState.RightButton == ButtonState.Released)
            {
                dice.Clear();

                for (int x = 0; x <= 7; x++)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        dice.Add(new Die(dieTextures, new Rectangle(100 * x + 10, i * 75 + 10, 75, 75)));
                    }
                }
            }


            prevKeyboardState = keyboardState;
            prevMouseState = mouseState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            foreach (Die die in dice)
            {
                die.DrawRoll(_spriteBatch);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
