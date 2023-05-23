using System;

public class TimeTravelPlayerMove : PlayerMove, IResoucesMove, ITimeMove
{
    public GameResources Resources { get; set;}
    public int Time { get; set;}
    public override GameResources Cost => Time * new GameResources(2,2,2);

    public TimeTravelPlayerMove(Player creator) : base(creator, MoveParameters.Resources | MoveParameters.Time) {}

    public override bool IsValidMove(ReadOnlyMap map, ReadOnlyPlayerStates playerStates)
    {
        ReadOnlyPlayerState CreatorState = playerStates.GetPlayerState(Creator);

        return CreatorState.Resources.IsEnoughTo(Resources);
    }

    public override void Execute(Map map, PlayerStates playerStates)
    {
        PlayerState CreatorState = playerStates.GetPlayerState(Creator);
        CreatorState.Resources -= Resources;
    }
}