using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Info", order = 51)]
public class Player :  ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Color _color;

    public int Id => _id;
    public string Name => _name;
    public Color Color => _color;


    public override bool Equals(object obj)
    {
        if(obj is Player info )
        {
            return _id == info.Id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }
}