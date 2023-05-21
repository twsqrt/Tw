using System;
using UnityEngine;

public class BiomView : MonoBehaviour
{
    BiomViewFactory _factory;
    public void Init(BiomViewFactory factory)
    {
        _factory = factory;
    }

    public void Destroy()
    {
        _factory.Destroy(this);
    }
}
