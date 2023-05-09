using System;
using UnityEngine;

public class PlayerMoveBuilder : MonoBehaviour 
{
    [SerializeField] private PlayerMoveBuilderTransition[] _transition;
    [SerializeField] private BuilderFinalState _finalState;
    [SerializeField] private PlayerMoveButton[] _buttons;

    //template solution
    public Player Player;

    public void Init()
    {
        foreach(PlayerMoveButton button in _buttons)
        {
            button.OnButtonClick += StartBuilding;
        }
    } 


    public void AddListener(Action<PlayerMove> action)
    {
        _finalState.IsEntered += action;
    }

    public void StartBuilding(PlayerMoveType moveType)
    {
        PlayerMove move = PlayerMove.Create(moveType, Player);

        foreach(var transition in _transition )
        {
            if(transition.TryEnterNext(move, moveType))
                return;
        }
    }
}
