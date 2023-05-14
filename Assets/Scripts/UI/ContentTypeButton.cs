using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ContentTypeButton<T> : MonoBehaviour, IPointerClickHandler where T : struct, IConvertible
{
    [SerializeField] private T _type;

    public event Action<T> OnButtonClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnButtonClick?.Invoke(_type);
    }
}
