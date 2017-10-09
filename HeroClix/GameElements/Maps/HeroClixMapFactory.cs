using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Maps
{
    public class HeroClixMapFactory : IHeroClixMapFactory
    {
        private IntellectualProperty intellectualProperty;

        /// <summary>
        /// Creates a new HeroClixMapFactory.
        /// </summary>
        /// <param name="IP">The IntellectualProperty of the HeroClixMaps that will be made by this factory.</param>
        public HeroClixMapFactory(IntellectualProperty IP)
        {
            this.intellectualProperty = IP;
        }

        /// <summary>
        /// Creates an indoor HeroClix map of standard size filled with clear Tiles.
        /// </summary>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <returns>An indoor HeroClix map.</returns>
        public IHeroClixMap CreateIndoorMap(string setName, string mapName)
        {
            return new IndoorMap(this.intellectualProperty, setName, mapName);
        }

        /// <summary>
        /// Creates an indoor HeroClix map of the specified dimensions filled with clear Tiles.
        /// </summary>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="rows">The number of rows the map will have.</param>
        /// <param name="columns">The number of columns the map will have.</param>
        /// <returns>An indoor HeroClix map.</returns>
        public IHeroClixMap CreateIndoorMap(string setName, string mapName, int rows, int columns)
        {
            return new IndoorMap(this.intellectualProperty, setName, mapName, rows, columns);
        }

        /// <summary>
        /// Creates an indoor HeroClix map using the specified 2D array of Tiles.
        /// </summary>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="tiles">The 2D array of Tiles which make up the map.</param>
        /// <returns>An indoor HeroClix map.</returns>
        public IHeroClixMap CreateIndoorMap(string setName, string mapName, Tile[,] tiles)
        {
            return new IndoorMap(this.intellectualProperty, setName, mapName, tiles);
        }

        /// <summary>
        /// Creates an outdoor HeroClix map of standard size filled with clear Tiles.
        /// </summary>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <returns>An outdoor HeroClix map.</returns>
        public IHeroClixMap CreateOutdoorMap(string setName, string mapName)
        {
            return new OutdoorMap(this.intellectualProperty, setName, mapName);
        }

        /// <summary>
        /// Creates an outdoor HeroClix map of the specified dimensions filled with clear Tiles.
        /// </summary>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="rows">The number of rows the map will have.</param>
        /// <param name="columns">The number of columns the map will have.</param>
        /// <returns>An outdoor HeroClix map.</returns>
        public IHeroClixMap CreateOutdoorMap(string setName, string mapName, int rows, int columns)
        {
            return new OutdoorMap(this.intellectualProperty, setName, mapName, rows, columns);
        }

        /// <summary>
        /// Creates an outdoor HeroClix map using the specified 2D array of Tiles.
        /// </summary>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="tiles">The 2D array of Tiles which make up the map.</param>
        /// <returns>An outdoor HeroClix map.</returns>
        public IHeroClixMap CreateOutdoorMap(string setName, string mapName, Tile[,] tiles)
        {
            return new OutdoorMap(this.intellectualProperty, setName, mapName, tiles);
        }

        /// <summary>
        /// Creates an indoor/outdoor HeroClix map of standard size filled with clear Tiles.
        /// </summary>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <returns>An indoor/outdoor HeroClix map.</returns>
        public IHeroClixMap CreateIndoorOutdoorMap(string setName, string mapName)
        {
            return new IndoorOutdoorMap(this.intellectualProperty, setName, mapName);
        }

        /// <summary>
        /// Creates an indoor/outdoor HeroClix map of the specified dimensions filled with clear Tiles.
        /// </summary>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="rows">The number of rows the map will have.</param>
        /// <param name="columns">The number of columns the map will have.</param>
        /// <returns>An indoor/outdoor HeroClix map.</returns>
        public IHeroClixMap CreateIndoorOutdoorMap(string setName, string mapName, int rows, int columns)
        {
            return new IndoorOutdoorMap(this.intellectualProperty, setName, mapName, rows, columns);
        }

        /// <summary>
        /// Creates an indoor/outdoor HeroClix map using the specified 2D array of Tiles.
        /// </summary>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="tiles">The 2D array of Tiles which make up the map.</param>
        /// <returns>An indoor/outdoor HeroClix map.</returns>
        public IHeroClixMap CreateIndoorOutdoorMap(string setName, string mapName, Tile[,] tiles)
        {
            return new IndoorOutdoorMap(this.intellectualProperty, setName, mapName, tiles);
        }
    }
}
