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

    public MapTile(Vector2Int positionOnMap, Biom biom)
    {
        _positionOnMap = positionOnMap;
        _building = null;
        _biom = biom;
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
        }
    }

    public Biom Biom => _biom;
    public Vector2Int PositionOnMap => _positionOnMap;

}