using System;
using UnityEngine;

public class TimeFrame : MonoBehaviour
{
    [NonSerialized] public Map _map;

    private int _time;

    private const int GAME_MAP_LAYER = 1 << 6;

    public int Time => _time;

    public void Init(Map map)
    {
        _map = map;
        _time = 1;
    }

    public void ApplyMove(IMove move)
    {
        move.Execute(_map);
    }

    public bool TryApplyMove(IMove move)
    {
        return move.TryExecute(_map);
    }

    public bool CanApplyPlayerMove(PlayerMove move)
    {
        return move.Player.Resources.IsEnough(move.Cost) && move.IsValidMove(_map);
    }

    public void ApplyPlayerMove(PlayerMove move)
    {
        ApplyMove(move);
        move.Player.Resources -= move.Cost;
        _time++;
    }

    public bool TryApplyPlayerMove(PlayerMove move)
    {
        bool canApply = CanApplyPlayerMove(move);

        if (canApply)
            ApplyPlayerMove(move);

        return canApply;
    }

    public bool TryGetPositionOnMap(Ray ray, out Vector2Int positionOnMap)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, 64f, GAME_MAP_LAYER))
        {
            Vector3 mapOffset = new Vector3(_map.Width * 0.5f, 0, _map.Height * 0.5f);

            Vector3 pointOnQuad = hit.point - _map.transform.position + mapOffset;
            positionOnMap = new Vector2Int((int)pointOnQuad.x, (int)pointOnQuad.z);
            return true;
        }
        positionOnMap = Vector2Int.zero;
        return false;
    }
}
