using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    public class Square
    {
        /// <summary>
        /// The game this square is a part of
        /// </summary>
        Game game;

        /// <summary>
        /// A color to help distinguish one square from another
        /// </summary>
        Color color;

        /// <summary>
        /// The texture to apply to a square
        /// </summary>
        Texture2D texture;

        /// <summary>
        /// The position of the square in the game world
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Constructs a new square instance
        /// </summary>
        /// <param name="game">The game this square belongs in</param>
        /// <param name="color">A color to distinguish this square</param>
        public Square(Game game, Color color)
        {
            this.game = game;
            this.color = color;
        }

        /// <summary>
        /// Loads the square's texture
        /// </summary>
        public void LoadContent()
        {
            texture = game.Content.Load<Texture2D>("Square");
        }

        /// <summary>
        /// Draws the square at its current position and with 
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
