using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayersView : MonoBehaviour
{
    [SerializeField] private PlayerView _playerViewPrefab;
    [SerializeField] private Transform _container;

    public void Init(IEnumerable<Player> players)
    {
        foreach(Player player in players)
        {
            PlayerView view = Instantiate(_playerViewPrefab, _container);
            view.Init(player);
        }
    }
}
