using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState
{
    private Player _player;
    private GameResources _resources = new GameResources(100, 100, 100);

    public Action<PlayerState> OnPlayerDataChanged;
    public Player Player => _player;

    public GameResources Resources
    {
        get
        {
            return _resources;
        }

        set
        {
            _resources = value;
            OnPlayerDataChanged?.Invoke(this);
        }
    }

    public PlayerState(Player player)
    {
        _player = player;
    }
}
