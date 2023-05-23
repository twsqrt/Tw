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
    private GameResources _resources;

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

    public PlayerState(Player player, GameResources resources)
    {
        _player = player;
        _resources = resources;
    }

    private PlayerState(PlayerState original)
    {
        _player = original.Player;
        _resources = original.Resources;
    }

    public PlayerState Clone()
    {
        return new PlayerState(this);
    } 
}
