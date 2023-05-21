using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private MeshCollider _quadCollider;

    [SerializeField] private int _width;
    [SerializeField] private int _height;

    private MapTile[] _tiles;
    public IEnumerable<MapTile> Tiles => _tiles;

    public int Width => _width;
    public int Height => _height;

    public MapTile this[int x, int y]
    {
        set
        {
            _tiles[x + y * _width] = value;
        }
        get
        {
            return _tiles[x + y * _width];
        }
    }

    public MapTile this[Vector2Int coords] => this[coords.x, coords.y];

    private bool IsValidCoordinates(int x, int y)
    {
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }

    public bool TryGetTile(int x, int y, out MapTile tile)
    {
        if(IsValidCoordinates(x,y))
        {
            tile = _tiles[x + y * _width];
            return true;
        }

        tile = null;
        return false;
    }

    private BiomType BiomTypeGenerator(int i, int j)
    {
        float x = 2f * (float)i / _width - 1f;
        float y = 2f * (float)j / _height -1f;
        float r = Mathf.Sqrt((x * x + y * y));
        float f = 0.5f * (Mathf.Sign(1f - 2f * r) * Mathf.Pow(1f - 2f * r, 2) + 1f) + 0.5f * Mathf.PerlinNoise(x + 0.5f, y - 0.5f);

        return (BiomType)(5 * Mathf.Clamp(f, 0f, 0.99f));
    }

    public void Init(BiomFactory biomFactory)
    {
        _quadCollider.transform.localScale = new Vector3(_width, _height, 1f);

        _tiles = new MapTile[_width * _height];

        for(int i =0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                BiomType biomType = BiomTypeGenerator(i, j);
                Biom biom = biomFactory.Create(biomType);

                this[i, j] = new MapTile(new Vector2Int(i,j), biom);
            }
        }
    }

    public IEnumerable<MapTile> GetVicinity(Vector2Int positionOnMap, int radius = 1)
    {
        for(int i = -radius; i <= radius; i++)
        {
            for (int j = -radius; j <= radius; j++)
            {
                if(TryGetTile(positionOnMap.x + i, positionOnMap.y + j, out MapTile tile))
                    yield return tile;
            }
        }
    }
}

