using System;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour
{
    [SerializeField] MapTileViewFactory _mapTileViewFactory;

    public void Render(Map map)
    {
        int widthOffset = map.Width / 2;
        int heightOffset = map.Height / 2;

        Vector3 positionOffset = new Vector3(Mathf.Floor(map.Width / 2), 0f, Mathf.Floor(map.Height / 2));
        Vector3 positionWithOffset = transform.position - positionOffset;

        for(int i = 0; i < map.Width; i++)
        {
            for(int j = 0; j < map.Height; j++)
            {
                MapTileView tileView = _mapTileViewFactory.Create(map[i,j]);
                tileView.name = $"x:{i}, y:{j}";

                tileView.transform.localPosition = positionWithOffset + new Vector3(i, 0f, j);
                tileView.transform.SetParent(transform);
            }
        }
    } 

    public void CleanUp()
    {
        IEnumerable<MapTileView> tilesView = GetComponentsInChildren<MapTileView>(); 

        foreach(MapTileView tileView in tilesView)
        {
            tileView.Destroy();
        }
    }
}