using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class MoveApplyer : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private Camera _camera;
    [SerializeField] private MapTileBuildingFactory _buildingFactory;
    [SerializeField] private MapTileBiomFactory _biomFactory;
    [SerializeField] private Player[] _players;

    [SerializeField] private List<PlayerMoveButton> _moveButtons;

    [SerializeField] private PlayersView _playersView;

    private PlayerMoveBuilder _builderTest;
    [SerializeField] private SetCoordinateBuilderPhase _buliderPhaseTest;

    private int _currentPlayerIndex;
    private Player _currentPlayer;
    private PlayerMove _currentMove;

    private List<Highlighter> _currentMoveHighlite;

    private GameProcess[] _gameProcesses; 

    private void Start()
    {
        _map.Init(_biomFactory, _buildingFactory, _players);
        _moveButtons.ForEach(b => b.OnButtonClick += OnMoveSelected);

        _currentPlayerIndex = 0;
        _currentPlayer = _players[_currentPlayerIndex];

        _currentMoveHighlite = new List<Highlighter>();
        _playersView.Init(_players);

        _gameProcesses = new GameProcess[] { new ResourceExtractionProcess() };

        _builderTest = new PlayerMoveBuilder();
        _buliderPhaseTest.Init();
        _builderTest.AddPhase(_buliderPhaseTest);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            MapTile tile = _map.GetTile(ray);

            if (tile != null && _currentMove != null)
            {
                //template solution
                (_currentMove as CoordinatePlayerMove).Coordinate = tile.PositionOnMap;
                TryApplyPlayerMove();
            }
        }
    }


    public bool TryApplyPlayerMove()
    {
        GameResources moveCost = _currentMove.Cost;
        if (_currentPlayer.Resources.IsEnough(moveCost) == false ||
            _currentMove.TryExecute(_map) == false)
            return false;

        _currentPlayer.Resources -= moveCost;

        _currentMove = null;
        _currentMoveHighlite.ForEach(h => h.HighlightDisable());
        _currentMoveHighlite.Clear();

        _currentPlayerIndex++;
        if(_currentPlayerIndex == _players.Count())
        {
            _currentPlayerIndex = 0;
            ApplyGameProcesses();
        }

        _currentPlayer = _players[_currentPlayerIndex];
        return true;
    }

    private void ApplyGameProcesses()
    {
        foreach(var gameProcess in _gameProcesses)
        {
            gameProcess.Execute(_map);
        }
    }

    private void OnMoveSelected(PlayerMoveButton moveButton)
    {
        if (moveButton is PlacePlayerMoveButton placePlayerMoveButton)
            OnPlacePlayerMoveSelected(placePlayerMoveButton);
        else
            _currentMove = PlayerMove.Create(moveButton.MoveType, _currentPlayer);

        //template solution
        _builderTest.StartBuilding(_currentMove);
    }

    private void OnPlacePlayerMoveSelected(PlacePlayerMoveButton placePlayerMoveButton)
    {
        PlacePlayerMove placeMove = PlayerMove.Create(PlayerMoveType.Place, _currentPlayer) as PlacePlayerMove;
        placeMove.BuildingType = placePlayerMoveButton.BuildingType;
        placeMove.BuildingFactory = _buildingFactory;

        _currentMove = placeMove;
    }
}
