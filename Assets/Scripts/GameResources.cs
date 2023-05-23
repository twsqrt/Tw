using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct GameResources
{
    public int Wood;
    public int Coal;
    public int Oil;
    
    public GameResources(int wood = 0, int coal = 0, int oil = 0)
    {
        Wood = wood;
        Coal = coal;
        Oil = oil;
    }

    public static GameResources zero => new GameResources(0, 0, 0);

    public int Sum()
    {
        return Wood + Coal + Oil;
    }

    public override string ToString()
    {
        return $"Wood:{Wood} Coal:{Coal} Oil:{Oil}";
    }

    public bool IsEnoughTo(GameResources cost)
    {
        return Wood >= cost.Wood
            && Coal >= cost.Coal
            && Oil >= cost.Oil;
    }

    public static GameResources operator +(GameResources a, GameResources b)
    {
        return new GameResources(a.Wood + b.Wood, a.Coal + b.Coal, a.Oil + b.Oil);
    }

    public static GameResources operator -(GameResources a)
    {
        return new GameResources(-a.Wood, -a.Coal, -a.Oil);
    }

    public static GameResources operator -(GameResources a, GameResources b)
    {
        return a + -b; 
    }

    public static GameResources operator *(float coef, GameResources a) 
    {
        return new GameResources((int)(coef*a.Wood), (int)(coef*a.Coal), (int)(coef*a.Oil));
    }
    public static GameResources operator *(GameResources a, float coef)
    {
        return coef * a;
    }
}
