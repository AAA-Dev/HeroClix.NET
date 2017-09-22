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
            HeroClixMap.MapDetails fiveByFiveDetails =
                new HeroClixMap.MapDetails(IntellectualProperty.Other, "TestSet", "5x5", MapType.Outdoor);
            HeroClixMap fiveByFiveMap = new HeroClixMap(fiveByFiveDetails, 5, 5);
            HeroClixMap twoByTwoMap;

            Tile[,] tiles = new Tile[,]{
                {new Tile(), new Tile(TerrainType.Hindering)},
                {new Tile(TerrainType.Blocking), new Tile()}
            };

            HeroClixMap.MapDetails twoByTwoDetails =
                new HeroClixMap.MapDetails(IntellectualProperty.Other, "TestSet", "2x2", MapType.Indoor);
            twoByTwoMap = new HeroClixMap(twoByTwoDetails, tiles);

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

            HeroClixMap.MapDetails mapDetails =
                new HeroClixMap.MapDetails(IntellectualProperty.Other, "TestSet", "1x1_Indoor", MapType.Indoor);
            indoorMap = new HeroClixMap(mapDetails, tiles);
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

            HeroClixMap.MapDetails mapDetails =
                new HeroClixMap.MapDetails(IntellectualProperty.Other, "TestSet", "1x1_Outdoor", MapType.Outdoor);
            outdoorMap = new HeroClixMap(mapDetails, tiles);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There is no tile with an Indoor BorderType on an Indoor/Outdoor map.")]
        public void HeroClixMap_Create_IndoorOutdoor_Contains_TilesWithIndoorBorders()
        {
            HeroClixMap indoorOutdoorMap;
            Tile[,] tiles = new Tile[,]{
                {new Tile()}
            };

            HeroClixMap.MapDetails mapDetails =
                new HeroClixMap.MapDetails(IntellectualProperty.Other, "TestSet", "1x1_IndoorOutdoor", MapType.IndoorOutdoor);
            indoorOutdoorMap = new HeroClixMap(mapDetails, tiles);
        }
    }
}
