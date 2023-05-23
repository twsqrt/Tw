using System;
using UnityEngine;

public class ReadOnlyMapTile
{
    private MapTile _mapTile;

    public Building Building => _mapTile.Building;
    public Biom Biom => _mapTile.Biom;
    public Vector2Int PositionOnMap => _mapTile.PositionOnMap;

    public event Action<Building> OnBuildingChange
    {
        add
        {
            _mapTile.OnBuildingChange += value;
        }

        remove
        {
            _mapTile.OnBuildingChange -= value;
        }
    }

    public ReadOnlyMapTile(MapTile mapTile)
    {
        _mapTile = mapTile;
    }
}