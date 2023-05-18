using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveResourcesSelector : ParameterSelector<IResoucesMove>
{
    [SerializeField] private ResourceCountSelector[] _selectors;
    [SerializeField] private Button _nextButton;
    [SerializeField] private TextMeshProUGUI _resourceSumText;
    [SerializeField] private int _resourceMaxSum;

    private IResoucesMove _resourceMove;
    private GameResources _resources;

    protected override void AfterStart(IResoucesMove resourceMove)
    {
        gameObject.SetActive(true);
        _resourceMove = resourceMove;
        _resources = _resourceMove.Resources;
    }

    protected override void BeforeExit()
    {
        gameObject.SetActive(false);

        foreach(ResourceCountSelector selector in _selectors)
        {
            selector.Reset();
        }
    }

    public override void Init()
    {
        gameObject.SetActive(false);
        _resourceSumText.text = "0";

        _nextButton.onClick.AddListener(NextButtonHandler);
        foreach(ResourceCountSelector selector in _selectors)
        {
            selector.Init();
            selector.OnCountChange += SelectorHandler;
        }
    }

    private void SelectorHandler(GameResourceType resourceType, int number)
    {
        switch(resourceType)
        {
            case GameResourceType.Wood:
                _resources.Wood = number;
                break;
            case GameResourceType.Coal:
                _resources.Coal = number;
                break;
            case GameResourceType.Oil:
                _resources.Oil = number;
                break;
            default:
                throw new NotImplementedException();
        }

        _resourceSumText.text = _resources.Sum().ToString();
    }

    private void NextButtonHandler()
    {
        if(_resources.Sum() <= _resourceMaxSum)
        {
            _resourceMove.Resources = _resources;
            Exit();
        }
    } 
}