using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class PlayerMove : IMove
{
    private MoveParameters _parameters;
    public Player Creator {get; protected set;}

    public PlayerMove(Player creator, MoveParameters parameters)
    {
        Creator = creator;
        _parameters = parameters;
    }
    public bool IsParameterizedBy(MoveParameters parameter)
    {
        return (_parameters & parameter) != 0;
    }

    public abstract GameResources Cost { get; }

    public abstract void Execute(Map map, PlayerStates playerStates); 

    public abstract bool IsValidMove(ReadOnlyMap map, ReadOnlyPlayerStates playerStates); 
}