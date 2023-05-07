using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMoveHighlighter
{
    private Map _map;
    private List<Highlighter> _highlighters;

    private bool _isMoveHighlightEnable;

    public PlayerMoveHighlighter(Map map)
    {
        _map = map;
        _isMoveHighlightEnable = false;
        _highlighters = new List<Highlighter>();
    }

    public void HighlightMove(ICoordinateMove move)
    {
        HighlightDisable();

        foreach(MapTile tile in _map.Tiles)
        {
            if(move.IsValidCoordinate(tile.PositionOnMap, _map))
            {
                _highlighters.Add(tile.Highlighter);
                tile.Highlighter.HighligthEnable();
            }
        }

        _isMoveHighlightEnable = true;
    }

    public void HighlightDisable()
    {
        if(_isMoveHighlightEnable)
        {
            _isMoveHighlightEnable = false;

            foreach(Highlighter h in _highlighters)
                h.HighlightDisable();
            
            _highlighters.Clear();
        }
    }
}