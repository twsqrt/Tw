using System;
using UnityEngine;

public class MoveCoordinateSelector : ParameterSelector<ICoordinateMove>
{
    [SerializeField] private Map _map;
    [SerializeField] private Camera _camera;

    private PlayerMoveHighlighter _moveHighlighter;
    private ICoordinateMove _coordinateMove;


    public override void Init()
    {
        _moveHighlighter = new PlayerMoveHighlighter(_map);
    }

    protected override void AfterStart(ICoordinateMove coordinateMove)
    {
        _coordinateMove = coordinateMove;
        _moveHighlighter.HighlightMove(coordinateMove);
    }

    protected override void BeforeExit()
    {
        _moveHighlighter.HighlightDisable();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            MapTile tile = _map.GetTile(ray);

            if (tile != null && _coordinateMove.IsValidCoordinate(tile.PositionOnMap, _map))
            {
                _coordinateMove.Coordinates = tile.PositionOnMap;

                Exit();
            }
        }
    }
}