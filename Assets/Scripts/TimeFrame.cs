using System;

public class TimeFrame
{
    private Map _map;
    private int _time;
    public int Time => _time;

    //template solution
    public Map MapClone => _map.Clone();

    public TimeFrame(Map map)
    {
        _map = map;
        _time = 1;
    }

    private TimeFrame(TimeFrame original)
    {
        _map = original.MapClone;
        _time = original.Time;
    }  

    public TimeFrame Clone()
    {
        return new TimeFrame(this);
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