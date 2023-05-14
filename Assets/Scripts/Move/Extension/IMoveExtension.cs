using System;

public static class IMoveExtension
{
    public static bool TryExecute(this IMove move, Map map)
    {
        bool isValid = move.IsValidMove(map);

        if(isValid)
            move.Execute(map);

        return isValid;
    }
}