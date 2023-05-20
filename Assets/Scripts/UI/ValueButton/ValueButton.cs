using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ValueButton<T> : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected T Value;

    public event Action<T> OnButtonClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnButtonClick?.Invoke(Value);
    }
}
