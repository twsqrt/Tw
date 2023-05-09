using System;
using UnityEngine;


public class BuilderFinalState : PlayerMoveBuilderState
{
    public event Action<PlayerMove> IsEntered;
    protected override void AfterEnter(PlayerMove move)
    {
        IsEntered?.Invoke(move);
        Exit();
    }
}