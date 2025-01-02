using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DartsTracker;

public class Game1 : Game {
  private GraphicsDeviceManager Graphics { get; }
  private float Scale { get; }
  private string HoveredTile { get; set; }
  private SpriteBatch SpriteBatch { get; set; }
  private Board Board { get; set; }
  private SpriteFont Font { get; set; }

  public Game1() {
    this.Content.RootDirectory = "Content";
    this.Window.Title = "Darts Tracker";
    this.IsMouseVisible = true;
    this.Graphics = new GraphicsDeviceManager(this);
    this.HoveredTile = "n/a";
    this.Scale = 2.5f;
    this.Graphics.PreferredBackBufferWidth = (int)(450 * this.Scale);
    this.Graphics.PreferredBackBufferHeight = (int)(450 * this.Scale);
  }

  protected override void Initialize() {
    base.Initialize();
  }

  protected override void LoadContent() {
    this.SpriteBatch = new SpriteBatch(GraphicsDevice);
    this.Board = new(this.Content, "Textures/Board");
    this.Font = this.Content.Load<SpriteFont>("Fonts/Consolas");
  }

  protected override void Update(GameTime gameTime) {
    MouseState mouseState = Mouse.GetState();
    Vector2 mousePosition = new(
      (int)(mouseState.X / this.Scale),
      (int)(mouseState.Y / this.Scale)
    );
    this.HoveredTile = this.Board.TileAt(mousePosition);

    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime) {
    GraphicsDevice.Clear(Color.Black);
    this.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

    Vector2 dimensions = new(
      this.Graphics.PreferredBackBufferWidth,
      this.Graphics.PreferredBackBufferHeight
    );
    this.Board.Draw(this.SpriteBatch, dimensions, this.Scale);

    Vector2 textPosition = new(5, 5);
    this.SpriteBatch.DrawString(
      spriteFont: this.Font,
      text: this.HoveredTile,
      position: textPosition,
      color: Color.White,
      rotation: 0f,
      origin: Vector2.Zero,
      scale: 1f,
      effects: SpriteEffects.None,
      layerDepth: 0f
    );

    this.SpriteBatch.End();
    base.Draw(gameTime);
  }
}
