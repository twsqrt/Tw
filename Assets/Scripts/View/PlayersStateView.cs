using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayersStateView : MonoBehaviour
{
    [SerializeField] private PlayerStateView _playerStateViewPrefab;
    [SerializeField] private Transform _container;

    public void Init(IEnumerable<PlayerState> players)
    {
        foreach(PlayerState player in players)
        {
            PlayerStateView view = Instantiate(_playerStateViewPrefab, _container);
            view.Init(player);
        }
    }
}
