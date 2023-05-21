using System;
using UnityEngine;

public class Building
{
    private BuildingInfo _info;
    private Player _owner;
    public Player Owner => _owner;

    public BuildingInfo Info => _info;

    public Building(BuildingInfo info, Player owner)
    {
        _info = info;
        _owner = owner;
    }
}