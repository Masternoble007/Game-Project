using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project.Sprites
{
    public class ThreeDTraingle
    {
        /// <summary>
        /// The vertices of the triangle
        /// </summary>
        VertexPositionColor[] vertices;

        /// <summary>
        /// The effect to use rendering the triangle
        /// </summary>
        BasicEffect effect;

        /// <summary>
        /// The game this triangle belongs to 
        /// </summary>
        Game game;

        /// <summary>
        /// Initializes the vertices of the triangle
        /// </summary>
        public void InitializeVertices()
        {
            vertices = new VertexPositionColor[3];
            // vertex 0
            vertices[0].Position = new Vector3(0, 1, 0);
            vertices[0].Color = Color.Red;
            // vertex 1
            vertices[1].Position = new Vector3(1, 1, 0);
            vertices[1].Color = Color.Green;
            // vertex 2 
            vertices[2].Position = new Vector3(1, 0, 0);
            vertices[2].Color = Color.Blue;
        }

        /// <summary>
        /// Initializes the BasicEffect to render our triangle
        /// </summary>
        void InitializeEffect()
        {
            effect = new BasicEffect(game.GraphicsDevice);
            effect.World = Matrix.Identity;
            effect.View = Matrix.CreateLookAt(
                new Vector3(0, 0, 4), // The camera position
                new Vector3(0, 0, 0), // The camera target,
                Vector3.Up            // The camera up vector
            );
            effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,                         // The field-of-view 
                game.GraphicsDevice.Viewport.AspectRatio,   // The aspect ratio
                0.1f, // The near plane distance 
                100.0f // The far plane distance
            );
            effect.VertexColorEnabled = true;
        }

        /// <summary>
        /// Constructs a triangle instance
        /// </summary>
        /// <param name="game">The game that is creating the triangle</param>
        public ThreeDTraingle(Game game)
        {
            this.game = game;
            InitializeVertices();
            InitializeEffect();
        }

        /// <summary>
        /// Rotates the triangle around the y-axis
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Update(GameTime gameTime)
        {
            float angle = (float)gameTime.TotalGameTime.TotalSeconds;
            effect.World = Matrix.CreateFromYawPitchRoll(0,angle,0);
        }


        /// <summary>
        /// Draws the triangle
        /// </summary>
        public void Draw()
        {
            // Cache old rasterizer state
            RasterizerState oldState = game.GraphicsDevice.RasterizerState;

            // Change the backface culling mode
            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.CullClockwiseFace;
            game.GraphicsDevice.RasterizerState = rasterizerState;


            effect.CurrentTechnique.Passes[0].Apply();
            game.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                PrimitiveType.TriangleList,
                vertices,       // The vertex data 
                0,              // The first vertex to use
                1               // The number of triangles to draw
            );

            // Restore the prior rasterizer state 
            game.GraphicsDevice.RasterizerState = oldState;
        }
    }
}
