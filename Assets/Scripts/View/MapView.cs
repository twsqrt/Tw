using System;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour
{
    [SerializeField] private MeshCollider _quadCollider;
    [SerializeField] MapTileViewFactory _mapTileViewFactory;

    private const int GAME_MAP_LAYER = 1 << 6;

    private MapTileView[] _tilesView;
    private int _width;
    private int _height;

    public MapTileView this[int x, int y]
    {
        get
        {
            return _tilesView[x + y * _width];
        }

        private set
        {
            _tilesView[x + y * _width] = value;
        }

    }

    public MapTileView this[Vector2Int position] => this[position.x, position.y];

    public void Render(Map map)
    {
        _width = map.Width;
        _height = map.Height;

        _quadCollider.transform.localScale = new Vector3(_width, _height, 1f);

        _tilesView = new MapTileView[_width * _height];
        
        Vector3 positionOffset = new Vector3((map.Width - 1) * 0.5f, 0f, (map.Height - 1) * 0.5f);
        Vector3 positionWithOffset = transform.position - positionOffset;

        for(int i = 0; i < map.Width; i++)
        {
            for(int j = 0; j < map.Height; j++)
            {
                MapTileView tileView = _mapTileViewFactory.Create(map[i,j]);
                tileView.name = $"x:{i}, y:{j}";

                tileView.transform.localPosition = positionWithOffset + new Vector3(i, 0f, j);
                tileView.transform.SetParent(transform);

                this[i,j] = tileView;
            }
        }
    } 

    public void CleanUp()
    {
        foreach(MapTileView tileView in _tilesView)
        {
            tileView.Destroy();
        }
    }

    public bool TryGetPositionOnMap(Ray ray, out Vector2Int positionOnMap)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, 64f, GAME_MAP_LAYER))
        {
            Vector3 mapOffset = new Vector3(_width * 0.5f, 0, _height * 0.5f);

            Vector3 pointOnQuad = hit.point - transform.position + mapOffset;
            positionOnMap = new Vector2Int((int)pointOnQuad.x, (int)pointOnQuad.z);
            return true;
        }
        positionOnMap = Vector2Int.zero;
        return false;
    }
}