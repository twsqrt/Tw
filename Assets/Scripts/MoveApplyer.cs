using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class MoveApplyer : MonoBehaviour
{
    [SerializeField] private MapConfiguration _mapConfiguration;
    [SerializeField] private MapView _mapView;
    [SerializeField] private Camera _camera;
    [SerializeField] private Player[] _players;
    [SerializeField] private PlayerStatesView _playerStatesView;
    [SerializeField] private GameStateSelector _gameStateSelector;
    [SerializeField] private PlayerMoveBuilder _playerMoveBuilder;

    //template solution
    [SerializeField] private BuildingInfo _settlement;

    private GameProcess[] _gameProcesses; 

    private RingArray<Player> _playresRingArray;

    //template solution
    private GameState _currentGameState;
    public GameState CurrentGameState => _currentGameState;
    private void Start()
    {
        PlayerStates playerStates = new PlayerStates(_players);
        _playresRingArray = new RingArray<Player>(_players);

        Map initialMap = new Map(_mapConfiguration);

        //template soluion
        initialMap[4,0].Building = new Building(_settlement, _playresRingArray[0]);
        initialMap[initialMap.Width - 3, initialMap.Height - 1].Building = new Building(_settlement, _playresRingArray[1]);

        _currentGameState = new GameState(initialMap, playerStates);

        _gameStateSelector.Init(new GameState[]{ _currentGameState, _currentGameState.Clone() } );
        _gameStateSelector.AddListener(GameStateSelectedHandler);

        _mapView.Render(initialMap.AsReadOnly());

        _playerMoveBuilder.Init();
        _playerMoveBuilder.Player = _playresRingArray.GetCurrent();
        _playerMoveBuilder.OnMoveBuilt += PlayerMoveCreatedHandler;

        _playerStatesView.Init(playerStates);

        _gameProcesses = new GameProcess[] { new ResourceExtractionProcess() };
    }

    private void ApplyGameProcesses()
    {
        foreach(var gameProcess in _gameProcesses)
        {
            _currentGameState.ApplyMove(gameProcess);
        }
    }

    public void PlayerMoveCreatedHandler(PlayerMove move)
    {
        if(_currentGameState.TryApplyPlayerMove(move))
        {
            ApplyGameProcesses();
        }

        _playerMoveBuilder.Player = _playresRingArray.Next();
    }

    public void GameStateSelectedHandler(GameState gameState)
    {
        if(_currentGameState != gameState)
        {
            _currentGameState = gameState;

            _mapView.CleanUp();
            _mapView.Render(_currentGameState.Map);
        }
    }
}