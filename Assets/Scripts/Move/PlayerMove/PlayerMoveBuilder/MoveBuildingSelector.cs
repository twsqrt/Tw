using System;
using UnityEngine;

public class MoveBuildingSelector : ParameterSelector<IBuildingMove>
{
    [SerializeField] private MapTileBuildingFactory _buildingFactory;
    [SerializeField] private BuildingButton[] _buttons;

    private IBuildingMove _buildingMove;
    
    private void OnEnable()
    {
        foreach(BuildingButton button in _buttons)
        {
            button.OnButtonClick += BuildingButtonHandler;
        }
    }

    private void OnDisable()
    {
        foreach(BuildingButton button in _buttons)
        {
            button.OnButtonClick -= BuildingButtonHandler;
        }
    }

    protected override void AfterStart(IBuildingMove buildingMove)
    {
        this.gameObject.SetActive(true);
        _buildingMove = buildingMove;
        _buildingMove.BuildingFactory = _buildingFactory;
    }

    protected override void BeforeExit()
    {
        this.gameObject.SetActive(false);
    }

    private void BuildingButtonHandler(MapTileBuildingType buildingType)
    {
        _buildingMove.BuildingType = buildingType;
        Exit();
    }
}