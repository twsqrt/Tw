using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacePlayerMoveButton : PlayerMoveButton
{
    [SerializeField] private MapTileBuildingType _buildingType;

    private void OnEnable()
    {
        _moveType = PlayerMoveType.Place;
    }

    private void OnValidate()
    {
        _moveType = PlayerMoveType.Place;
    }

    public MapTileBuildingType BuildingType => _buildingType; 
}
