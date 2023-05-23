using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AirStrikePlayerMove : PlayerMove, ICoordinateMove
{
    public Vector2Int Coordinates {get; set;}
    public override GameResources Cost => new GameResources(5, 2, 2);

    public AirStrikePlayerMove(Player creator) : base(creator, MoveParameters.Coordinate) { }

    public override bool IsValidMove(Map map, PlayerStates playerStates)
    {
        MapTile tile = map[Coordinates];

        if (tile.Building == null || tile.Building.Owner == Creator)
            return false;

        IEnumerable<MapTile> tileVicinityRadius1 = map.GetVicinity(Coordinates, 1);
        return tileVicinityRadius1.Any(t => t.Biom.IsAirBarrier) == false;
    }
    public override void Execute(Map map, PlayerStates playerStates)
    {
        map[Coordinates].Building = null;
    }
}
