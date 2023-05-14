using System;
using UnityEngine;

public static class ICoodinateMoveExtension
{
    public static bool IsValidCoordinate(this ICoordinateMove move, Vector2Int coordinate, Map map)
    {
        Vector2Int currentCoordinate = move.Coordinates;
        move.Coordinates = coordinate;

        bool isValid = move.IsValidMove(map);

        move.Coordinates = currentCoordinate;
        return isValid;
    }
}