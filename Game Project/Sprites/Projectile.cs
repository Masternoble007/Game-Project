using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CollisionExample.Collisions;
using Microsoft.Xna.Framework.Content;

namespace Game_Project.Sprites
{
    public class Projectile
    {

        const float LINEAR_ACCELERATION = 10;
        private float timer;
        public Direction direction;
        public Vector2 position;
        public Vector2 velocity;
        private Texture2D texture;



        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("projectile");
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            


        }

        public void Draw()
        {

        }
        
    }
}
