using System;
using UnityEngine;

public abstract class GameObjectFactory<TIn, TOut> : ScriptableObject where TOut : MonoBehaviour 
{
    public abstract TOut Create(TIn tIn);

    public void Destroy(TOut tOut)
    {
        Destroy(tOut.gameObject);
    }
}