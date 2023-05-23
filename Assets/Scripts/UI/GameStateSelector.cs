using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSelector : MonoBehaviour
{
    [SerializeField] private GameStateButton _gameStateButtonPrefab;
    [SerializeField] private Transform _container;

    private IEnumerable<GameStateButton> _gameStateButtons;

    public void Init(IEnumerable<GameState> gameStates)
    {
        List<GameStateButton> gameStateButtonsList = new List<GameStateButton>();
        foreach(GameState gameState in gameStates)
        {
            GameStateButton gameStateButton = Instantiate(_gameStateButtonPrefab, _container);
            gameStateButton.Init(gameState);
            gameStateButtonsList.Add(gameStateButton);
        }

        _gameStateButtons = gameStateButtonsList;
    }

    public void AddListener(Action<GameState> action)
    {
        foreach(GameStateButton button in _gameStateButtons)
        {
            button.OnButtonClick += action;
        }
    }
}