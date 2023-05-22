using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class NavalAttackPlayerMove : PlayerMove, ICoordinateMove
{
    public Vector2Int Coordinates { get; set; }
    public override GameResources Cost => new GameResources(1, 2, 3);

    public NavalAttackPlayerMove(PlayerState player) : base(player, MoveParameters.Coordinate) {}

    public override bool IsValidMove(Map map)
    {
        MapTile tile = map[Coordinates];

        if (tile == null || tile.Building == null || tile.Building.Owner == _player)
            return false;

        IEnumerable<MapTile> tileVicinityRadius2 = map.GetVicinity(Coordinates, 2);
        return tileVicinityRadius2.Any(t => t.Biom.Type == BiomType.Ocean);
    }

    public override void Execute(Map map)
    {
        map[Coordinates].Building = null;
    }
}
