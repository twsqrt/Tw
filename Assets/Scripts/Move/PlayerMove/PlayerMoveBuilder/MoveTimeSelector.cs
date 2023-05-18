using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveTimeSelector : ParameterSelector<ITimeMove>
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private CountButton[] _buttons;
    [SerializeField] private TextMeshProUGUI _timeText;

    int _time;

    private int Time
    {
        get
        {
            return _time;
        }

        set
        {
            _time = value;
            _timeText.text = _time.ToString();
        }
    }

    ITimeMove _timeMove;

    protected override void AfterStart(ITimeMove timeMove)
    {
        gameObject.SetActive(true);
        _timeMove = timeMove;
    }

    protected override void BeforeExit()
    {
        gameObject.SetActive(false);
    }

    public override void Init()
    {
        _nextButton.onClick.AddListener(Exit);
        Time = 0;

        foreach(CountButton button in _buttons)
        {
            button.OnButtonClick += TimeChangeHandler;
        }
    }

    private void TimeChangeHandler(int timeOffset)
    {
        Time += timeOffset;
    }
}