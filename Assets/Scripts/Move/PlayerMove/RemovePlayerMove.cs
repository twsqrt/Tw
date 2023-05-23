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

    public RemovePlayerMove(Player creator) : base(creator, MoveParameters.Coordinate) { }

    public override bool IsValidMove(ReadOnlyMap map, ReadOnlyPlayerStates playerStates)
    {
        IEnumerable<ReadOnlyMapTile> allValidTiles = map.Tiles.Where( t => t.Building != null && t.Building.Owner == Creator);

        if(allValidTiles.Count() < 2)
            return false;

        ReadOnlyMapTile selectedTile = map[Coordinates];

        return allValidTiles.Any( t => t == selectedTile);
    }

    public override void Execute(Map map, PlayerStates playerStates)
    {
        MapTile tile = map[Coordinates];
        GameResources buildingCost = tile.Building.Info.Cost;

        PlayerState CreatorState = playerStates.GetPlayerState(Creator);
        CreatorState.Resources += buildingCost * 0.5f;

        tile.Building = null;
    }
}
