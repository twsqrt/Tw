using System;
using System.Linq;

public class ReadOnlyPlayerStates
{
    private PlayerStates _playerStates;

    public ReadOnlyPlayerStates(PlayerStates playerStates)
    {
        _playerStates = playerStates;
    }

    public ReadOnlyPlayerState GetPlayerState(Player player)
    {
        return _playerStates.GetPlayerState(player).AsReadOnly();
    }
}