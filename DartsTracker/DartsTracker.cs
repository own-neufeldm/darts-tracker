using DartsTracker.Screen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DartsTracker;

public class DartsTracker : Game {
  private GraphicsDeviceManager Graphics { get; }
  private ScreenManager Screen { get; set; }

  public DartsTracker() {
    this.Content.RootDirectory = "Content";
    this.Window.Title = "Darts Tracker";
    this.IsMouseVisible = true;
    this.Graphics = new GraphicsDeviceManager(this) {
      PreferredBackBufferWidth = 1600,
      PreferredBackBufferHeight = 900
    };
  }

  protected override void Initialize() {
    base.Initialize();
  }

  protected override void LoadContent() {
    SpriteBatch spriteBatch = new(this.GraphicsDevice);
    this.Screen = new(this.Graphics, spriteBatch, this.Content);
    this.Screen.LoadContent();
    // base.LoadContent() is empty
  }

  protected override void UnloadContent() {
    this.Screen.UnloadContent();
    // base.UnloadContent() is empty
  }

  protected override void Update(GameTime gameTime) {
    this.Screen.Update(gameTime);
    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime) {
    this.GraphicsDevice.Clear(Color.Black);
    this.Screen.Draw(gameTime);
    base.Draw(gameTime);
  }
}
