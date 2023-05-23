using System;
using UnityEngine;

public class BuildingView : MonoBehaviour
{
    [SerializeField] private ColorSetter _colorSetter;

    private BuildingViewFactory _factory;


    public void Init(BuildingViewFactory factory, Color buildingColor)
    {
        _factory = factory;
        _colorSetter.SetColor(buildingColor);
    }

    public void Destroy()
    {
        _factory.Destroy(this);
    }
}