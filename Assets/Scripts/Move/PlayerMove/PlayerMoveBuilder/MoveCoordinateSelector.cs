using System;
using UnityEngine;

public class MoveCoordinateSelector : ParameterSelector<ICoordinateMove>
{
    //template solution
    [SerializeField] private TimeFrame _timeFrame;
    [SerializeField] private Camera _camera;

    private ICoordinateMove _coordinateMove;


    protected override void AfterStart(ICoordinateMove coordinateMove)
    {
        _coordinateMove = coordinateMove;
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