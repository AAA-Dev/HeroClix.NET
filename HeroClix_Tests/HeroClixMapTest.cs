using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroClix;
using HeroClix.Map;

namespace HeroClix_Tests
{
    [TestClass]
    public class HeroClixMapTest
    {
        [TestMethod]
        public void HeroClixMap_Create_CorrectDimensions()
        {
            HeroClixMap defaultMap = new HeroClixMap();
            HeroClixMap fiveByFiveMap = new HeroClixMap("5x5", MapType.Outdoor, IntellectualProperty.Other, 5, 5);
            HeroClixMap twoByTwoMap;

            Tile[,] tiles = new Tile[,]{
                {new Tile(), new Tile(TerrainType.Hindering)},
                {new Tile(TerrainType.Blocking), new Tile()}
            };

            twoByTwoMap = new HeroClixMap("2x2", MapType.Indoor, IntellectualProperty.Other, tiles);

            Assert.IsTrue(defaultMap.GetTiles().Length == 384);
            Assert.IsTrue(fiveByFiveMap.GetTiles().Length == 25);
            Assert.IsTrue(twoByTwoMap.GetTiles().Length == 4);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Tile on an Indoor map has an Indoor BorderType.")]
        public void HeroClixMap_Create_Indoor_CanNotContain_TilesWithIndoorBorders()
        {
            HeroClixMap indoorMap;
            HeroClix.Map.Tile.BorderDetails borders = new HeroClix.Map.Tile.BorderDetails();
            borders.Top = new System.Collections.Generic.List<BorderType> { BorderType.Indoor };
            Tile[,] tiles = new Tile[,]{
                {new Tile(borders)}
            };

            indoorMap = new HeroClixMap("1x1_Indoor", MapType.Indoor, IntellectualProperty.Other, tiles);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Tile on an Outdoor map has an Indoor BorderType.")]
        public void HeroClixMap_Create_Outdoor_CanNotContain_TilesWithIndoorBorders()
        {
            HeroClixMap outdoorMap;
            HeroClix.Map.Tile.BorderDetails borders = new HeroClix.Map.Tile.BorderDetails();
            borders.Left = new System.Collections.Generic.List<BorderType> { BorderType.Indoor };
            Tile[,] tiles = new Tile[,]{
                {new Tile(borders)}
            };

            outdoorMap = new HeroClixMap("1x1_Outdoor", MapType.Outdoor, IntellectualProperty.Other, tiles);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There is no tile with an Indoor BorderType on an Indoor/Outdoor map.")]
        public void HeroClixMap_Create_IndoorOutdoor_Contains_TilesWithIndoorBorders()
        {
            HeroClixMap indoorOutdoorMap;
            Tile[,] tiles = new Tile[,]{
                {new Tile()}
            };

            indoorOutdoorMap = new HeroClixMap("1x1_IndoorOutdoor", MapType.IndoorOutdoor, IntellectualProperty.Other, tiles);
        }
    }
}
