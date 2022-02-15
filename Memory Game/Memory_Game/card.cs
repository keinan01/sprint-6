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
    class Card
    {
        public Texture2D[] texs = new Texture2D[13];
        int textIndex;
        Rectangle posRect;
        bool isFaceUp;

        public Card(int textIndex, Rectangle rect)
        {
            this.textIndex = textIndex;
            this.posRect = rect;
            isFaceUp = false;
            //texs = new Texture2D[13];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Console.WriteLine(texs[textIndex]);
            spriteBatch.Draw(texs[textIndex], posRect, Color.White);

        }

        bool Contains(int x, int y)
        {
            if(posRect.Contains(x, y))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        bool Equals(Card other)
        {
            if (textIndex.Equals(other.textIndex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void FlipCard()
        {
            isFaceUp = true;
        }

    }
}
