using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PlayerMoveType _moveType;

    public PlayerMoveType MoveType => _moveType;

    public event Action<PlayerMoveType> OnButtonClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnButtonClick?.Invoke(_moveType);
    }
}
