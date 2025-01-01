using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DartsTracker;

public class Board {
  public Texture2D Texture { get; }
  private Color[] TextureData { get; }
  private Color TileDelimiter { get; }
  private Dictionary<string, List<Vector2>> Tiles { get; }

  public Board(ContentManager content, string assetName) {
    this.Texture = content.Load<Texture2D>(assetName);
    this.TextureData = new Color[this.Texture.Width * this.Texture.Height];
    this.Texture.GetData(this.TextureData);
    this.TileDelimiter = Color.White;
    this.Tiles = [];
    this.LoadTiles();
  }

  public void Draw(SpriteBatch spriteBatch, Vector2 dimensions, float scale) {
    Vector2 position = new(
      dimensions.X / 2 - this.Texture.Width * scale / 2,
      dimensions.Y / 2 - this.Texture.Height * scale / 2
    );

    spriteBatch.Draw(
      texture: this.Texture,
      position: position,
      sourceRectangle: null,
      color: Color.White,
      rotation: 0f,
      origin: Vector2.Zero,
      scale: scale,
      effects: SpriteEffects.None,
      layerDepth: 0f
    );
  }

  public string TileAt(Vector2 point) {
    foreach (KeyValuePair<string, List<Vector2>> pair in this.Tiles)
      if (pair.Value.Contains(point))
        return pair.Key;
    return "n/a";
  }

  private void LoadTiles() {
    // miss
    this.Tiles.Add("0", this.LoadTile([new(210, 5)]));

    // bullseye
    this.Tiles.Add("25", this.LoadTile([new(221, 210)]));
    this.Tiles.Add("D25", this.LoadTile([new(222, 219)]));

    // twenty
    this.Tiles.Add("20", this.LoadTile([new(200, 65), new(210, 127)]));
    this.Tiles.Add("D20", this.LoadTile([new(198, 58)]));
    this.Tiles.Add("T20", this.LoadTile([new(209, 120)]));

    // one
    this.Tiles.Add("1", this.LoadTile([new(251, 65), new(241, 127)]));
    this.Tiles.Add("D1", this.LoadTile([new(253, 58)]));
    this.Tiles.Add("T1", this.LoadTile([new(242, 120)]));

    // eighteen
    this.Tiles.Add("18", this.LoadTile([new(298, 80), new(269, 137)]));
    this.Tiles.Add("D18", this.LoadTile([new(301, 74)]));
    this.Tiles.Add("T18", this.LoadTile([new(273, 130)]));

    // four
    this.Tiles.Add("4", this.LoadTile([new(339, 110), new(294, 155)]));
    this.Tiles.Add("D4", this.LoadTile([new(344, 105)]));
    this.Tiles.Add("T4", this.LoadTile([new(299, 150)]));

    // thirteen
    this.Tiles.Add("13", this.LoadTile([new(369, 153), new(313, 181)]));
    this.Tiles.Add("D13", this.LoadTile([new(375, 150)]));
    this.Tiles.Add("T13", this.LoadTile([new(319, 178)]));

    // six
    this.Tiles.Add("6", this.LoadTile([new(384, 200), new(322, 210)]));
    this.Tiles.Add("D6", this.LoadTile([new(391, 198)]));
    this.Tiles.Add("T6", this.LoadTile([new(329, 209)]));

    // ten
    this.Tiles.Add("10", this.LoadTile([new(384, 251), new(322, 241)]));
    this.Tiles.Add("D10", this.LoadTile([new(391, 253)]));
    this.Tiles.Add("T10", this.LoadTile([new(329, 242)]));

    // fifteen
    this.Tiles.Add("15", this.LoadTile([new(369, 298), new(312, 269)]));
    this.Tiles.Add("D15", this.LoadTile([new(375, 301)]));
    this.Tiles.Add("T15", this.LoadTile([new(319, 273)]));

    // two
    this.Tiles.Add("2", this.LoadTile([new(339, 339), new(294, 295)]));
    this.Tiles.Add("D2", this.LoadTile([new(344, 344)]));
    this.Tiles.Add("T2", this.LoadTile([new(299, 300)]));

    // seventeen
    this.Tiles.Add("17", this.LoadTile([new(296, 370), new(268, 313)]));
    this.Tiles.Add("D17", this.LoadTile([new(299, 376)]));
    this.Tiles.Add("T17", this.LoadTile([new(271, 319)]));

    // three
    this.Tiles.Add("3", this.LoadTile([new(249, 384), new(239, 322)]));
    this.Tiles.Add("D3", this.LoadTile([new(251, 391)]));
    this.Tiles.Add("T3", this.LoadTile([new(240, 329)]));

    // nineteen
    this.Tiles.Add("19", this.LoadTile([new(198, 384), new(208, 322)]));
    this.Tiles.Add("D19", this.LoadTile([new(196, 391)]));
    this.Tiles.Add("T19", this.LoadTile([new(207, 329)]));

    // seven
    this.Tiles.Add("7", this.LoadTile([new(151, 369), new(180, 312)]));
    this.Tiles.Add("D7", this.LoadTile([new(148, 375)]));
    this.Tiles.Add("T7", this.LoadTile([new(176, 319)]));

    // sixteen
    this.Tiles.Add("16", this.LoadTile([new(109, 338), new(154, 293)]));
    this.Tiles.Add("D16", this.LoadTile([new(104, 343)]));
    this.Tiles.Add("T16", this.LoadTile([new(149, 298)]));

    // eight
    this.Tiles.Add("8", this.LoadTile([new(80, 296), new(136, 268)]));
    this.Tiles.Add("D8", this.LoadTile([new(78, 297)]));
    this.Tiles.Add("T8", this.LoadTile([new(134, 269)]));

    // eleven
    this.Tiles.Add("11", this.LoadTile([new(65, 249), new(127, 239)]));
    this.Tiles.Add("D11", this.LoadTile([new(58, 251)]));
    this.Tiles.Add("T11", this.LoadTile([new(120, 240)]));

    // fourteen
    this.Tiles.Add("14", this.LoadTile([new(65, 198), new(127, 208)]));
    this.Tiles.Add("D14", this.LoadTile([new(58, 196)]));
    this.Tiles.Add("T14", this.LoadTile([new(120, 207)]));

    // nine
    this.Tiles.Add("9", this.LoadTile([new(80, 151), new(137, 180)]));
    this.Tiles.Add("D9", this.LoadTile([new(74, 148)]));
    this.Tiles.Add("T9", this.LoadTile([new(130, 176)]));

    // twelve
    this.Tiles.Add("12", this.LoadTile([new(111, 109), new(156, 153)]));
    this.Tiles.Add("D12", this.LoadTile([new(106, 104)]));
    this.Tiles.Add("T12", this.LoadTile([new(151, 148)]));

    // five
    this.Tiles.Add("5", this.LoadTile([new(153, 79), new(181, 136)]));
    this.Tiles.Add("D5", this.LoadTile([new(150, 73)]));
    this.Tiles.Add("T5", this.LoadTile([new(178, 130)]));
  }

  private List<Vector2> LoadTile(List<Vector2> startingPoints) {
    List<Vector2> output = [];

    foreach (Vector2 startingPoint in startingPoints) {
      List<Vector2> range = Utils.FloodFill(
        data: this.TextureData,
        delimiter: this.TileDelimiter,
        startingPoint: startingPoint,
        dimensions: new(this.Texture.Width, this.Texture.Width)
      );
      output.AddRange(range);
    }

    return output;
  }
}
