using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    public class Rectangle
    {
        /// <summary>
        /// The game this rectangle is a part of
        /// </summary>
        Game game;

        /// <summary>
        /// A color to help distinguish one rectangle from another
        /// </summary>
        Color color;

        /// <summary>
        /// The texture to apply to a rectangle
        /// </summary>
        Texture2D texture;

        /// <summary>
        /// The position of the rectangle in the game world
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Constructs a new rectangle instance
        /// </summary>
        /// <param name="game">The game this rectangle belongs in</param>
        /// <param name="color">A color to distinguish this rectangle</param>
        public Rectangle(Game game, Color color)
        {
            this.game = game;
            this.color = color;
        }

        /// <summary>
        /// Loads the rectangle's texture
        /// </summary>
        public void LoadContent()
        {
            texture = game.Content.Load<Texture2D>("Rectangle");
        }

        /// <summary>
        /// Draws the rectangle at its current position and with 
        /// its assigned color
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to render with</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture is null) throw new InvalidOperationException("Texture must be loaded to render");
            spriteBatch.Draw(texture, Position, color);
        }
    }
}
