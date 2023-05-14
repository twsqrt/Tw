using UnityEngine;

public interface ICoordinateMove : IMove
{
    Vector2Int Coordinates { get; set; }
}