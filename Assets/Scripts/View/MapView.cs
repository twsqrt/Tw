using System;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour
{
    [SerializeField] MapTileViewFactory _mapTileViewFactory;

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
}