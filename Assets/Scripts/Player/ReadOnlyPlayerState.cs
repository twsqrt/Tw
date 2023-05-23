using System;

public class ReadOnlyPlayerState
{
    private PlayerState _playerState;

    public ReadOnlyPlayerState(PlayerState playerState)
    {
        _playerState = playerState;
    }

    public Player Player => _playerState.Player;
    public GameResources Resources => _playerState.Resources;

}