using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Map
{
    public abstract class HeroClixMapFactory
    {
        public abstract IHeroClixMap CreateIndoorMap(string setName, string mapName);
        public abstract IHeroClixMap CreateIndoorMap(string setName, string mapName, int rows, int columns);
        public abstract IHeroClixMap CreateIndoorMap(string setName, string mapName, Tile[,] tiles);

        public abstract IHeroClixMap CreateOutdoorMap(string setName, string mapName);
        public abstract IHeroClixMap CreateOutdoorMap(string setName, string mapName, int rows, int columns);
        public abstract IHeroClixMap CreateOutdoorMap(string setName, string mapName, Tile[,] tiles);

        public abstract IHeroClixMap CreateIndoorOutdoorMap(string setName, string mapName);
        public abstract IHeroClixMap CreateIndoorOutdoorMap(string setName, string mapName, int rows, int columns);
        public abstract IHeroClixMap CreateIndoorOutdoorMap(string setName, string mapName, Tile[,] tiles);
    }
}
