using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CollisionExample.Collisions;


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
        Right,
        Left
    }

    public class F16Sprite
    {
        private GamePadState gamePadState;

        private KeyboardState keyboardState;

        private Texture2D texture;

        private bool Left;

        private bool Right;

        private double animationTimer;

        private short animationFrame = 1;

        /// <summary>
        /// The direction of the jet
        /// </summary>
        public Direction Direction;

        /// <summary>
        /// The position of the jet
        /// </summary>
        public Vector2 position = new Vector2(375, 350);

        /// <summary>
        /// 
        /// </summary>
        private BoundingRectangle bounds = new BoundingRectangle(new Vector2(375 - 16, 350 - 16), 32, 32);

        /// <summary>
        /// The bounding volume of the sprite
        /// </summary>
        public BoundingRectangle Bounds => bounds;

        /// <summary>
        /// The color blend with the ghost
        /// </summary>
        public Color Color { get; set; } = Color.White;

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
            gamePadState = GamePad.GetState(0);
            keyboardState = Keyboard.GetState();

            // Apply the gamepad movement with inverted Y axis
            position += gamePadState.ThumbSticks.Left * new Vector2(1, -1);

            if (gamePadState.ThumbSticks.Left.X < 0)
            {
                Direction = Direction.Left;
            }
            else if (gamePadState.ThumbSticks.Left.X > 0)
            {
                Direction = Direction.Right;
            }
            else
            {
                Direction = Direction.Up;
            }

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W)) position += new Vector2(0, -1);
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S)) position += new Vector2(0, 1);
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                position += new Vector2(-1, 0);
                Direction = Direction.Left;
            }
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                position += new Vector2(1, 0);
                Direction = Direction.Right;
            }
            bounds.X = position.X - 16;
            bounds.Y = position.Y - 16;
        }
            /// <summary>
            /// Draws the animated plane sprite
            /// </summary>
            /// <param name="gameTime">The game time</param>
            /// <param name="spriteBatch">The SpriteBatch to draw with</param>
            public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            {
                //Draw the sprite
                var source = new Microsoft.Xna.Framework.Rectangle(32, 32, 96, 32);
                spriteBatch.Draw(texture, position, source, Color.Gray);
            }
        }
    }

