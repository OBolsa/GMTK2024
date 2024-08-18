using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Texture2D textureMap;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tileToPaint;
    [SerializeField] private Color colorRef;
    [SerializeField] private List<MapPainterTile> mapPainterTiles;

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

                if (pixel == colorRef)
                {
                    tilemap.SetTile(position, tileToPaint);
                }
                
            }
        }
    }
}

[System.Serializable]
public class MapPainterTile
{
    public Color color = Color.white;
    public TileBase tile;
}
