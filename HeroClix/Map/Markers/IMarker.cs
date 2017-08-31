using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Map
{
    public interface IMarker
    {
        TerrainType MyTerrainType { get; }
    }
}
