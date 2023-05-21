using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map Tile View Factory", order = 51)]
public class MapTileViewFactory : GameObjectFactory<MapTile, MapTileView>
{
    [SerializeField] private BiomViewFactory _biomViewFactory;
    [SerializeField] private BuildingViewFactory _buildingViewFactory;
    [SerializeField] private MapTileView _mapTileViewPrefab;

    public override MapTileView Create(MapTile tile)
    {
        BiomView biomView = _biomViewFactory.Create(tile.Biom);

        MapTileView tileView = Instantiate(_mapTileViewPrefab);

        if(tile.Building == null)
            tileView.Init(this, biomView);
        else
        {
            BuildingView buildingView = _buildingViewFactory.Create(tile.Building);
            tileView.Init(this, biomView, buildingView);
        }

        return tileView;
    }
}