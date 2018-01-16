using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroClix.GameElements.GamePieces.Characters
{
    public interface IBaseCombatInformation
    {
        int GetBaseRange();
        int GetBaseNumberOfTargets();
    }
}
