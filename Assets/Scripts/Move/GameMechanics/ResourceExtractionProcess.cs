using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ResourceExtractionProcess : GameProcess
{
    public override void Execute(Map map)
    {
        IEnumerable<MapTile> settlementTiles = map.Tiles.Where(t => t.Building != null && t.Building.Type == MapTileBuildingType.Settlement);

        foreach(var tile in settlementTiles)
        {
            IEnumerable<GameResources> vicinityResources = map.GetVicinity(tile.PositionOnMap).Where(t => t.Building == null).Select(t => t.Biom.Resources);
            foreach(GameResources resource in vicinityResources)
            {
                tile.Building.Owner.Resources += resource;
            }
        }
    }
}
