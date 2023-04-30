using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Biom Factory", order = 51)]
public class MapTileBiomFactory : ScriptableObject
{
    [SerializeField] private MapTileBiom _oceanPrefab;
    [SerializeField] private MapTileBiom _beachPrefab;
    [SerializeField] private MapTileBiom _plainsPrefab;
    [SerializeField] private MapTileBiom _forestPrefab;
    [SerializeField] private MapTileBiom _mountainsPrefab;
    public MapTileBiom Create(MapTileBiomType type)
    {
        MapTileBiom selectedPrefab;
        switch (type)
        {
            case MapTileBiomType.Ocean:
                selectedPrefab = _oceanPrefab;
                break;
            case MapTileBiomType.Beach:
                selectedPrefab = _beachPrefab;
                break;
            case MapTileBiomType.Plains:
                selectedPrefab = _plainsPrefab;
                break;
            case MapTileBiomType.Forest:
                selectedPrefab = _forestPrefab;
                break;
            case MapTileBiomType.Mountains:
                selectedPrefab = _mountainsPrefab;
                break;
            default:
                throw new NotImplementedException();
        }

        return CreateByPrefab(selectedPrefab);
    }
    public MapTileBiom CreateByPrefab(MapTileBiom prefab)
    {
        MapTileBiom newBiom = Instantiate(prefab);
        newBiom.Init(this);
        return newBiom;
    }
    public void Destroy(MapTileBiom content)
    {
        Destroy(content.gameObject);
    }
}
