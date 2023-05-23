using System;

public class GameState
{
    private Map _map;
    private PlayerStates _playerStates;
    private int _time;
    public int Time => _time;

    //template solution
    public ReadOnlyMap Map => _map.AsReadOnly();
    public ReadOnlyPlayerStates PlayerStates => _playerStates.AsReadOnly();

    public GameState(Map map, PlayerStates playersState)
    {
        _map = map;
        _playerStates = playersState;
        _time = 0;
    }

    private GameState(GameState original)
    {
        _map = original._map.Clone();
        _time = original._time;
        _playerStates = original._playerStates.Clone();
    }  

    public GameState Clone()
    {
        return new GameState(this);
    } 

    public void ApplyMove(IMove move)
    {
        move.Execute(_map, _playerStates);
    }

    public bool TryApplyMove(IMove move)
    {
        return move.TryExecute(_map, _playerStates);
    }

    public bool CanApplyPlayerMove(PlayerMove move)
    {
        PlayerState creatorState = _playerStates.GetPlayerState(move.Creator);

        return creatorState.Resources.IsEnoughTo(move.Cost) && move.IsValidMove(_map.AsReadOnly(), _playerStates.AsReadOnly());
    }

    public void ApplyPlayerMove(PlayerMove move)
    {
        ApplyMove(move);

        PlayerState creatorState = _playerStates.GetPlayerState(move.Creator);
        creatorState.Resources -= move.Cost;

        _time++;
    }

    public bool TryApplyPlayerMove(PlayerMove move)
    {
        bool canApply = CanApplyPlayerMove(move);

        if (canApply)
            ApplyPlayerMove(move);

        return canApply;
    }

}