using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RemovePlayerMove : PlayerMove
{
    public override GameResources Cost => GameResources.zero;

    public RemovePlayerMove(Player player) : base(player) { }

    public override IEnumerable<MapTile> AllValidTiles(Map map)
    {
        IEnumerable<MapTile> validTiles = base.AllValidTiles(map);

        if (validTiles.Count() < 2) 
            return Enumerable.Empty<MapTile>();

        return validTiles;
    }
    protected override bool IsValidCoordinate(Vector2Int coordinates, Map map)
    {
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
