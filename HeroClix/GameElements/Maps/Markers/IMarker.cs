using HeroClix.GameElements;
using HeroClix.Maps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Maps
{
    public interface IMarker
    {
        string GetName();

        TerrainType GetTerrainType { get; }
    }
}
