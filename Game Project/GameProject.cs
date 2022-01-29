using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Project
{
    public class GameProject : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private Ball ball;
        private Rectangle1 rectangle;
        private Triangle triangle;
        private Square square;
        private F16Sprite f16;
        private SpriteFont overhaul;

        public GameProject()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Game Project 0";
        }

        protected override void Initialize()
        {
            ball = new Ball(this, Color.Red) {Position = new Vector2(25, 50)};
            rectangle = new Rectangle1(this, Color.Yellow) {Position = new Vector2(25, 400)};
            square = new Square(this, Color.Green) { Position = new Vector2(700, 400) };
            triangle = new Triangle(this, Color.Blue) { Position = new Vector2(700, 50) };
            f16 = new F16Sprite() {Position = new Vector2(375, 200), Direction = Direction.Up };
            
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ball.LoadContent();
            rectangle.LoadContent();
            triangle.LoadContent();
            square.LoadContent();
            f16.LoadContent(Content);
            overhaul = Content.Load<SpriteFont>("Overhaul");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.G) || GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed) Exit();

            f16.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            overhaul.MeasureString("To give instructions to exit the game.");


            spriteBatch.Begin();

            ball.Draw(spriteBatch);
            rectangle.Draw(spriteBatch);
            triangle.Draw(spriteBatch);
            square.Draw(spriteBatch);
            spriteBatch.DrawString(overhaul, $"{"To exit the game, press g or start from the controller."}", new Vector2(125, 400), Color.Black);
            spriteBatch.DrawString(overhaul, $"{"Some soon to be fighter jet game."}", new Vector2(200, 75), Color.Black);
            f16.Draw(gameTime, spriteBatch);
            
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
