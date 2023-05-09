using System;
using UnityEngine;

public class PlayerMoveBuilderTransition : MonoBehaviour
{
    [SerializeField] private PlayerMoveBuilderState _nextState;
    [SerializeField] private bool _alwaysTransit;
    [SerializeField] private PlayerMoveType[] _correctTypes;

    public bool TryEnterNext(PlayerMove move, PlayerMoveType moveType)
    {
        if(_alwaysTransit || IsCorrectType(moveType))
        {
            _nextState?.Enter(move, moveType);
            return true;
        }
        return false;
    } 

    private bool IsCorrectType(PlayerMoveType type)
    {
        foreach(PlayerMoveType correctType in _correctTypes)
        {
            if(correctType == type)
                return true;

        }
        return false;
    }
}