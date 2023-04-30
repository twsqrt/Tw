using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class NavalAttackPlayerMove : PlayerMove
{
    public override GameResources Cost => new GameResources(1, 2, 3);

    public NavalAttackPlayerMove(Player player) : base(player) { }

    protected override bool IsValidCoordinate(Vector2Int coordinate, Map map)
    {
        MapTile tile = map[coordinate];

        if (tile == null || tile.Building == null || tile.Building.Owner == _player)
            return false;

        IEnumerable<MapTile> tileVicinityRadius2 = map.GetVicinity(coordinate, 2);
        return tileVicinityRadius2.Any(t => t.Biom.Type == MapTileBiomType.Ocean);
    }

    public override void Execute(Map map)
    {
        map[Coordinate].Building = null;
    }
}
