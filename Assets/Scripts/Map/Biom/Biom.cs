using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Biom", order = 51)]
public class Biom : ScriptableObject
{
    //template solution
    [SerializeField] private BiomType _type;
    [SerializeField] private bool _isBuildingAllowed;
    [SerializeField] private bool _isAirBarrier;
    [SerializeField] private GameResources _resources;
    [SerializeField] private BiomView _prefab;

    public BiomType Type => _type;
    public bool IsBuildingAllowed => _isBuildingAllowed;
    public bool IsAirBarrier => _isAirBarrier;
    public GameResources Resources => _resources;
    public BiomView Prefab => _prefab;
}

[Serializable]
public enum BiomType
{
    Ocean,
    Beach,
    Plains,
    Forest,
    Mountains
}