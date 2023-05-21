using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Biom Factory", order = 51)]
public class BiomFactory : ScriptableObject
{
    [SerializeField] private Biom _ocean;
    [SerializeField] private Biom _beach;
    [SerializeField] private Biom _plains;
    [SerializeField] private Biom _forest;
    [SerializeField] private Biom _mountains;
    public Biom Create(BiomType type)
    {
        switch (type)
        {
            case BiomType.Ocean:
                return _ocean;
            case BiomType.Beach:
                return _beach;
            case BiomType.Plains:
                return _plains;
            case BiomType.Forest:
                return _forest;
            case BiomType.Mountains:
                return _mountains;
            default:
                throw new NotImplementedException();
        }
    }
}
