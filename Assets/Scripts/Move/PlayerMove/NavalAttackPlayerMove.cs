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

    public NavalAttackPlayerMove(Player creator) : base(creator, MoveParameters.Coordinate) {}

    public override bool IsValidMove(ReadOnlyMap map, ReadOnlyPlayerStates playerStates)
    {
        ReadOnlyMapTile tile = map[Coordinates];

        if (tile.Building == null || tile.Building.Owner == Creator)
            return false;

        IEnumerable<ReadOnlyMapTile> tileVicinityRadius2 = map.GetVicinity(Coordinates, 2);
        return tileVicinityRadius2.Any(t => t.Biom.Type == BiomType.Ocean);
    }

    public override void Execute(Map map, PlayerStates playerStates)
    {
        map[Coordinates].Building = null;
    }
}
