using System;
using UnityEngine;

public class MapTileView : MonoBehaviour
{
    [SerializeField] private Highlighter _highlighter;

    private BiomView _biomView;
    private BuildingView _buildingView;
    private MapTileViewFactory _factory;

    public Highlighter Highlighter => _highlighter;

    public void Init(MapTileViewFactory facotry, MapTile tile)
    {
        _factory = facotry;
        tile.OnBuildingChange += UpdateBuilding;

        _biomView = facotry.BiomViewFactory.Create(tile.Biom);
        SetParentage(_biomView.transform);

        UpdateBuilding(tile.Building);
    }

    public void UpdateBuilding(Building building)
    {
        _buildingView?.Destroy();
        if(building != null)
        {
            _buildingView = _factory.BuildingViewFactory.Create(building);
            SetParentage(_buildingView.transform);
        }
        else
        {
            _buildingView = null;
        }

        _highlighter.MarkToRefresh();
    }

    private void SetParentage(Transform child)
    {
        child.position = transform.position;
        child.SetParent(transform);
    }

    public void Destroy()
    {
        _factory.Destroy(this);
    }
}