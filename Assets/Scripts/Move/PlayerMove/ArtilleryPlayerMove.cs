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

    public ArtilleryPlayerMove(PlayerState player) : base(player, MoveParameters.Coordinate) { }

    public override bool IsValidMove(Map map)
    {
        MapTile tile = map[Coordinates];
        return tile != null && tile.Building != null && tile.Building.Owner != _player;
    }
    public override void Execute(Map map)
    {
        map[Coordinates].Building = null;
    }
}
