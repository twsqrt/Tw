using System;
using UnityEngine;
   
[CreateAssetMenu(fileName = "New Building Factory", order = 51)]
public class BuildingFactory : ScriptableObject
{

    public Building Create(BuildingInfo buildingInfo, Player owner)
    {
        Building building = Instantiate(buildingInfo.Prefab);
        building.Init(this, buildingInfo, owner);
        return building;
    } 


    public void Destroy(Building building)
    {
        Destroy(building.gameObject);
    }
}