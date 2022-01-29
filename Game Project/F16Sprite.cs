using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game_Project
{

    /// <summary>
    /// Up = Left area
    /// Up2 = Middle
    /// Up3 = Right area
    /// </summary>
    public enum Direction
    {
        Up,
        Up2,
        Up3,
        Right,
        Left
    }

    public class F16Sprite
    {
        private Texture2D texture;

        private double directionTimer;

        private double animationTimer;

        private short animationFrame = 1;

        /// <summary>
        /// The direction of the jet
        /// </summary>
        public Direction Direction;

        /// <summary>
        /// The position of the jet
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Loads the jet sprite texture
        /// </summary>
        /// <param name="content">The ContentManager load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("f-16_blank_strip3");
        }

        /// <summary>
        /// Updates the plane sprite to fly in a pattern
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public void Update(GameTime gameTime)
        {
            //Update the direction timer
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;

            //Switch directions every 4 seconds
            if (directionTimer > 4.0)
            {
                switch (Direction)
                {
                    case Direction.Up:
                        Direction = Direction.Right;
                        break;
                    case Direction.Up2:
                        Direction = Direction.Up2;
                        break;
                    case Direction.Up3:
                        Direction = Direction.Left;
                        break;
                    case Direction.Left:
                        Direction = Direction.Up;
                        break;
                    case Direction.Right:
                        Direction = Direction.Up3;
                        break;
                }
            }

            // Move the bat in the direction it is flying
            switch (Direction)
            {
                case Direction.Left:
                    Position += new Vector2(-1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Right:
                    Position += new Vector2(1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;

                    ///Trying to have start on the left side going straight then straft to the right and stop, then to the left and repeat.
                    /*
                case Direction.Up:
                    Position += new Vector2(0, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Up3:
                    Position += new Vector2(0, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                    */
            }
        }
            /// <summary>
            /// Draws the animated plane sprite
            /// </summary>
            /// <param name="gameTime">The game time</param>
            /// <param name="spriteBatch">The SpriteBatch to draw with</param>
            public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            {
                //Update animation timer
                animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

                //Update animation frame
                if (animationTimer > 0.3)
                {
                    animationFrame++;
                    if (animationFrame > 3) animationFrame = 1;
                    animationTimer -= 0.3;
                }
                //Draw the sprite
                var source = new Rectangle(animationFrame * 32, (int)Direction * 32, 96, 32);
                spriteBatch.Draw(texture, Position, source, Color.Gray);
            }
        }
    }

