﻿using HeroClix.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix
{
    public abstract class HeroClixObject : IGamePiece
    {
        public HeroClixObject()
        {
            // TODO: Write Implementation
        }

        public abstract int GetPointValue();
    }
}
