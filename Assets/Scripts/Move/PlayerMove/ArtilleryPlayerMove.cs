using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ArtilleryPlayerMove : CoordinatePlayerMove
{
    public override GameResources Cost => new GameResources(5, 7, 5);

    public ArtilleryPlayerMove(Player player) : base(player) { }
    public override bool IsValidCoordinate(Vector2Int coordinate, Map map)
    {
        MapTile tile = map[coordinate];
        return tile != null && tile.Building != null && tile.Building.Owner != _player;
    }
    public override void Execute(Map map)
    {
        map[Coordinate].Building = null;
    }
}
