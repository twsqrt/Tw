using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map Tile View Factory", order = 51)]
public class MapTileViewFactory : GameObjectFactory<ReadOnlyMapTile, MapTileView>
{
    [SerializeField] private BiomViewFactory _biomViewFactory;
    [SerializeField] private BuildingViewFactory _buildingViewFactory;
    [SerializeField] private MapTileView _mapTileViewPrefab;

    public BuildingViewFactory BuildingViewFactory => _buildingViewFactory;
    public BiomViewFactory BiomViewFactory => _biomViewFactory;

    public override MapTileView Create(ReadOnlyMapTile tile)
    {
        MapTileView tileView = Instantiate(_mapTileViewPrefab);
        tileView.Init(this, tile);

        return tileView;
    }
}