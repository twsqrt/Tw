using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface IMove
{
    void Execute(Map map, PlayerStates playerStates);

    bool IsValidMove(ReadOnlyMap map, ReadOnlyPlayerStates playerStates);
}

