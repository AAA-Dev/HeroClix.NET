using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Map
{
    /// <summary>
    /// The playing field for HeroClix characters
    /// </summary>
    public class HeroClixMap
    {
        private const int STANDARD_ROWS = 16;
        private const int STANDARD_COLUMNS = 24;
        private Tile[,] tiles;

        /// <summary>
        /// Creates a standard sized HeroClix map filled with clear Tiles.
        /// </summary>
        public HeroClixMap()
            : this(STANDARD_ROWS, STANDARD_COLUMNS)
        {
            Name = "";
        }

        /// <summary>
        /// Creates a HeroClix map of the specified dimensions filled with clear Tiles.
        /// </summary>
        /// <param name="rows">The number of rows the map will have.</param>
        /// <param name="columns">The number of columns the map will have.</param>
        public HeroClixMap(int rows, int columns)
        {
            tiles = new Tile[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    tiles[i, j] = new Tile();
                }
            }
        }

        /// <summary>
        /// Creates a named HeroClix map using the specified 2D array of Tiles.
        /// </summary>
        /// <param name="mapName">The name of the HeroClix map.</param>
        /// <param name="tiles">The 2D array of Tiles which make up the map.</param>
        public HeroClixMap(string mapName, Tile[,] mapTiles)
        {
            Name = mapName;
            tiles = mapTiles;
        }

        /// <summary>
        /// Gets or Sets the name of a HeroClix map.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns all of the tiles that a HeroClixMap consists of as a 2D array.
        /// </summary>
        /// <returns>A 2D array of Tile objects which makes up the HeroClixMap.</returns>
        public Tile[,] GetTiles()
        {
            return this.tiles;
        }
    }
}
