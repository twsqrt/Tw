using System;
using UnityEngine;

public class SetMoveBuilding : PlayerMoveBuilderState
{
    [SerializeField] private MapTileBuildingFactory _buildingFactory;
    protected override void AfterEnter(PlayerMove move)
    {
        if(move is IBuildingMove buildingMove)
        {
            buildingMove.BuildingType = MapTileBuildingType.Settlement;
            buildingMove.BuildingFactory = _buildingFactory;

            Exit();
        }
        else
        {
            throw new ArgumentException();
        }
    }

}