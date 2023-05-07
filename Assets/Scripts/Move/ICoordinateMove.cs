using UnityEngine;

public interface ICoordinateMove
{
    Vector2Int Coordinate { get; set; }

    bool IsValidCoordinate(Vector2Int coordinate, Map map);
}