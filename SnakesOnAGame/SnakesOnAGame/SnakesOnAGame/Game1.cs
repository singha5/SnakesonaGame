using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SnakesOnAGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D snakeTexture;
        Texture2D FoodTexture;
        Rectangle currentSquare;

        float timeRemaining = 0.0f;
        const float TimePerSquare = 0.75f;

        Random rand = new Random();
        List <Vector2> snake = new List <Vector2>();
        List<Vector2> Food = new List<Vector2>();

        Vector2 pellet = new Vector2(2, 2);//rand.Next(1, 10),rand.Next(1,10));
        Vector2 velocity = new Vector2(0, -1);

        Color[] colors = new Color[5] { Color.Red, Color.PowderBlue, 
        Color.SteelBlue, Color.Tomato, Color.IndianRed };

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Food.Add(new Vector2(45, 29));
            snake.Add(new Vector2(40, 24));
           


            snakeTexture = Content.Load<Texture2D>(@"SQUARE");

            FoodTexture = Content.Load<Texture2D>(@"Food");


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.Up))
            {
                velocity = new Vector2(0, -1);
            }

            if (kb.IsKeyDown(Keys.Down))
            {
                velocity = new Vector2(0, 1);
            }

            if (kb.IsKeyDown(Keys.Left))
            {
                velocity = new Vector2(-1, 0);
            }

            if (kb.IsKeyDown(Keys.Right))
            {
                velocity = new Vector2(1, 0);
                
            }

            if (true)
            {
                timeRemaining = 0.05f;
                snake[0] += velocity;
            }

            if (timeRemaining == 0.0f)
            {
                currentSquare = new Rectangle(
                rand.Next(0, this.Window.ClientBounds.Width - 25),
                rand.Next(0, this.Window.ClientBounds.Height - 25),
                25, 25);
                timeRemaining = TimePerSquare;
            }

            if (snake[0] == Food[0])
            {
                snake.Add(new Vector2(2, 1));
                Food[0] = new Vector2(1000, 1000);
                pellet = new Vector2(1000, 1000);

                //Food.Add(new Vector2(rand.Next(1,100), rand.Next(1,100)));
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();
            for (int i = 0; i < snake.Count; i++)
            {
                spriteBatch.Draw(FoodTexture, Food[0], colors[i]);
                spriteBatch.Draw(snakeTexture, snake[i] * 10, colors[i]);
                
                
               
            }
            spriteBatch.End();


            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
