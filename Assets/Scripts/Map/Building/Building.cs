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

    private Building(Building original)
    {
        _info = original.Info;
        _owner = original.Owner;
    }

    public Building Clone()
    {
        return new Building(this);
    }  
}