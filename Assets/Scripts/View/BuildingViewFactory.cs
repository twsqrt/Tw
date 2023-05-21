using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building View Factory", order = 51)]
public class BuildingViewFactory : GameObjectFactory<Building, BuildingView>
{
    public override BuildingView Create(Building building)
    {
        BuildingView buildingView = Instantiate(building.Info.Prefab);
        buildingView.Init(this, building.Owner.Info.Color);
        return buildingView;
    } 
}