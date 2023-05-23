using System;
using UnityEngine;

public class ReadOnlyMapTile
{
    private MapTile _mapTile;

    public Building Building => _mapTile.Building;
    public Biom Biom => _mapTile.Biom;
    public Vector2Int PositionOnMap => _mapTile.PositionOnMap;

    public ReadOnlyMapTile(MapTile mapTile)
    {
        _mapTile = mapTile;
    }
}