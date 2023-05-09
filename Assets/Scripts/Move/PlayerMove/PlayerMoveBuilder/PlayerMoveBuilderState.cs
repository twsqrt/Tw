using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMoveBuilderState : MonoBehaviour
{
    [SerializeField] private PlayerMoveBuilderTransition[] _transitions;

    private PlayerMove _currentMove;
    private PlayerMoveType _currentMoveType;

    public void Enter(PlayerMove move, PlayerMoveType moveType)
    {
        enabled = true;

        _currentMove = move;
        _currentMoveType = moveType;

        AfterEnter(move);
    }

    protected void Exit()
    {
        foreach(var transition in _transitions)
        {
            if(transition.TryEnterNext(_currentMove, _currentMoveType))
            {
                enabled = false;
                return;
            }
        }
    }

    protected abstract void AfterEnter(PlayerMove move);
}