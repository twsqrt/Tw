using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Map : MonoBehaviour
{
    [SerializeField] private MeshCollider _quadCollider;
    [SerializeField] private MapTile _mapTilePrefab;

    [SerializeField] private int _width;
    [SerializeField] private int _height;

    private MapTile[] _tiles;

    private const int GAME_MAP_LAYER = 1 << 6;

    public int Width => _width;
    public int Height => _height;

    private bool IsValidCoordinates(int x, int y)
    {
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }

    public MapTile this[int x, int y]
    {
        set
        {
            if(IsValidCoordinates(x,y))
                _tiles[x + y * _width] = value;
        }
        get
        {
            if(IsValidCoordinates(x,y))
                return _tiles[x + y * _width];
            return null;
        }
    }

    public MapTile this[Vector2Int coords] => this[coords.x, coords.y];

    public IEnumerable<MapTile> Tiles => _tiles;

    public void Init(MapTileBiomFactory biomFactory, MapTileBuildingFactory buildingFactory, Player[] players)
    {
        _quadCollider.transform.localScale = new Vector3(_width, _height, 1f);

        _tiles = new MapTile[_width * _height];

        int WidthOffset = _width / 2;
        int HeightOffset = _height / 2;

        for(int i =0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                float x = 2f * (float)i / _width - 1f;
                float y = 2f * (float)j / _height -1f;
                float r = Mathf.Sqrt((x * x + y * y));
                float f = 0.5f * (Mathf.Sign(1 - 2 * r) * Mathf.Pow(1 - 2 * r, 2) + 1f) + 0.5f * Mathf.PerlinNoise(x + 0.5f, y - 0.5f);

                MapTileBiomType biomType = (MapTileBiomType)(5 * Mathf.Clamp(f, 0f, 0.99f));

                MapTile newTile = Instantiate(_mapTilePrefab, transform);
                newTile.name = $"MapTile i: {i}, j: {j}";
                newTile.Init(new Vector2Int(i, j), biomFactory.Create(biomType));
                newTile.transform.localPosition = transform.position + new Vector3(i - WidthOffset , 0f, j - HeightOffset);

                this[i, j] = newTile;
            }
        }

        this[4, 0].Building = buildingFactory.Create(MapTileBuildingType.Settlement, players[0]);
        this[_width - 3, _height - 1].Building = buildingFactory.Create(MapTileBuildingType.Settlement, players[1]);

    }

    public MapTile GetTile(Ray ray)
    {
        if(Physics.Raycast(ray, out RaycastHit hit, 64f, GAME_MAP_LAYER))
        {
            Vector3 mapOffset = new Vector3(_width * 0.5f, 0, _height * 0.5f);

            Vector3 point = hit.point - transform.position + mapOffset;
            int i = (int) point.x;
            int j = (int) point.z;

            return this[i, j]; 
        }
        return null; 
    }

    public IEnumerable<MapTile> GetVicinity(Vector2Int positionOnMap, int radius = 1)
    {
        List<MapTile> vicinity = new List<MapTile>();

        for(int i = -radius; i <= radius; i++)
        {
            for (int j = -radius; j <= radius; j++)
            {
                Vector2Int position = new Vector2Int(positionOnMap.x + i, positionOnMap.y + j);

                if (this[position] != null)
                    vicinity.Add(this[position]);
            }
        }

        return vicinity;
    }
}

