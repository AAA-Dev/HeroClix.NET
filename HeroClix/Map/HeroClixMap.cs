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
        private MapType type;
        private IntellectualProperty intellectualProperty;
        private string set;
        private HeroClixAge age;

        /// <summary>
        /// Creates a standard sized, outdoor HeroClix map filled with clear Tiles.
        /// </summary>
        public HeroClixMap()
        {
            Name = "";
            type = MapType.Outdoor;
            intellectualProperty = IntellectualProperty.Other;
            set = "N/A";
            age = HeroClixAge.Other;
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
        /// Creates a HeroClix map of the specified dimensions filled with clear Tiles.
        /// </summary>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="mapType">The type of HeroClix map being created.</param>
        /// <param name="rows">The number of rows the map will have.</param>
        /// <param name="columns">The number of columns the map will have.</param>
        public HeroClixMap(string mapName, MapType mapType, IntellectualProperty property, string setName, HeroClixAge heroClixAge, int rows, int columns)
        {
            Name = mapName;
            type = mapType;
            intellectualProperty = property;
            set = setName;
            age = heroClixAge;
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
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="mapType">The type of HeroClix map being created.</param>
        /// <param name="tiles">The 2D array of Tiles which make up the map.</param>
        public HeroClixMap(string mapName, MapType mapType, IntellectualProperty property, string setName, HeroClixAge heroClixAge, Tile[,] mapTiles)
        {
            Name = mapName;
            type = mapType;
            intellectualProperty = property;
            set = setName;
            age = heroClixAge;
            tiles = ValidateTiles(mapTiles);
        }

        /// <summary>
        /// Gets or Sets the name of a HeroClix map.
        /// </summary>
        public string Name { get; set; }

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
        /// Gets the HeroClixAge that the HeroClixMap belongs to.
        /// </summary>
        public HeroClixAge Age
        {
            get
            {
                return age;
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
        /// Returns the 2d array of Tiles for a Map if they are valid, otherwise throws an Exception.
        /// </summary>
        /// <param name="tiles">The 2D Tile array to validate.</param>
        /// <returns>A valid 2D array of Tiles for a Map.</returns>
        private Tile[,] ValidateTiles(Tile[,] tiles)
        {
            if (type != MapType.IndoorOutdoor)
            {
                for (int i = 0; i < tiles.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < tiles.GetUpperBound(1) + 1; j++)
                    {
                        if (IndoorBorderExists(tiles[i, j]))
                        {
                            throw new InvalidOperationException("Tile[" + i + "," + j + "]: A tile on an Indoor map has no need for an Indoor border.");
                        }
                    }
                }
            }
            else
            {
                bool foundIndoorBorder = false;
                for (int i = 0; i < tiles.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < tiles.GetUpperBound(1) + 1; j++)
                    {
                        if (IndoorBorderExists(tiles[i, j]))
                        {
                            foundIndoorBorder = true;
                            break;
                        }
                    }
                    if (foundIndoorBorder)
                    {
                        break;
                    }
                }
                if (!foundIndoorBorder)
                {
                    throw new InvalidOperationException("An Indoor/Outdoor map requires tiles with an Indoor BorderType. Try changing the MapType or adding Indoor Borders to Tiles.");
                }
            }
            return tiles;
        }

        /// <summary>
        /// Checks if a tile has an Indoor Border on one of its sides.
        /// </summary>
        /// <param name="tile">The tile to check.</param>
        /// <returns>True if the tile has an Indoor Border on one of its sides, false otherwise.</returns>
        private bool IndoorBorderExists(Tile tile)
        {
            bool indoorBorderFound = false;
            List<BorderType> topBorder = tile.GetBorderDetails().Top;
            List<BorderType> rightBorder = tile.GetBorderDetails().Right;
            List<BorderType> bottomBorder = tile.GetBorderDetails().Bottom;
            List<BorderType> leftBorder = tile.GetBorderDetails().Left;
            if (topBorder.Any() && topBorder.Exists(x => x == BorderType.Indoor)
                || rightBorder.Any() && rightBorder.Exists(x => x == BorderType.Indoor)
                || bottomBorder.Any() && bottomBorder.Exists(x => x == BorderType.Indoor)
                || leftBorder.Any() && leftBorder.Exists(x => x == BorderType.Indoor))
            {
                indoorBorderFound = true;
            }
            return indoorBorderFound;
        }
    }
}
