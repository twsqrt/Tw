using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Biom : MonoBehaviour
{
    [SerializeField] private BiomType _type;
    [SerializeField] private bool _canPlaceBulidingsOn;
    [SerializeField] private bool _isAirBarrier;
    [SerializeField] private GameResources _resources;

    private BiomFactory _factory;
    public BiomType Type => _type;
    public bool CanPlaceBulidingsOn => _canPlaceBulidingsOn;
    public bool IsAirBarrier => _isAirBarrier;

    public GameResources Resources => _resources;

    public void Init(BiomFactory factory)
    {
        _factory = factory;
    }

    public void DestroyContent()
    {
        _factory.Destroy(this);
    }
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
