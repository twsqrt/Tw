using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBuilder
{
    private List<PlayerMoveBuilderPhase> _phases;
    private int _currentPhaseIndex;
    private PlayerMove _currentMove;

    public Action<PlayerMove> BuildingIsCompleted;


    public PlayerMoveBuilder()
    {
        _phases = new List<PlayerMoveBuilderPhase>();
    }

    public void AddPhase(PlayerMoveBuilderPhase phase)
    {
        phase.PhaseIsCompleted += OnPhaseCompletion;
        _phases.Add(phase);
    }

    public void StartBuilding(PlayerMove move)
    {
        _phases.ForEach(p => p.SetMove(move));
        _currentMove = move;
        _currentPhaseIndex = 0;

        _phases[_currentPhaseIndex].StartPhase();
    }

    private void OnPhaseCompletion()
    {
        _currentPhaseIndex++;
        if(_currentPhaseIndex == _phases.Count)
        {
            _currentPhaseIndex = 0;
            BuildingIsCompleted?.Invoke(_currentMove);
        }
        else
        {
            _phases[_currentPhaseIndex].StartPhase();
        }
    }

}