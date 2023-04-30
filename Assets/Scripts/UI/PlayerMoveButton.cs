using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected PlayerMoveType _moveType;

    public PlayerMoveType MoveType => _moveType;

    public Action<PlayerMoveButton> OnButtonClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnButtonClick?.Invoke(this);
    }
}
