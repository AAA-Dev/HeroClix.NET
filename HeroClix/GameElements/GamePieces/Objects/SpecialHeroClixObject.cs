using HeroClix.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix
{
    public class SpecialHeroClixObject : HeroClixObject
    {
        private int pointValue;

        public SpecialHeroClixObject()
        {
            // TODO: Write Implementation
        }

        public override int GetPointValue()
        {
            return this.pointValue;
        }
    }
}
