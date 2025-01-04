using DartsTracker.Screen;
using Microsoft.Xna.Framework;

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
    this.Screen = new();
  }

  protected override void Initialize() {
    base.Initialize();
  }

  protected override void LoadContent() {
    this.Screen.LoadContent(this.Content, this.GraphicsDevice);
    // base.LoadContent() is empty
  }

  protected override void UnloadContent() {
    this.Screen.UnloadContent();
    // base.UnloadContent() is empty
  }

  protected override void Update(GameTime gameTime) {
    this.Screen.Update(this.Graphics.GraphicsDevice.Viewport, gameTime);
    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime) {
    this.Screen.Draw(this.GraphicsDevice, gameTime);
    base.Draw(gameTime);
  }
}
