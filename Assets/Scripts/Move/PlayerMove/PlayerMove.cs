using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class PlayerMove : IMove
{
    protected Player _player;
    public Player Player => _player;

    private MoveParameters _parameters;

    public PlayerMove(Player player, MoveParameters parameters)
    {
        _player = player;
        _parameters = parameters;
    }
    public bool IsParameterizedBy(MoveParameters parameter)
    {
        return (_parameters & parameter) != 0;
    }

    public abstract GameResources Cost
    {
        get;
    }

    public abstract void Execute(Map map); 

    public abstract bool IsValidMove(Map map); 
}