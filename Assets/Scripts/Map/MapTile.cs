using JetBrains.Annotations;
using Newtonsoft.Json.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;


public class MapTile
{
    private Vector2Int _positionOnMap;
    private Building _building;
    private Biom _biom;

    public Action<Building> OnBuildingChange;

    public MapTile(Vector2Int positionOnMap, Biom biom)
    {
        _positionOnMap = positionOnMap;
        _building = null;
        _biom = biom;
    }

    private MapTile(MapTile original)
    {
        _positionOnMap = original.PositionOnMap;
        _biom = original.Biom;

        if(original.Building != null)
            _building = original.Building.Clone();
        else
            _building = null;
    }

    public MapTile Clone()
    {
        return new MapTile(this);
    }

    public Building Building
    {
        get
        {
            return _building;
        }

        set
        {
            _building = value;
            OnBuildingChange?.Invoke(_building);
        }
    }

    public Biom Biom => _biom;
    public Vector2Int PositionOnMap => _positionOnMap;

}