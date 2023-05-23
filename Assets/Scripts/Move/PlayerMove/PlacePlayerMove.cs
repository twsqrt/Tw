using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlacePlayerMove : PlayerMove, ICoordinateMove, IBuildingMove
{
    public Vector2Int Coordinates { get; set; }
    public BuildingInfo BuildingInfo { get; set; }

    public override GameResources Cost => BuildingInfo.Cost;

    public PlacePlayerMove(Player creator) : base(creator, MoveParameters.Coordinate | MoveParameters.Building) { }

    public override bool IsValidMove(Map map, PlayerStates playerStates)
    {
        MapTile tile = map[Coordinates];

        if (tile.Building != null || tile.Biom.IsBuildingAllowed == false) 
            return false;

        IEnumerable<MapTile> vicinityRadius1 = map.GetVicinity(tile.PositionOnMap, 1);
        IEnumerable<MapTile> vicinityRadius2 = map.GetVicinity(tile.PositionOnMap, 2);

        return vicinityRadius1.Any(t => t.Building != null && t.Building.Owner != Creator) == false
            && vicinityRadius2.Any(t => t.Building != null && t.Building.Owner == Creator);
    }

    public override void Execute(Map map, PlayerStates playerStates)
    {
        MapTile tile = map[Coordinates];
        tile.Building = new Building(BuildingInfo, Creator);
    }
}
