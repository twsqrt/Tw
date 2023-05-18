using System;

public class TimeTravelPlayerMove : PlayerMove, IResoucesMove, ITimeMove
{
    public GameResources Resources { get; set;}
    public int Time { get; set;}
    public override GameResources Cost => Time * new GameResources(2,2,2);

    public TimeTravelPlayerMove(Player player) : base(player, MoveParameters.Resources | MoveParameters.Time)
    {
        //template solution
        Time = 0;
    }

    public override void Execute(Map map)
    {
        _player.Resources -= Resources;
    }

    public override bool IsValidMove(Map map)
    {
        return _player.Resources.IsEnough(Resources);
    }
}