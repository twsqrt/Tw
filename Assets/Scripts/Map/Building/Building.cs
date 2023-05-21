using System;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private ColorSetter _colorSetter;
    private BuildingInfo _info;
    private Player _owner;
    private BuildingFactory _factory;
    public Player Owner => _owner;

    public BuildingInfo Info => _info;

    public void Init(BuildingFactory factory, BuildingInfo info, Player owner)
    {
        _factory = factory;
        _info = info;
        _owner = owner;

        _colorSetter.SetColor(_owner.Info.Color);
    }

    public void DestroyBuilding()
    {
        _factory.Destroy(this);
    }
}