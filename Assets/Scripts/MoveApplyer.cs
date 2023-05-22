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
    [SerializeField] private PlayerInfo[] _playersInfo;
    [SerializeField] private PlayersView _playersView;
    [SerializeField] private PlayerMoveBuilder _playerMoveBuilder;

    //template solution
    [SerializeField] private BuildingInfo _settlement;

    private GameProcess[] _gameProcesses; 

    private RingArray<Player> _players;

    //template solution
    private GameState _currentTimeFrame;

    public event Action<GameState> OnTimeFrameChange;
    public GameState CurrentTimeFrame
    {
        get
        {
            return _currentTimeFrame;
        }

        set
        {
            _currentTimeFrame = value;
            OnTimeFrameChange?.Invoke(_currentTimeFrame);
        }
    }

    private void Start()
    {
        _players = new RingArray<Player>(_playersInfo.Select(i => new Player(i)));

        //template soluion
        Map initialMap = new Map(_mapConfiguration);

        initialMap[4,0].Building = new Building(_settlement, _players[0]);
        initialMap[initialMap.Width - 3, initialMap.Height - 1].Building = new Building(_settlement, _players[1]);

        CurrentTimeFrame = new GameState(initialMap);

        _mapView.Render(initialMap);

        _playerMoveBuilder.Init();
        _playerMoveBuilder.Player = _players.GetCurrent();
        _playerMoveBuilder.OnMoveBuilt += OnPlayerMoveCreated;

        _playersView.Init(_players.ToArray());

        _gameProcesses = new GameProcess[] { new ResourceExtractionProcess() };

    }

    private void ApplyGameProcesses()
    {
        foreach(var gameProcess in _gameProcesses)
        {
            _currentTimeFrame.ApplyMove(gameProcess);
        }
    }

    public void OnPlayerMoveCreated(PlayerMove move)
    {
        if(_currentTimeFrame.TryApplyPlayerMove(move))
        {
            ApplyGameProcesses();
        }

        _playerMoveBuilder.Player = _players.Next();
    }
}