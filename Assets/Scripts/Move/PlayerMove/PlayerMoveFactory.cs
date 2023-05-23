using System;

public static class PlayerMoveFactory
{
    public static PlayerMove Create(PlayerMoveType type, Player creator)
    {
        switch(type)
        {
            case PlayerMoveType.Place:
                return new PlacePlayerMove(creator);
            case PlayerMoveType.Remove:
                return new RemovePlayerMove(creator);
            case PlayerMoveType.NavalAttack:
                return new NavalAttackPlayerMove(creator);
            case PlayerMoveType.AirStrike:
                return new AirStrikePlayerMove(creator);
            case PlayerMoveType.Artillery:
                return new ArtilleryPlayerMove(creator);
            case PlayerMoveType.TimeTravel:
                return new TimeTravelPlayerMove(creator);
            default:
                throw new NotImplementedException();
        }
    }
}

public enum PlayerMoveType
{
    Place,
    Remove,
    NavalAttack,
    AirStrike,
    Artillery,
    TimeTravel

}