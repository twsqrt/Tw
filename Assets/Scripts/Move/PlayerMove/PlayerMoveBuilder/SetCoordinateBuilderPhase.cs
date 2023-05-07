using System;
using UnityEngine;

public class SetCoordinateBuilderPhase : PlayerMoveBuilderPhase
{
    [SerializeField] private Map _map;
    [SerializeField] private Camera _camera;

    private PlayerMoveHighlighter _moveHighlighter;
    private ICoordinateMove _coordinateMove;

    public void Init()
    {
        _moveHighlighter = new PlayerMoveHighlighter(_map);
    }

    public override void SetMove(PlayerMove move)
    {
        if(move is ICoordinateMove coordinateMove)
        {
            _coordinateMove = coordinateMove;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    protected override void AfterStart()
    {
        _moveHighlighter.HighlightMove(_coordinateMove);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            MapTile tile = _map.GetTile(ray);

            if (tile != null)
            {
                _coordinateMove.Coordinate = tile.PositionOnMap;

                _moveHighlighter.HighlightDisable();
                this.gameObject.SetActive(false);
                PhaseIsCompleted?.Invoke();
            }
        }
    }
}