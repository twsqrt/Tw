using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TerrainUtils;

public class Highlighter : MonoBehaviour
{
    [SerializeField] private Color _highlightColor;
    [SerializeField, Range(0f, 1f)] private float _colorAdditionCoefficient;

    private List<(MeshRenderer, Color)> _defaultColors = new List<(MeshRenderer, Color)>();
    private bool _isHighlighteEnable = false;
    private bool _shouldUpdateDefaultColorsList = false;

    public void MarkForUpdateDefaultColorsList()
    {
        _shouldUpdateDefaultColorsList = true;
    }

    private void UpdateDefaultColorsList()
    {
        _defaultColors.Clear();

        foreach(MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            _defaultColors.Add((meshRenderer, meshRenderer.material.color));
        }
    }

    public void HighligthEnable()
    {
        if (_isHighlighteEnable) 
            return;

        if (_shouldUpdateDefaultColorsList)
        {
            _shouldUpdateDefaultColorsList = false;
            UpdateDefaultColorsList();
        }

        _isHighlighteEnable = true;
        foreach(var (meshRenderer, defaultColor) in _defaultColors)
        {
            meshRenderer.material.color = Color.Lerp(defaultColor, _highlightColor, _colorAdditionCoefficient);
        }
    }

    public void HighlightDisable()
    {
        if (_isHighlighteEnable == false)
            return;

        _isHighlighteEnable = false;
        foreach(var (meshRenderer, defaultColor) in _defaultColors)
        {
            if(meshRenderer != null)
                meshRenderer.material.color = defaultColor;
        }
    }
}
