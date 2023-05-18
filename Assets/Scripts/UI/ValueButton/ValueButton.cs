using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ValueButton<T> : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private T _value;

    public event Action<T> OnButtonClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnButtonClick?.Invoke(_value);
    }
}
