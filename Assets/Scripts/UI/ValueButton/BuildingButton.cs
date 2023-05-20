using System;
using UnityEngine;
using TMPro;

public class BuildingButton : ValueButton<BuildingInfo> 
{
    [SerializeField] private TextMeshProUGUI _buildingName;
    [SerializeField] private TextMeshProUGUI _buildingCost;

    public void Init()
    {
        _buildingName.text = Value.Name;
        _buildingCost.text = Value.Cost.ToString();
    }
}