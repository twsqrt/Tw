using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Player
{
    private PlayerInfo _info;
    private GameResources _resources = new GameResources(100, 100, 100);

    public Action<Player> OnPlayerDataChanged;
    public PlayerInfo Info => _info;

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

    public Player(PlayerInfo info)
    {
        _info = info;
    }

    public Player Clone()
    {
        Player playerClone = new Player(_info);
        playerClone.Resources = _resources;

        return playerClone;
    }
}
