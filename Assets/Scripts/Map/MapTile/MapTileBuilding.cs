using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MapTileBuilding : MonoBehaviour
{
    [SerializeField] private MapTileBuildingType _type;
    [SerializeField] private GameResources _cost;
    [SerializeField] private ColorSeter _colorSeter;

    private Player _owner;
    private MapTileBuildingFactory _factory;

    public MapTileBuildingType Type => _type;
    public Player Owner => _owner;
    public GameResources Cost => _cost;


    public void Init(MapTileBuildingFactory factory, Player player)
    {
        _factory = factory;
        _owner = player;
        _colorSeter.SetColor(player.Color);
        _cost = new GameResources(5, 10, 15);
    }

    public void DestroyContent()
    {
        _factory.DestroyBuliding(this);
    }
}

[Serializable]
public enum MapTileBuildingType
{
    Settlement,
    Pier,
    Airport,
    Artillery
}
