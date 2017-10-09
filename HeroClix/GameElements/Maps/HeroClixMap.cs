using HeroClix.Maps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Maps
{
    /// <summary>
    /// The playing field for HeroClix characters
    /// </summary>
    public abstract class HeroClixMap : IHeroClixMap, IGameElement
    {
        private const int STANDARD_ROWS = 16;
        private const int STANDARD_COLUMNS = 24;
        private IntellectualProperty intellectualProperty;
        private string set;
        private string name;
        private MapType type;
        private Tile[,] tiles;

        /// <summary>
        /// Creates a standard sized, indoor HeroClix map filled with clear Tiles.
        /// </summary>
        public HeroClixMap()
        {
            intellectualProperty = IntellectualProperty.Other;
            set = "";
            name = "";
            type = MapType.Indoor;
            tiles = new Tile[STANDARD_ROWS, STANDARD_COLUMNS];

            for (int i = 0; i < STANDARD_ROWS; i++)
            {
                for (int j = 0; j < STANDARD_COLUMNS; j++)
                {
                    tiles[i, j] = new Tile();
                }
            }
        }

        /// <summary>
        /// Creates a standard sized HeroClix map of the specified type filled with clear Tiles.
        /// </summary>
        public HeroClixMap(MapType mapType)
            : this()
        {
            type = mapType;
        }

        /// <summary>
        /// Creates a standard sized HeroClix map of the specified type filled with clear Tiles.
        /// </summary>
        /// <param name="IP">The Intellectual Property that the HeroClix map being created belongs to.</param>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="mapType">The type of HeroClix map being created.</param>
        public HeroClixMap(IntellectualProperty IP, string setName, string mapName, MapType mapType)
            : this()
        {
            intellectualProperty = IP;
            set = setName;
            name = mapName;
            type = mapType;
        }

        /// <summary>
        /// Creates a HeroClix map of the specified dimensions filled with clear Tiles.
        /// </summary>
        /// <param name="IP">The Intellectual Property that the HeroClix map being created belongs to.</param>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="mapType">The type of HeroClix map being created.</param>
        /// <param name="rows">The number of rows the map will have.</param>
        /// <param name="columns">The number of columns the map will have.</param>
        public HeroClixMap(IntellectualProperty IP, string setName, string mapName, MapType mapType, int rows, int columns)
        {
            intellectualProperty = IP;
            set = setName;
            name = mapName;
            type = mapType;
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
        /// Creates a HeroClix map using the specified 2D array of Tiles.
        /// </summary>
        /// <param name="IP">The Intellectual Property that the HeroClix map being created belongs to.</param>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="mapType">The type of HeroClix map being created.</param>
        /// <param name="tiles">The 2D array of Tiles which make up the map.</param>
        public HeroClixMap(IntellectualProperty IP, string setName, string mapName, MapType mapType, Tile[,] mapTiles)
        {
            intellectualProperty = IP;
            set = setName;
            name = mapName;
            type = mapType;
            tiles = ValidateTiles(mapTiles);
        }

        /// <summary>
        /// Gets the Intellectual Property that the HeroClixMap belongs to.
        /// </summary>
        public IntellectualProperty IP
        {
            get
            {
                return intellectualProperty;
            }
        }

        /// <summary>
        /// Gets the Set that the HeroClixMap belongs to.
        /// </summary>
        public string Set
        {
            get
            {
                return set;
            }
        }

        /// <summary>
        /// Gets the name of a HeroClix map.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Gets the MapType of a HeroClix map.
        /// </summary>
        public MapType MapType
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// Returns all of the tiles that a HeroClixMap consists of as a 2D array.
        /// </summary>
        /// <returns>A 2D array of Tile objects which makes up the HeroClixMap.</returns>
        public Tile[,] GetTiles()
        {
            return this.tiles;
        }

        /// <summary>
        /// Checks if a tile has an Indoor Border on one of its sides.
        /// </summary>
        /// <param name="tile">The tile to check.</param>
        /// <returns>True if the tile has an Indoor Border on one of its sides, false otherwise.</returns>
        protected bool IndoorBorderExists(Tile tile)
        {
            bool indoorBorderFound = false;
            List<BorderType> topBorder = tile.GetBorderDetails().Item1;
            List<BorderType> rightBorder = tile.GetBorderDetails().Item2;
            List<BorderType> bottomBorder = tile.GetBorderDetails().Item3;
            List<BorderType> leftBorder = tile.GetBorderDetails().Item4;
            if (topBorder.Any() && topBorder.Exists(x => x == BorderType.Indoor)
                || rightBorder.Any() && rightBorder.Exists(x => x == BorderType.Indoor)
                || bottomBorder.Any() && bottomBorder.Exists(x => x == BorderType.Indoor)
                || leftBorder.Any() && leftBorder.Exists(x => x == BorderType.Indoor))
            {
                indoorBorderFound = true;
            }
            return indoorBorderFound;
        }

        /// <summary>
        /// Returns the 2d array of Tiles for a Map if they are valid, otherwise throws an Exception.
        /// </summary>
        /// <param name="tiles">The 2D Tile array to validate.</param>
        /// <returns>A valid 2D array of Tiles for a Map.</returns>
        protected abstract Tile[,] ValidateTiles(Tile[,] tiles);
    }
}
