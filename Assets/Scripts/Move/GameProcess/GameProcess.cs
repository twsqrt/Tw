﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class GameProcess : IMove
{
    public bool IsValidMove(Map map, PlayerStates playerStates)
    {
        return true;
    }

    public abstract void Execute(Map map, PlayerStates playerStates);
}
