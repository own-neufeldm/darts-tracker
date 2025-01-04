using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DartsTracker.Screen;

public interface IScreen {
  public void LoadContent(
    ContentManager content,
    GraphicsDeviceManager graphics
  );

  public void UnloadContent();

  public void Update(Viewport viewport, GameTime gameTime);

  public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
}
