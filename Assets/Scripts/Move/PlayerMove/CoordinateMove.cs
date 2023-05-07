using UnityEngine;

public abstract class CoordinatePlayerMove : PlayerMove, ICoordinateMove
{
    public Vector2Int Coordinate { get; set; }

    public CoordinatePlayerMove(Player player) : base(player) {}

    public abstract bool IsValidCoordinate(Vector2Int coordinate, Map map);

    public override bool IsValidMove(Map map)
    {
        return IsValidCoordinate(Coordinate, map);
    }

}