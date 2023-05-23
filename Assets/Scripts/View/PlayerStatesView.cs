using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerStatesView : MonoBehaviour
{
    [SerializeField] private PlayerStateView _playerStateViewPrefab;
    [SerializeField] private Transform _container;

    public void Init(PlayerStates playerStates)
    {
        foreach(PlayerState player in playerStates.Players)
        {
            PlayerStateView view = Instantiate(_playerStateViewPrefab, _container);
            view.Init(player);
        }
    }
}
