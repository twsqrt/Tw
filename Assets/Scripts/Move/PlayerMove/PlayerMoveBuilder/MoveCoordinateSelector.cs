using System;
using UnityEngine;

public class MoveCoordinateSelector : ParameterSelector<ICoordinateMove>
{
    //template solution
    [SerializeField] private TimeFrame _timeFrame;
    [SerializeField] private Camera _camera;

    private PlayerMoveHighlighter _moveHighlighter;
    private ICoordinateMove _coordinateMove;


    public override void Init()
    {
        _moveHighlighter = new PlayerMoveHighlighter(_timeFrame._map);
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

            if (_timeFrame.TryGetPositionOnMap(ray, out Vector2Int positionOnMap) && _coordinateMove.IsValidCoordinate(positionOnMap, _timeFrame._map))
            {
                _coordinateMove.Coordinates = positionOnMap;
                Exit();
            }
        }
    }
}