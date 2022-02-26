using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Game_Project
{
    public class GameProject : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        //private Ball ball;
        //private Rectangle rectangle;
        //private Triangle triangle;
        //private Square square;
        private F16Sprite f16;
        private SpriteFont overhaul;
        private f5Sprite[] f5s;
        private int f5planes;
        private Song backgroundMusic;
        private SoundEffect planeExploding;

        public GameProject()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Game Project 0";
        }

        protected override void Initialize()
        {
            System.Random rand = new System.Random();
            //ball = new Ball(this, Color.Red) {Position = new Vector2(25, 50)};
            //rectangle = new Rectangle(this, Color.Yellow) {Position = new Vector2(25, 400)};
            //square = new Square(this, Color.Green) { Position = new Vector2(700, 400) };
            //triangle = new Triangle(this, Color.Blue) { Position = new Vector2(700, 50) };
            f16 = new F16Sprite();
            f5s = new f5Sprite[]
            {
                new f5Sprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new f5Sprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new f5Sprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
            };
            f5planes = f5s.Length;
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //ball.LoadContent();
            //rectangle.LoadContent();
            //triangle.LoadContent();
            //square.LoadContent();
            f16.LoadContent(Content);
            foreach (var f5 in f5s) f5.LoadContent(Content);
            overhaul = Content.Load<SpriteFont>("Overhaul");
            planeExploding = Content.Load<SoundEffect>("PlaneExploding");
            backgroundMusic = Content.Load<Song>("Jack_Adkins-The_Bomb");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.G) || GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed) Exit();

            f16.Update(gameTime);

            foreach (var f5 in f5s)
            {
                if (!f5.touched && f5.Bounds.CollidesWith(f16.Bounds))
                {
                    f16.Color = Color.Red;
                    f5.touched = true;
                    f5planes--;
                    planeExploding.Play();
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            overhaul.MeasureString("To give instructions to exit the game.");


            spriteBatch.Begin();

            foreach (var f5 in f5s)
            {
                f5.Draw(gameTime, spriteBatch);
            }
            //ball.Draw(spriteBatch);
            //rectangle.Draw(spriteBatch);
            //triangle.Draw(spriteBatch);
            //square.Draw(spriteBatch);
            //spriteBatch.DrawString(overhaul, $"{"To exit the game, press g or start from the controller."}", new Vector2(125, 400), Color.Black);
            //spriteBatch.DrawString(overhaul, $"{"Press W A S D (or number keys) to move the plane"}", new Vector2(150, 75), Color.Black);
            f16.Draw(gameTime, spriteBatch);
            
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
