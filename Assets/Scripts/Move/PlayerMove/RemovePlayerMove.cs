using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RemovePlayerMove : CoordinatePlayerMove
{
    public override GameResources Cost => GameResources.zero;

    public RemovePlayerMove(Player player) : base(player) { }

    public override bool IsValidCoordinate(Vector2Int coordinates, Map map)
    {
        //template soulution
        if(map.Tiles.Where( t => t.Building != null && t.Building.Owner == Player).Count() < 2)
            return false;

        MapTile tile = map[coordinates];

        return tile != null && tile.Building != null && tile.Building.Owner == _player;
    }

    public override void Execute(Map map)
    {
        MapTile tile = map[Coordinate];

        GameResources buildingCost = tile.Building.Cost;

        _player.Resources += buildingCost * 0.5f;

        tile.Building = null;
    }
}
