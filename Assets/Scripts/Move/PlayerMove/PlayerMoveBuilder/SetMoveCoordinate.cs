using System;
using UnityEngine;

public class SetMoveCoordinate : PlayerMoveBuilderState
{
    [SerializeField] private Map _map;
    [SerializeField] private Camera _camera;

    private PlayerMoveHighlighter _moveHighlighter;
    private ICoordinateMove _coordinateMove;

    protected override void AfterEnter(PlayerMove move)
    {
        if(move is ICoordinateMove coordinateMove)
        {
            //template solution
            if(_moveHighlighter == null)
                _moveHighlighter = new PlayerMoveHighlighter(_map);

            _coordinateMove = coordinateMove;
            _moveHighlighter.HighlightMove(coordinateMove);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            MapTile tile = _map.GetTile(ray);

            if (tile != null && _coordinateMove.IsValidCoordinate(tile.PositionOnMap, _map))
            {
                _coordinateMove.Coordinate = tile.PositionOnMap;

                _moveHighlighter.HighlightDisable();
                Exit();
            }
        }
    }
}