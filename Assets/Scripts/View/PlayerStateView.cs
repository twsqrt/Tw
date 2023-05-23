using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PlayerStateView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;

    public void Init(PlayerState playerState)
    {
        _textMesh.color = playerState.Player.Color;
        playerState.OnPlayerDataChanged += Render;

        Render(playerState);
    }

    public void Render(PlayerState playerState)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Player: {playerState.Player.Name}");
        sb.AppendLine($"Resources: {playerState.Resources}");

        _textMesh.text = sb.ToString();
    }
}
