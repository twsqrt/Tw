using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameStateButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameStateView _gameStateView;

    private GameState _gameState;

    public void Init(GameState gameState)
    {
        _gameState = gameState;
        _gameStateView.Init(gameState);
    }

    public event Action<GameState> OnButtonClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnButtonClick?.Invoke(_gameState);
    }
}