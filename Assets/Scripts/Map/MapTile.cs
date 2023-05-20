using JetBrains.Annotations;
using Newtonsoft.Json.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;


public class MapTile : MonoBehaviour
{
    [SerializeField] public Highlighter Highlighter;

    private Vector2Int _positionOnMap;
    private Building _building;
    private Biom _biom;

    public Building Building
    {
        get
        {
            return _building;
        }

        set
        {
            _building?.DestroyBuilding();
            _building = value;

            if(_building != null)
            {
                _building.transform.localPosition = transform.localPosition;
                _building.transform.SetParent(transform);
            }

            Highlighter.MarkForUpdateDefaultColorsList();
        }
    }

    public Biom Biom => _biom;
    public Vector2Int PositionOnMap => _positionOnMap;

    public void Init(Vector2Int positionOnMap, Biom biom)
    {
        _positionOnMap = positionOnMap;
        _building = null;

        _biom = biom;
        _biom.transform.localPosition = transform.localPosition;
        _biom.transform.SetParent(transform);

        Highlighter.MarkForUpdateDefaultColorsList();
    }
}
