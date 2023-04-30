using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlacePlayerMove : PlayerMove
{
    public MapTileBuildingType BuildingType;
    public MapTileBuildingFactory BuildingFactory;

    public override GameResources Cost => GameResources.zero;

    public PlacePlayerMove(Player player) : base(player) { }

    protected override bool IsValidCoordinate(Vector2Int coordinate, Map map)
    {
        MapTile tile = map[coordinate];

        if (tile == null || tile.Building != null || tile.Biom.CanPlaceBulidingsOn == false) return false;

        IEnumerable<MapTile> vicinityRadius1 = map.GetVicinity(tile.PositionOnMap, 1);
        IEnumerable<MapTile> vicinityRadius2 = map.GetVicinity(tile.PositionOnMap, 2);

        return vicinityRadius1.Any(t => t.Building != null && t.Building.Owner != _player) == false
            && vicinityRadius2.Any(t => t.Building != null && t.Building.Owner == _player);
    }

    public override void Execute(Map map)
    {
        MapTile tile = map[Coordinate];

        tile.Building = BuildingFactory.Create(BuildingType, _player);
    }

}
