using HeroClix.GameElements;
using HeroClix.Map.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Map
{
    public interface IMarker : IGamePiece
    {
        string GetName();

        TerrainType GetTerrainType { get; }
    }
}
