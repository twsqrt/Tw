using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Move
{
    public abstract void Execute(Map map);

    public abstract bool IsValidMove(Map map);

    public bool TryExecute(Map map)
    {
        bool isValid = IsValidMove(map);

        if (isValid)
            Execute(map);

        return isValid;
    }
}

