using System;
using UnityEngine;

public class MapTileView : MonoBehaviour
{
    [SerializeField] private Highlighter Highlighter;

    private BiomView _biomView;
    private BuildingView _buildingView;

    private MapTileViewFactory _factory;

    public void Init(MapTileViewFactory factory, BiomView biomView, BuildingView buildingView)
    {
        _factory = factory;
        _biomView = biomView;
        SetParentage(_biomView.transform);

        _buildingView =buildingView;
        SetParentage(_buildingView.transform);
    }

    private void SetParentage(Transform child)
    {
        child.localPosition = transform.localPosition;
        child.SetParent(transform);
    }

    public void Destroy()
    {
        _factory.Destroy(this);
    }
}