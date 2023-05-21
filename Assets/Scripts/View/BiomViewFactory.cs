using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Biom View Factory", order = 51)]
public class BiomViewFactory : GameObjectFactory<Biom, BiomView>
{
    public override BiomView Create(Biom biom)
    {
        BiomView biomView = Instantiate(biom.Prefab);
        biomView.Init(this);

        return biomView;
    } 
}