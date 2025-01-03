using System;
using DartsTracker.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DartsTracker.Screen;

public class ScreenManager : IDisposable {
  private GraphicsDeviceManager Graphics { get; }
  private SpriteBatch SpriteBatch { get; }
  private ContentManager Content { get; }

  private float Scale { get; }
  private string HoveredTile { get; set; }

  private Board Board { get; set; }
  private Rectangle BoardDestinationRectangle { get; set; }

  private SpriteFont Font { get; set; }
  private Vector2 TextPosition { get; set; }

  private Texture2D TurnFrame { get; set; }
  private Rectangle TurnFrameDestinationRectangle { get; set; }

  public ScreenManager(
    GraphicsDeviceManager graphics,
    SpriteBatch spriteBatch,
    ContentManager content
  ) {
    this.Graphics = graphics;
    this.SpriteBatch = spriteBatch;
    this.Content = content;
    this.Scale = 2f;
    this.HoveredTile = "n/a";
  }

  public void LoadContent() {
    // load board
    this.Board = new(
      texture: this.Content.Load<Texture2D>("Textures/Board"),
      tileDelimiter: Color.White
    );
    Vector2 boardScreen = new(
      x: this.Graphics.PreferredBackBufferWidth / 3 * 2,
      y: this.Graphics.PreferredBackBufferHeight
    );
    this.BoardDestinationRectangle = new(
      x: (int)((boardScreen.X - this.Board.Texture.Width * this.Scale) / 2),
      y: (int)((boardScreen.Y - this.Board.Texture.Height * this.Scale) / 2),
      width: (int)(this.Board.Texture.Width * this.Scale),
      height: (int)(this.Board.Texture.Height * this.Scale)
    );

    // load font
    this.Font = this.Content.Load<SpriteFont>("Fonts/Consolas");
    this.TextPosition = new(5, 5);

    // load turn frame
    Vector2 turnFrameScreen = new(
      x: this.Graphics.PreferredBackBufferWidth - this.Graphics.PreferredBackBufferWidth / 3,
      y: 0
    );
    this.TurnFrameDestinationRectangle = new(
      x: (int)turnFrameScreen.X,
      y: (int)turnFrameScreen.Y,
      width: (int)(this.Graphics.PreferredBackBufferWidth - turnFrameScreen.X),
      height: (int)(this.Graphics.PreferredBackBufferHeight - turnFrameScreen.Y)
    );
    this.TurnFrame = new(
      graphicsDevice: this.Graphics.GraphicsDevice,
      width: this.TurnFrameDestinationRectangle.Width,
      height: this.TurnFrameDestinationRectangle.Height
    );
    Color[] turnFrameData = new Color[this.TurnFrameDestinationRectangle.Width * this.TurnFrameDestinationRectangle.Height];
    Array.Fill(turnFrameData, Color.White);
    this.TurnFrame.SetData(turnFrameData);
  }

  public void UnloadContent() {
    this.Board = null;
    this.Font = null;
  }

  public void Update(GameTime gameTime) {
    MouseState mouseState = Mouse.GetState();
    Vector2 mousePosition = new(
      x: (int)((mouseState.X - this.BoardDestinationRectangle.X) / this.Scale),
      y: (int)((mouseState.Y - this.BoardDestinationRectangle.Y) / this.Scale)
    );
    this.HoveredTile = this.Board.TileAt(mousePosition);
  }

  public void Draw(GameTime gameTime) {
    this.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
    this.Draw();
    this.SpriteBatch.End();
  }

  private void Draw() {
    // draw board
    this.SpriteBatch.Draw(
      texture: this.Board.Texture,
      destinationRectangle: this.BoardDestinationRectangle,
      color: Color.White
    );

    // draw hovered tile
    this.SpriteBatch.DrawString(
      spriteFont: this.Font,
      text: this.HoveredTile,
      position: this.TextPosition,
      color: Color.White
    );

    // draw turn frame
    this.SpriteBatch.Draw(
      texture: this.TurnFrame,
      destinationRectangle: this.TurnFrameDestinationRectangle,
      color: Color.White
    );
  }

  void IDisposable.Dispose() {
    this.UnloadContent();
    GC.SuppressFinalize(this);
  }
}
