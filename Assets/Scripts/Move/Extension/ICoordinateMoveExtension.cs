using System;
using System.Linq;
using System.Collections.Generic;
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

    public static IEnumerable<Vector2Int> GetAllValidCoordinate(this ICoordinateMove move, Map map)
    {
        Vector2Int currentCoordinate = move.Coordinates;

        foreach(MapTile tile in map.Tiles)
        {
            Vector2Int tilePosition = tile.PositionOnMap;
            move.Coordinates = tilePosition;
            if(move.IsValidMove(map))
            {
                yield return tilePosition;
            }
        }

        move.Coordinates = currentCoordinate;
    }
}