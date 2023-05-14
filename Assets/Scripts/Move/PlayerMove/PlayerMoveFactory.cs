using System;

public static class PlayerMoveFactory
{
    public static PlayerMove Create(PlayerMoveType type, Player player)
    {
        switch(type)
        {
            case PlayerMoveType.Place:
                return new PlacePlayerMove(player);
            case PlayerMoveType.Remove:
                return new RemovePlayerMove(player);
            case PlayerMoveType.NavalAttack:
                return new NavalAttackPlayerMove(player);
            case PlayerMoveType.AirStrike:
                return new AirStrikePlayerMove(player);
            case PlayerMoveType.Artillery:
                return new ArtilleryPlayerMove(player);
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
    Artillery
}