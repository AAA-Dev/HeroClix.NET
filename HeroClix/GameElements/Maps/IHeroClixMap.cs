using HeroClix.Maps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Maps
{
    public interface IHeroClixMap
    {
        IntellectualProperty IP { get; }
        string Set { get; }
        string Name { get; }
        MapType MapType { get; }
        Tile[,] GetTiles();
    }
}
