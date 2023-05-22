using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class MoveApplyer : MonoBehaviour
{
    //template soluion
    [SerializeField] private TimeFrame _timeFrame;
    [SerializeField] private Map _map;
    [SerializeField] private MapView _mapView;
    [SerializeField] private Camera _camera;
    [SerializeField] private BiomFactory _biomFactory;
    [SerializeField] private PlayerInfo[] _playersInfo;
    [SerializeField] private PlayersView _playersView;
    [SerializeField] private PlayerMoveBuilder _playerMoveBuilder;

    //template solution
    [SerializeField] private BuildingInfo _settlement;

    private GameProcess[] _gameProcesses; 

    private RingArray<Player> _players;


    private void Start()
    {
        _map.Init(_biomFactory);

        _players = new RingArray<Player>(_playersInfo.Select(i => new Player(i)));

        //template soluion
        _map[4,0].Building = new Building(_settlement, _players[0]);
        _map[_map.Width - 3, _map.Height - 1].Building = new Building(_settlement, _players[1]);

        _timeFrame.Init(_map);
        _mapView.Render(_map);

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
            gameProcess.Execute(_map);
        }
    }

    public void OnPlayerMoveCreated(PlayerMove move)
    {
        if(_timeFrame.TryApplyPlayerMove(move))
        {
            ApplyGameProcesses();
            //_mapView.CleanUp();
            //_mapView.Render(_map);
        }

        _playerMoveBuilder.Player = _players.Next();
    }
}
