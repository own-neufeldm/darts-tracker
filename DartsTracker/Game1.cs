using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DartsTracker;

public class Game1 : Game
{
  private readonly GraphicsDeviceManager Graphics;
  private SpriteBatch SpriteBatch;
  private Texture2D BoardTexture;

  public Game1()
  {
    this.Graphics = new GraphicsDeviceManager(this);
    this.Window.Title = "Darts Tracker";
    this.Content.RootDirectory = "Content";
    this.IsMouseVisible = true;
  }

  protected override void Initialize()
  {
    base.Initialize();
  }

  protected override void LoadContent()
  {
    this.SpriteBatch = new SpriteBatch(GraphicsDevice);
    this.BoardTexture = this.Content.Load<Texture2D>("Board");
  }

  protected override void Update(GameTime gameTime)
  {
    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime)
  {
    GraphicsDevice.Clear(Color.Black);
    this.SpriteBatch.Begin();
    this.Draw();
    this.SpriteBatch.End();
    base.Draw(gameTime);
  }

  private void Draw()
  {
    Vector2 position = new(
      x: this.Graphics.PreferredBackBufferWidth / 2,
      y: this.Graphics.PreferredBackBufferHeight / 2
    );
    Vector2 origin = new(
      x: this.BoardTexture.Width / 2,
      y: this.BoardTexture.Height / 2
    );
    this.SpriteBatch.Draw(
      texture: this.BoardTexture,
      position: position,
      sourceRectangle: null,
      color: Color.White,
      rotation: 0f,
      origin: origin,
      scale: 1f,
      effects: SpriteEffects.None,
      layerDepth: 0f
    );
  }
}
