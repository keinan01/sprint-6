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
using System.Diagnostics;
namespace Memory_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        enum gameStages
        {
            StartScreen,
            PlayScreen,
            EndScreen
        }
        List<Card> cards = new List<Card>();
        Texture2D startScreen;
        Texture2D[] texts = new Texture2D[13];
        int x, m, rx, ry;
        MouseState mouseState;
        Vector2 screen;
        gameStages stage = gameStages.StartScreen;
        public Game1()
        {
            this.Window.AllowUserResizing = true;


            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();
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
            screen = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            base.Initialize();
            x = 0;
            rx = 0;
            ry = 0;
            Rectangle[] rects = new Rectangle[24];
            for (int i = 0; i < 4; i++)
            {
                for (int e = 0; e < 6; e++)
                {
                    rects[x] = new Rectangle(rx, ry, 75, 90);
                    x++;
                    rx += 75;
                }
                ry += 90;
            }
            m = 0;
            for (int i = 0; i < 24; i++)
            {
                cards.Add(new Card(m, rects[i]));
                //cards.Add(new Card(m, new Rectangle(0, 0, 12, 201)));

                Debug.WriteLine(cards[i].texs[m]);
                //Debug.WriteLine(m);
                m++;
                if (m > 12)
                {
                    m = 0;
                }
                
            }

            //cards[0] = new Card(m, new Rectangle(0, 0, 0, 0));



        }

        

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            startScreen = this.Content.Load<Texture2D>("start screen");

            texts[0] = this.Content.Load<Texture2D>("1");
            texts[1] = this.Content.Load<Texture2D>("2");
            texts[2] = this.Content.Load<Texture2D>("3");
            texts[3] = this.Content.Load<Texture2D>("4");
            texts[4] = this.Content.Load<Texture2D>("5");
            texts[5] = this.Content.Load<Texture2D>("6");
            texts[6] = this.Content.Load<Texture2D>("7");
            texts[7] = this.Content.Load<Texture2D>("8");
            texts[8] = this.Content.Load<Texture2D>("9");
            texts[9] = this.Content.Load<Texture2D>("10");
            texts[10] = this.Content.Load<Texture2D>("11");
            texts[11] = this.Content.Load<Texture2D>("12");
            texts[12] = this.Content.Load<Texture2D>("13");

            for (int i = 0; i < cards.Count; i++)
            {
                //Console.WriteLine(cards[1].texs.Length);
                //cards[i].texs = texts;
                //texts.CopyTo(cards[i].texs, 0);
                cards[i].texs[0] = texts[0];
                cards[i].texs[1] = texts[1];
                cards[i].texs[2] = texts[2];
                cards[i].texs[3] = texts[3];
                cards[i].texs[4] = texts[4];
                cards[i].texs[5] = texts[5];
                cards[i].texs[6] = texts[6];
                cards[i].texs[7] = texts[7];
                cards[i].texs[8] = texts[8];
                cards[i].texs[9] = texts[9];
                cards[i].texs[10] = texts[10];
                cards[i].texs[11] = texts[11];
                cards[i].texs[12] = texts[12];
                
            }
            for (int e = 0; e < texts.Length; e++)
            {
                //Debug.WriteLine(cards[i].texs[e]);
                Debug.WriteLine(texts[e]);
            }


            //Card[] cardsArray = cards.ToArray();

            //for (int i = 0; i < cards.Count; i++)
            //{
            //    for (int e = 0; e < texts.Length; e++)
            //    {
            //        cardsArray[i].texs[e] = texts[0];
            //    }
            //}


            //cards = cardsArray.ToList();
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
            mouseState = Mouse.GetState();
            // TODO: Add your update logic here

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                stage = gameStages.PlayScreen;
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

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (stage == gameStages.StartScreen)
            {
                spriteBatch.Draw(startScreen, new Rectangle(0, 0, (int)screen.X, (int)screen.Y), Color.White);
            }
            for (int i = 0; i < 24; i++)
            {
                cards[i].Draw(spriteBatch);
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
