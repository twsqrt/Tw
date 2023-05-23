using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ArtilleryPlayerMove : PlayerMove, ICoordinateMove
{
    public Vector2Int Coordinates { get; set; }
    public override GameResources Cost => new GameResources(6, 7, 5);

    public ArtilleryPlayerMove(Player creator) : base(creator, MoveParameters.Coordinate) { }

    public override bool IsValidMove(ReadOnlyMap map, ReadOnlyPlayerStates playerStates)
    {
        ReadOnlyMapTile tile = map[Coordinates];
        return tile.Building != null && tile.Building.Owner != Creator;
    }

    public override void Execute(Map map, PlayerStates playerStates)
    {
        map[Coordinates].Building = null;
    }
}
