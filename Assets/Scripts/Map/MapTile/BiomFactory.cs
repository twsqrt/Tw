using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Biom Factory", order = 51)]
public class BiomFactory : ScriptableObject
{
    [SerializeField] private Biom _oceanPrefab;
    [SerializeField] private Biom _beachPrefab;
    [SerializeField] private Biom _plainsPrefab;
    [SerializeField] private Biom _forestPrefab;
    [SerializeField] private Biom _mountainsPrefab;
    public Biom Create(BiomType type)
    {
        Biom selectedPrefab;
        switch (type)
        {
            case BiomType.Ocean:
                selectedPrefab = _oceanPrefab;
                break;
            case BiomType.Beach:
                selectedPrefab = _beachPrefab;
                break;
            case BiomType.Plains:
                selectedPrefab = _plainsPrefab;
                break;
            case BiomType.Forest:
                selectedPrefab = _forestPrefab;
                break;
            case BiomType.Mountains:
                selectedPrefab = _mountainsPrefab;
                break;
            default:
                throw new NotImplementedException();
        }

        return CreateByPrefab(selectedPrefab);
    }
    public Biom CreateByPrefab(Biom prefab)
    {
        Biom newBiom = Instantiate(prefab);
        newBiom.Init(this);
        return newBiom;
    }
    public void Destroy(Biom content)
    {
        Destroy(content.gameObject);
    }
}
