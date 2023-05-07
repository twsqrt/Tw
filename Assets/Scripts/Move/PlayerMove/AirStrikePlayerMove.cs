using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AirStrikePlayerMove : CoordinatePlayerMove
{
    public override GameResources Cost => new GameResources(5, 2, 2);

    public AirStrikePlayerMove(Player player) : base(player) { }

    public override bool IsValidCoordinate(Vector2Int coordinate, Map map)
    {
        MapTile tile = map[coordinate];

        if (tile == null || tile.Building == null || tile.Building.Owner == _player)
            return false;

        IEnumerable<MapTile> tileVicinityRadius1 = map.GetVicinity(coordinate, 1);

        return tileVicinityRadius1.Any(t => t.Biom.IsAirBarrier) == false;
    }
    public override void Execute(Map map)
    {
        map[Coordinate].Building = null;
    }
}
