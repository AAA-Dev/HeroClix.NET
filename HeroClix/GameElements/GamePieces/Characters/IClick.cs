using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HeroClix.GameElements.GamePieces.Characters
{
    public interface IClick
    {
        Color GetClickColor();
        int GetClickNumber();
        int GetSpeedValue();
        int GetAttackValue();
        int GetDefenseValue();
        int GetDamageValue();
        bool IsStartingClick();
    }
}
