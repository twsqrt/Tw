using System;

public static class IMoveExtension
{
    public static bool TryExecute(this IMove move, Map map, PlayerStates playerStates)
    {
        bool isValid = move.IsValidMove(map.AsReadOnly(), playerStates.AsReadOnly());

        if(isValid)
            move.Execute(map, playerStates);

        return isValid;
    }
}