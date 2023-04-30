using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ColorSeter : MonoBehaviour
{
    public void SetColor(Color color)
    {
        IEnumerable<MeshRenderer> renderers = GetComponentsInChildren<MeshRenderer>();

        if(renderers != null)
        {
            foreach(MeshRenderer renderer in renderers)
            {
                renderer.material.color = color;
            }
        }
    }
}
