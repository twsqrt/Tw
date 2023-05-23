using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoordinateSelector : ParameterSelector<ICoordinateMove>
{
    //template solution
    [SerializeField] private MoveApplyer _moveApplyer;
    [SerializeField] private Camera _camera;
    [SerializeField] private MapView _mapView;

    private ICoordinateMove _coordinateMove;
    private IEnumerable<Highlighter> _highlighters;

    private GameState _currentGameState;
    protected override void AfterStart(ICoordinateMove coordinateMove)
    {
        _coordinateMove = coordinateMove;
        _currentGameState = _moveApplyer.CurrentGameState;

        _highlighters = _coordinateMove.GetAllValidCoordinate(_currentGameState.Map, _currentGameState.PlayerStates).Select(p => _mapView[p].Highlighter);

        HighlightersEnable();
    }

    private void HighlightersEnable()
    {
        foreach(Highlighter highlighter in _highlighters)
        {
            highlighter.HighligthEnable();
        }
    }

    private void HighlightersDisable()
    {
        foreach(Highlighter highlighter in _highlighters)
        {
            highlighter.HighlightDisable();
        }
    }

    protected override void BeforeExit()
    {
        HighlightersDisable();
    }


    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (_mapView.TryGetPositionOnMap(ray, out Vector2Int positionOnMap) && _coordinateMove.IsValidCoordinate(positionOnMap, _currentMapClone, _currentPlayerStatesClone))
            {
                _coordinateMove.Coordinates = positionOnMap;
                Exit();
            }
        }
    }
}