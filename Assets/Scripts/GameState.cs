using System;

public class GameState
{
    private Map _map;
    private int _time;
    public int Time => _time;

    //template solution
    public Map MapClone => _map.Clone();

    public GameState(Map map)
    {
        _map = map;
        _time = 1;
    }

    private GameState(GameState original)
    {
        _map = original.MapClone;
        _time = original.Time;
    }  

    public GameState Clone()
    {
        return new GameState(this);
    } 

    public void ApplyMove(IMove move)
    {
        move.Execute(_map);
    }

    public bool TryApplyMove(IMove move)
    {
        return move.TryExecute(_map);
    }

    public bool CanApplyPlayerMove(PlayerMove move)
    {
        return move.Player.Resources.IsEnough(move.Cost) && move.IsValidMove(_map);
    }

    public void ApplyPlayerMove(PlayerMove move)
    {
        ApplyMove(move);
        move.Player.Resources -= move.Cost;
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