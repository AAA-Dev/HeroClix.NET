using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Map
{
    public interface IHeroClixMapFactory
    {
        IHeroClixMap CreateIndoorMap(string setName, string mapName);
        IHeroClixMap CreateIndoorMap(string setName, string mapName, int rows, int columns);
        IHeroClixMap CreateIndoorMap(string setName, string mapName, Tile[,] tiles);

        IHeroClixMap CreateOutdoorMap(string setName, string mapName);
        IHeroClixMap CreateOutdoorMap(string setName, string mapName, int rows, int columns);
        IHeroClixMap CreateOutdoorMap(string setName, string mapName, Tile[,] tiles);

        IHeroClixMap CreateIndoorOutdoorMap(string setName, string mapName);
        IHeroClixMap CreateIndoorOutdoorMap(string setName, string mapName, int rows, int columns);
        IHeroClixMap CreateIndoorOutdoorMap(string setName, string mapName, Tile[,] tiles);
    }
}
