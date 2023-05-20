using System;
using UnityEngine;

public class MoveBuildingSelector : ParameterSelector<IBuildingMove>
{
    [SerializeField] private BuildingFactory _buildingFactory;
    [SerializeField] private BuildingButton[] _buttons;

    private IBuildingMove _buildingMove;

    public override void Init()
    {
        gameObject.SetActive(false);
        foreach(BuildingButton button in _buttons)
        {
            button.Init();
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

    private void BuildingButtonHandler(BuildingInfo buildingInfo)
    {
        _buildingMove.BuildingInfo = buildingInfo;
        Exit();
    }
}