using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    public void Init(Player player)
    {
        textMeshProUGUI.color = player.Info.Color;
        player.OnPlayerDataChanged += Render;

        Render(player);
    }

    public void Render(Player player)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Player: {player.Info.Name}");
        sb.AppendLine($"Resources: {player.Resources}");

        textMeshProUGUI.text = sb.ToString();
    }
}
