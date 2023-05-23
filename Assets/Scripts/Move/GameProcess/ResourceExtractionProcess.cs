using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ResourceExtractionProcess : GameProcess
{
    public override void Execute(Map map, PlayerStates playerStates)
    {
        IEnumerable<MapTile> minesResourcesTiles = map.Tiles.Where(t => t.Building != null && t.Building.Info.IsMinesResources);

        foreach(var tile in minesResourcesTiles)
        {
            Player owner = tile.Building.Owner;
            PlayerState ownerState = playerStates.GetPlayerState(owner);

            IEnumerable<GameResources> vicinityResources = map.GetVicinity(tile.PositionOnMap, 1).Where(t => t.Building == null).Select(t => t.Biom.Resources);
            foreach(GameResources resources in vicinityResources)
            {
                ownerState.Resources += resources;
            }
        }
    }
}