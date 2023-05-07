using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class PlayerMove : Move
{
    protected Player _player;
    public Player Player => _player;

    public PlayerMove(Player player)
    {
        _player = player;
    }

    public abstract GameResources Cost
    {
        get;
    }

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
