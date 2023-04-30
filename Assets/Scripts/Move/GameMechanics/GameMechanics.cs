using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class GameProcess : Move
{
    public override bool IsValidMove(Map map)
    {
        return true;
    }


}
