using HeroClix;
using HeroClix.Map;
using HeroClix.Map.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HeroClix_Tests
{
    [TestClass]
    public class HeroClixMapTest
    {
        [TestMethod]
        public void HeroClixMap_Create_CorrectDimensions()
        {
            IHeroClixMap defaultIndoorMap = new IndoorMap();

            IHeroClixMap fiveByFiveMap = new OutdoorMap(IntellectualProperty.Other, "TestSet", "5x5", 5, 5);
            IHeroClixMap twoByTwoMap;

            Tile[,] tiles = new Tile[,]{
                {new Tile(), new Tile(TerrainType.Hindering)},
                {new Tile(TerrainType.Blocking), new Tile()}
            };

            twoByTwoMap = new IndoorMap(IntellectualProperty.Other, "TestSet", "2x2", tiles);

            Assert.IsTrue(defaultIndoorMap.GetTiles().Length == 384);
            Assert.IsTrue(fiveByFiveMap.GetTiles().Length == 25);
            Assert.IsTrue(twoByTwoMap.GetTiles().Length == 4);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Tile on an Indoor map has an Indoor BorderType.")]
        public void HeroClixMap_Create_Indoor_CanNotContain_TilesWithIndoorBorders()
        {
            IHeroClixMap indoorMap;
            Tuple<List<BorderType>, List<BorderType>, List<BorderType>, List<BorderType>> borders =
                Tuple.Create(
                    new List<BorderType> { BorderType.Indoor },
                    new List<BorderType>(),
                    new List<BorderType>(),
                    new List<BorderType>());
            Tile[,] tiles = new Tile[,]{
                {new Tile(borders)}
            };

            indoorMap = new IndoorMap(IntellectualProperty.Other, "TestSet", "1x1_Indoor", tiles);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Tile on an Outdoor map has an Indoor BorderType.")]
        public void HeroClixMap_Create_Outdoor_CanNotContain_TilesWithIndoorBorders()
        {
            IHeroClixMap outdoorMap;
            Tuple<List<BorderType>, List<BorderType>, List<BorderType>, List<BorderType>> borders =
                Tuple.Create(
                    new List<BorderType>(),
                    new List<BorderType>(),
                    new List<BorderType>(),
                    new List<BorderType> { BorderType.Indoor });
            Tile[,] tiles = new Tile[,]{
                {new Tile(borders)}
            };

            outdoorMap = new OutdoorMap(IntellectualProperty.Other, "TestSet", "1x1_Outdoor", tiles);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There is no tile with an Indoor BorderType on an Indoor/Outdoor map.")]
        public void HeroClixMap_Create_IndoorOutdoor_Contains_TilesWithIndoorBorders()
        {
            IHeroClixMap indoorOutdoorMap;
            Tile[,] tiles = new Tile[,]{
                {new Tile()}
            };

            indoorOutdoorMap = new IndoorOutdoorMap(IntellectualProperty.Other, "TestSet", "1x1_IndoorOutdoor", tiles);
        }
    }
}
