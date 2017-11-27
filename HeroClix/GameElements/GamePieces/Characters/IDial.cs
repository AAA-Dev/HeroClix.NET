using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroClix.GameElements.GamePieces.Characters
{
    public interface IDial
    {
        Click TurnDialForDamage(int numberOfTimes);
        Click TurnDialForHealing(int numberOfTimes);
        Click CurrentClick();
    }
}
