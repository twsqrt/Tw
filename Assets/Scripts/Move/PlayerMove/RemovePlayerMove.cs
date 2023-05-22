using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RemovePlayerMove : PlayerMove, ICoordinateMove
{
    public Vector2Int Coordinates { get; set; }
    public override GameResources Cost => GameResources.zero;

    public RemovePlayerMove(PlayerState player) : base(player, MoveParameters.Coordinate) { }

    public override bool IsValidMove(Map map)
    {
        //template soulution
        if(map.Tiles.Where( t => t.Building != null && t.Building.Owner == Player).Count() < 2)
            return false;

        MapTile tile = map[Coordinates];

        return tile != null && tile.Building != null && tile.Building.Owner == _player;
    }

    public override void Execute(Map map)
    {
        MapTile tile = map[Coordinates];

        GameResources buildingCost = tile.Building.Info.Cost;

        _player.Resources += buildingCost * 0.5f;

        tile.Building = null;
    }
}
