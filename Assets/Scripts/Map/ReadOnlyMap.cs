using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class ReadOnlyMap
{
    private Map _map;
    private ReadOnlyMapTile[] _tiles;

    public ReadOnlyMap(Map map)
    {
        _map = map;
        _tiles = map.Tiles.Select(t => t.AsReadOnly()).ToArray();
    }

    public int Width => _map.Width;
    public int Height => _map.Height;

    public IEnumerable<ReadOnlyMapTile> Tiles => _tiles;
    public ReadOnlyMapTile this[int x, int y] => _tiles[x + y * _map.Width];
    public ReadOnlyMapTile this[Vector2Int position]  => this[position.x, position.y];

    public IEnumerable<ReadOnlyMapTile> GetVicinity(Vector2Int position, int radius)
    {
        return _map.GetVicinity(position, radius).Select(t => t.AsReadOnly());
    }
}