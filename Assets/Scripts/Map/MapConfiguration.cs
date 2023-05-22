using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map Configuration", order =51)]
public class MapConfiguration : ScriptableObject
{
    [SerializeField] private int _mapWidth;
    [SerializeField] private int _mapHeight;
    [SerializeField] private BiomFactory _biomFactory;

    public int MapWidth => _mapWidth;
    public int MapHeight => _mapHeight;
    public BiomFactory BiomFactory => _biomFactory; 
}