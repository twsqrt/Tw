using System;
using System.Linq;
using System.Collections.Generic;

public class PlayerStates
{
    private Dictionary<Player, PlayerState> _playerStates;

    public IEnumerable<PlayerState> Players => _playerStates.Values;

    public PlayerStates(IEnumerable<Player> players)
    {
        _playerStates = new Dictionary<Player, PlayerState>();
        foreach(Player player in players)
        {
            _playerStates.Add(player, new PlayerState(player, new GameResources(100, 100, 100)));
        }
    }

    private PlayerStates(PlayerStates original)
    {
        _playerStates = original._playerStates.Values.Select(s => s.Clone()).ToDictionary(s => s.Player);
    }

    public PlayerState GetPlayerState(Player player)
    {
        return _playerStates[player];
    }

    public PlayerStates Clone()
    {
        return new PlayerStates(this);
    }

    public ReadOnlyPlayerStates AsReadOnly()
    {
        return new ReadOnlyPlayerStates(this);
    }
}