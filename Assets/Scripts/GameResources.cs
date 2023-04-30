using Mono.Cecil;
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
    public int Resource1;
    public int Resource2;
    public int Resource3;

    public GameResources(int resource1, int resource2, int resource3)
    {
        Resource1 = resource1;
        Resource2 = resource2;
        Resource3 = resource3;
    }


    public static GameResources zero => new GameResources(0, 0, 0);

    public int Sum()
    {
        return Resource1 + Resource2 + Resource3;
    }

    public override string ToString()
    {
        return $"resource1 = {Resource1}, resource2 = {Resource2}, resource3 = {Resource3}";
    }

    public bool IsEnough(GameResources cost)
    {
        return Resource1 >= cost.Resource1
            && Resource2 >= cost.Resource2
            && Resource3 >= cost.Resource3;
    }

    public static GameResources operator +(GameResources a, GameResources b)
    {
        return new GameResources(a.Resource1 + b.Resource1, a.Resource2 + b.Resource2, a.Resource3 + b.Resource3);
    }

    public static GameResources operator -(GameResources a)
    {
        return new GameResources(-a.Resource1, -a.Resource2, -a.Resource3);
    }

    public static GameResources operator -(GameResources a, GameResources b)
    {
        return a + -b; 
    }

    public static GameResources operator *(float coef, GameResources a) 
    {
        return new GameResources((int)(coef * a.Resource1), (int)(coef * a.Resource2), (int)(coef * a.Resource3));
    }
    public static GameResources operator *(GameResources a, float coef)
    {
        return coef * a;
    }

}
