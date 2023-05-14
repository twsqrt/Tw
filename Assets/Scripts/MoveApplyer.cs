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
    [SerializeField] private PlayersView _playersView;
    [SerializeField] private PlayerMoveBuilder _playerMoveBuilder;

    private int _currentPlayerIndex;
    private GameProcess[] _gameProcesses; 

    private void Start()
    {
        _map.Init(_biomFactory, _buildingFactory, _players);

        _currentPlayerIndex = 0;
        _playerMoveBuilder.Init();
        _playerMoveBuilder.Player = _players[_currentPlayerIndex];
        _playerMoveBuilder.OnMoveBuilt += OnPlayerMoveCreated;

        _playersView.Init(_players);

        _gameProcesses = new GameProcess[] { new ResourceExtractionProcess() };

    }

    public bool TryApplyPlayerMove(PlayerMove move)
    {
        GameResources moveCost = move.Cost;
        if (move.Player.Resources.IsEnough(moveCost) == false ||
            move.TryExecute(_map) == false)
            return false;

        move.Player.Resources -= moveCost;
        ApplyGameProcesses();
        return true;
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
        //template solution
        TryApplyPlayerMove(move);

        _currentPlayerIndex = (_currentPlayerIndex + 1 ) % _players.Count();
        _playerMoveBuilder.Player = _players[_currentPlayerIndex];
    }
}
