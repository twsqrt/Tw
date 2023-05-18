using System;
using UnityEngine;

public class MoveBuildingSelector : ParameterSelector<IBuildingMove>
{
    [SerializeField] private MapTileBuildingFactory _buildingFactory;
    [SerializeField] private BuildingButton[] _buttons;

    private IBuildingMove _buildingMove;

    public override void Init()
    {
        gameObject.SetActive(false);
        foreach(BuildingButton button in _buttons)
        {
            button.OnButtonClick += BuildingButtonHandler;
        }
    }

    protected override void AfterStart(IBuildingMove buildingMove)
    {
        gameObject.SetActive(true);
        _buildingMove = buildingMove;
        _buildingMove.BuildingFactory = _buildingFactory;
    }

    protected override void BeforeExit()
    {
        gameObject.SetActive(false);
    }

    private void BuildingButtonHandler(MapTileBuildingType buildingType)
    {
        _buildingMove.BuildingType = buildingType;
        Exit();
    }
}