using System;
using UnityEngine;


[CreateAssetMenu(fileName = "New Building Info", order = 51)]
public class BuildingInfo : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private GameResources _cost; 
    [SerializeField] private Building _prefab;
    [SerializeField] private bool _isMinesResources;

    public string Name => _name;
    public GameResources Cost => _cost;
    public Building Prefab => _prefab;
    public bool IsMinesResources => _isMinesResources;

}