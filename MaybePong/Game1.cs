using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MaybePong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D paddleLeftTexture;
        private Rectangle paddleLeftShape;
        private Point paddleLeftPosition;

        private Texture2D paddleRightTexture;
        private Rectangle paddleRightShape;
        private Point paddleRightPosition;

        private Rectangle ballShape;
        private Texture2D ballTexture;
        private Point ballPosition;

        private const int Margin = 10;
        private Point velocity;

        private bool up;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            paddleLeftPosition.X = 5;
            paddleLeftShape = new Rectangle(0, 0, 10, 100);
            paddleLeftTexture = new Texture2D(GraphicsDevice, paddleLeftShape.Width, paddleLeftShape.Height);
            Fill(paddleLeftTexture);

            paddleRightPosition.X = graphics.PreferredBackBufferWidth - Margin - 5;
            paddleRightShape = new Rectangle(0, 0, 10, 100);
            paddleRightTexture = new Texture2D(GraphicsDevice, paddleRightShape.Width, paddleRightShape.Height);
            Fill(paddleRightTexture);

            ballPosition.Y = (graphics.PreferredBackBufferHeight - ballShape.Height) / 2;
            ballPosition.X = (graphics.PreferredBackBufferWidth - ballShape.Width) / 2;
            ballShape = new Rectangle(0, 0, 10, 10);
            ballTexture = new Texture2D(GraphicsDevice, ballShape.Width, ballShape.Height);
            Fill(ballTexture);

            velocity.X = 1;
            velocity.Y = 1;
        }

        private void Fill(Texture2D texture2D)
        {
            Color[] data = new Color[paddleLeftShape.Width * paddleLeftShape.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Black;
            texture2D.SetData(data);
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Up))
            {
                if (paddleLeftPosition.Y > Margin)
                    paddleLeftPosition.Y -= Margin;
                else
                    paddleLeftPosition.Y = 0;
            }
            if (newState.IsKeyDown(Keys.Down))
            {
                if (paddleLeftPosition.Y + Margin + paddleLeftShape.Height < graphics.PreferredBackBufferHeight)
                    paddleLeftPosition.Y += Margin;
                else
                    paddleLeftPosition.Y = graphics.PreferredBackBufferHeight - paddleLeftShape.Height;
            }



            ballPosition.Y += velocity.Y;
            ballPosition.X += velocity.X;



            if (ballPosition.Y + Margin + ballShape.Height >= graphics.PreferredBackBufferHeight)
            {
                velocity.Y = -1 * (Math.Abs(velocity.Y) + 1);
            }

            if (ballPosition.Y <= Margin)
            {
                velocity.Y = Math.Abs(velocity.Y) + 1;
            }




            if (ballPosition.X + Margin + ballShape.Width >= graphics.PreferredBackBufferWidth)
            {
                velocity.X = -1 * (Math.Abs(velocity.X) + 1);
            }

            if (ballPosition.X <= Margin)
            {
                velocity.X = Math.Abs(velocity.X) + 1;
            }





            //if (ballPosition.X + 10 + ballShape.Width<= graphics.PreferredBackBufferWidth)
            //{
            //    ballPosition.X += 1;
            //}
            //else
            //{
            //    ballPosition.X -= 1;
            //}




            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            spriteBatch.Begin();
            paddleLeftShape.Location = paddleLeftPosition;
            spriteBatch.Draw(paddleLeftTexture, paddleLeftShape, Color.White);

            paddleRightShape.Location = paddleRightPosition;
            spriteBatch.Draw(paddleRightTexture, paddleRightShape, Color.White);

            ballShape.Location = ballPosition;
            spriteBatch.Draw(ballTexture, ballShape, Color.White);
            spriteBatch.End();
        }
    }
}
