using System;
using UnityEngine; 
using TMPro;

public class GameStateView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameStateTimeText;

    public void Init(GameState gameState)
    {
        gameState.OnPlayerMoveApplied += Render;
        Render(gameState);
    }

    public void Render(GameState gameState)
    {
        _gameStateTimeText.text = gameState.Time.ToString();
    }
}