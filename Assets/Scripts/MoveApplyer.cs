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
    [SerializeField] private PlayersStateView _playersStateView;
    [SerializeField] private PlayerMoveBuilder _playerMoveBuilder;

    //template solution
    [SerializeField] private BuildingInfo _settlement;

    private GameProcess[] _gameProcesses; 

    private RingArray<PlayerState> _playersState;

    //template solution
    private GameState _currentGameState;

    public GameState CurrentGameState => _currentGameState;
    private void Start()
    {
        _playersState = new RingArray<PlayerState>(_players.Select(p => new PlayerState(p)));

        //template soluion
        Map initialMap = new Map(_mapConfiguration);

        initialMap[4,0].Building = new Building(_settlement, _playersState[0]);
        initialMap[initialMap.Width - 3, initialMap.Height - 1].Building = new Building(_settlement, _playersState[1]);

        _currentGameState = new GameState(initialMap);

        _mapView.Render(initialMap);

        _playerMoveBuilder.Init();
        _playerMoveBuilder.Player = _playersState.GetCurrent();
        _playerMoveBuilder.OnMoveBuilt += OnPlayerMoveCreated;

        _playersStateView.Init(_playersState.ToArray());

        _gameProcesses = new GameProcess[] { new ResourceExtractionProcess() };

    }

    private void ApplyGameProcesses()
    {
        foreach(var gameProcess in _gameProcesses)
        {
            _currentGameState.ApplyMove(gameProcess);
        }
    }

    public void OnPlayerMoveCreated(PlayerMove move)
    {
        if(_currentGameState.TryApplyPlayerMove(move))
        {
            ApplyGameProcesses();
        }

        _playerMoveBuilder.Player = _playersState.Next();
    }
}