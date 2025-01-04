using System;
using DartsTracker.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DartsTracker.Screen;

public class ScreenGame : IScreen {
  private string HoveredTile { get; set; }
  private Board Board { get; set; }
  private Viewport BoardViewport { get; set; }
  private Rectangle BoardDestinationRectangle { get; set; }
  private SpriteFont Font { get; set; }
  private Texture2D TurnFrame { get; set; }
  private Viewport TurnFrameViewport { get; set; }
  private Rectangle TurnFrameDestinationRectangle { get; set; }

  public void LoadContent(ContentManager content, GraphicsDeviceManager graphics) {
    // load board
    this.Board = new(
      texture: content.Load<Texture2D>("Textures/Board"),
      tileDelimiter: Color.White
    );

    // load font
    this.Font = content.Load<SpriteFont>("Fonts/Consolas");

    // load turn frame
    this.TurnFrame = new(graphics.GraphicsDevice, width: 1, height: 1);
    this.TurnFrame.SetData([Color.White]);
  }

  public void UnloadContent() {
    this.Board = null;
    this.Font = null;
    this.TurnFrame = null;
  }

  public void Update(Viewport viewport, GameTime gameTime) {
    // update board
    this.BoardViewport = new(
      x: viewport.X,
      y: viewport.Y,
      width: viewport.Width / 3 * 2,
      height: viewport.Height
    );
    float boardScale = Math.Min(
      (float)this.BoardViewport.Width / this.Board.Texture.Width,
      (float)this.BoardViewport.Height / this.Board.Texture.Height
    );
    this.BoardDestinationRectangle = new(
      x: (int)(this.BoardViewport.Width / 2 - this.Board.Texture.Width * boardScale / 2),
      y: (int)(this.BoardViewport.Height / 2 - this.Board.Texture.Height * boardScale / 2),
      width: (int)(this.Board.Texture.Width * boardScale),
      height: (int)(this.Board.Texture.Height * boardScale)
    );

    // update turn frame
    this.TurnFrameViewport = new(
      x: this.BoardViewport.X + this.BoardViewport.Width + 1,
      y: viewport.Y,
      width: viewport.Width - this.BoardViewport.Width,
      height: viewport.Height
    );
    this.TurnFrameDestinationRectangle = this.TurnFrameViewport.Bounds;

    // update hovered tile
    MouseState mouseState = Mouse.GetState();
    Vector2 mousePosition = new(
      x: (int)((mouseState.X - this.BoardDestinationRectangle.X) / boardScale),
      y: (int)((mouseState.Y - this.BoardDestinationRectangle.Y) / boardScale)
    );
    this.HoveredTile = this.Board.TileAt(mousePosition);
  }

  public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
    // draw board
    spriteBatch.Draw(
      texture: this.Board.Texture,
      destinationRectangle: this.BoardDestinationRectangle,
      color: Color.White
    );

    // draw hovered tile
    Vector2 textPosition = new(
      x: this.BoardViewport.X + 5,
      y: this.BoardViewport.Y + 5
    );
    spriteBatch.DrawString(
      spriteFont: this.Font,
      text: this.HoveredTile,
      position: textPosition,
      color: Color.White
    );

    // draw turn frame
    spriteBatch.Draw(
      texture: this.TurnFrame,
      destinationRectangle: this.TurnFrameDestinationRectangle,
      color: Color.White
    );
  }

  public void LoadContent() {
    throw new NotImplementedException();
  }
}
