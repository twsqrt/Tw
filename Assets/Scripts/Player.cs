using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Player
{
    [SerializeField] private string _name;
    [SerializeField] private Color _color;


    private GameResources _resources = new GameResources(100, 100, 100);

    public Action<Player> OnPlayerDataChanged;
    public string Name => _name;
    public Color Color => _color;

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
}
