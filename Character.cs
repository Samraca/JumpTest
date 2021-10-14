 using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jump_Test
{
    class Character
    {
        Texture2D texture;
        Vector2 position;
        Vector2 velocity;
        bool hasjumped;
        Rectangle rect;
        Point pos;

        public Character(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            hasjumped = true;
            pos = new Point(200, 200);
            rect = new Rectangle(pos, new Point(75));
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                velocity.X = 3f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocity.X = -3f;
            }
            else
            {
                velocity.X = 0f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasjumped == false)
            {
                position.Y -= 20f;
                velocity.Y = -15f;
                hasjumped = true;
            }

            if (hasjumped)
            {
                float i = 1;
                velocity.Y += 0.50f * i;
            }


            if (position.Y + texture.Height >= 1080)
            {
                hasjumped = false;
            }

            if (hasjumped == false)
            {
                velocity.Y = 0f;
            }


             if (position.X <= -20)
            {
                position.X = -20f;
            }
            pos = this.Vector2ToPoint(position, pos);
            
            rect.X = pos.X;
            rect.Y = pos.Y;

            
            
        }

        public Point Vector2ToPoint(Vector2 newVector, Point newPoint)
        {
            newPoint.X = Convert.ToInt32(newVector.X);
            newPoint.Y = Convert.ToInt32(newVector.Y);
            return newPoint;
        }

        public void Draw(SpriteBatch spritebatch)
        {
         
            spritebatch.Draw(texture, rect, Color.White);
            
        }
    }
}
