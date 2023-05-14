using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building Factory", order = 51)]
public class MapTileBuildingFactory : ScriptableObject
{
    [SerializeField] private MapTileBuilding _cettlementPrefab;
    [SerializeField] private MapTileBuilding _pierPrefab;
    [SerializeField] private MapTileBuilding _airportPrefab;
    [SerializeField] private MapTileBuilding _artilleryPrefab;
    public MapTileBuilding Create(MapTileBuildingType type, Player owner)
    {
        MapTileBuilding selectedPrefab;
        switch(type)
        {
            case MapTileBuildingType.Settlement:
                selectedPrefab = _cettlementPrefab;
                break;
            case MapTileBuildingType.NavalBase:
                selectedPrefab = _pierPrefab;
                break;
            case MapTileBuildingType.Airport:
                selectedPrefab = _airportPrefab;
                break;
            case MapTileBuildingType.Artillery:
                selectedPrefab = _artilleryPrefab;
                break;
            default:
                throw new NotImplementedException();

        }

        return CreateByPrefab(selectedPrefab, owner);
    }
    public MapTileBuilding CreateByPrefab(MapTileBuilding prefab, Player owner)
    {
        MapTileBuilding newContent = Instantiate(prefab);
        newContent.Init(this, owner);
        return newContent;
    }
    public void DestroyBuliding(MapTileBuilding content)
    {
        Destroy(content.gameObject);
    }
}

public enum MapTileBuildingType
{
    Settlement,
    NavalBase,
    Airport,
    Artillery
}