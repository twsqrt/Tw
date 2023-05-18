using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCountSelector : MonoBehaviour
{
    [SerializeField] private GameResourceType _resourceType;
    [SerializeField] private CountButton[] _buttons;
    [SerializeField] private TextMeshProUGUI _currentCountText;

    private int _currentCount;

    public event Action<GameResourceType, int> OnCountChange;
    public int CurrentCount
    {
        get
        {
            return _currentCount;
        }

        private set
        {
            _currentCount = value;
            _currentCountText.text = _currentCount.ToString();
            OnCountChange?.Invoke(_resourceType, _currentCount);
        }
    }

    public void Init()
    {
        CurrentCount = 0;
        foreach(CountButton button in _buttons)
        {
            button.OnButtonClick += CountButtonHandler;
        }
    }

    public void Reset()
    {
        CurrentCount = 0;
    } 

    private void CountButtonHandler(int value)
    {
        if(CurrentCount + value < 0)
            CurrentCount = 0;
        else
            CurrentCount += value;
    }
}