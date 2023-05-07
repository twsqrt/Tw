using System;
using UnityEngine;

public abstract class PlayerMoveBuilderPhase : MonoBehaviour
{
     
    public Action PhaseIsCompleted;

    public void StartPhase()
    {
        this.gameObject.SetActive(true);
        AfterStart();
    }

    public abstract void SetMove(PlayerMove move);

    protected abstract void AfterStart(); 
}