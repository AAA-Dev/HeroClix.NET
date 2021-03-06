﻿using HeroClix.Map.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Map
{
    public class IndoorOutdoorMap : HeroClixMap
    {
        /// <summary>
        /// Creates a standard sized, indoor/outdoor HeroClix map filled with clear Tiles.
        /// </summary>
        public IndoorOutdoorMap()
            : base(MapType.IndoorOutdoor)
        {
            // no op
        }

        /// <summary>
        /// Creates a standard sized, indoor/outdoor HeroClix map filled with clear Tiles.
        /// </summary>
        public IndoorOutdoorMap(IntellectualProperty IP, string setName, string mapName)
            : base(IP, setName, mapName, MapType.IndoorOutdoor)
        {
            // no op
        }

        /// <summary>
        /// Creates an Indoor/Outdoor HeroClix map of the specified dimensions filled with clear Tiles.
        /// </summary>
        /// <param name="IP">The Intellectual Property that the HeroClix map being created belongs to.</param>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="rows">The number of rows the map will have.</param>
        /// <param name="columns">The number of columns the map will have.</param>
        public IndoorOutdoorMap(IntellectualProperty IP, string setName, string mapName, int rows, int columns)
            : base(IP, setName, mapName, MapType.IndoorOutdoor, rows, columns)
        {
            // no op
        }

        /// <summary>
        /// Creates an Indoor/Outdoor HeroClix map using the specified 2D array of Tiles.
        /// </summary>
        /// <param name="IP">The Intellectual Property that the HeroClix map being created belongs to.</param>
        /// <param name="setName">The name of the set that the HeroClix map being created belongs to.</param>
        /// <param name="mapName">The name of the HeroClix map being created.</param>
        /// <param name="tiles">The 2D array of Tiles which make up the map.</param>
        public IndoorOutdoorMap(IntellectualProperty IP, string setName, string mapName, Tile[,] mapTiles)
            : base(IP, setName, mapName, MapType.IndoorOutdoor, mapTiles)
        {
            // no op
        }

        /// <summary>
        /// Returns the 2d array of Tiles for a Map if they are valid, otherwise throws an Exception.
        /// </summary>
        /// <param name="tiles">The 2D Tile array to validate.</param>
        /// <returns>A valid 2D array of Tiles for a Map.</returns>
        protected override Tile[,] ValidateTiles(Tile[,] tiles)
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
            return tiles;
        }
    }
}
