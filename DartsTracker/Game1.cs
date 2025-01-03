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
  private Rectangle BoardDestinationRectangle { get; set; }
  private SpriteFont Font { get; set; }
  private Vector2 TextPosition { get; set; }

  public Game1() {
    this.Content.RootDirectory = "Content";
    this.Window.Title = "Darts Tracker";
    this.IsMouseVisible = true;
    this.Graphics = new GraphicsDeviceManager(this) {
      PreferredBackBufferWidth = 1600,
      PreferredBackBufferHeight = 900
    };
    this.Scale = 2f;
    this.HoveredTile = "n/a";
  }

  protected override void Initialize() {
    base.Initialize();
  }

  protected override void LoadContent() {
    this.SpriteBatch = new SpriteBatch(GraphicsDevice);

    this.Board = new(
      texture: this.Content.Load<Texture2D>("Textures/Board"),
      tileDelimiter: Color.White
    );
    this.BoardDestinationRectangle = new(
      x: (int)((this.Graphics.PreferredBackBufferWidth - this.Board.Texture.Width * this.Scale) / 2),
      y: (int)((this.Graphics.PreferredBackBufferHeight - this.Board.Texture.Height * this.Scale) / 2),
      width: (int)(this.Board.Texture.Width * this.Scale),
      height: (int)(this.Board.Texture.Height * this.Scale)
    );

    this.Font = this.Content.Load<SpriteFont>("Fonts/Consolas");
    this.TextPosition = new(5, 5);
  }

  protected override void Update(GameTime gameTime) {
    MouseState mouseState = Mouse.GetState();
    Vector2 mousePosition = new(
      x: (int)((mouseState.X - this.BoardDestinationRectangle.X) / this.Scale),
      y: (int)((mouseState.Y - this.BoardDestinationRectangle.Y) / this.Scale)
    );
    this.HoveredTile = this.Board.TileAt(mousePosition);

    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime) {
    GraphicsDevice.Clear(Color.Black);
    this.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

    this.SpriteBatch.Draw(
      texture: this.Board.Texture,
      destinationRectangle: this.BoardDestinationRectangle,
      color: Color.White
    );
    this.SpriteBatch.DrawString(
      spriteFont: this.Font,
      text: this.HoveredTile,
      position: this.TextPosition,
      color: Color.White
    );

    this.SpriteBatch.End();
    base.Draw(gameTime);
  }
}
