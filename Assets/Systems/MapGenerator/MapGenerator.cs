using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Texture2D textureMap;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tileToPaint;

    [ContextMenu("Setup Tile")]
    public void PaintMap()
    {
        int width = textureMap.width;
        int height = textureMap.height;

        int widthOffset = width / 2;
        int heightOffset = height / 2;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color pixel = textureMap.GetPixel(x, y);
                Vector3Int position = new Vector3Int(x - widthOffset, y - heightOffset, 0);

                if (pixel == Color.black)
                {
                    tilemap.SetTile(position, tileToPaint);
                }
                else
                {
                    tilemap.SetTile(position, null);
                }
            }
        }
    }
}
