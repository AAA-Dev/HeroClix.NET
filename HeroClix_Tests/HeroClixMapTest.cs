using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            HeroClixMap fiveByFiveMap = new HeroClixMap(5, 5);
            HeroClixMap twoByTwoMap;

            Tile[,] tiles = new Tile[,]{
                {new Tile(), new Tile(HeroClix.TerrainType.Hindering)},
                {new Tile(HeroClix.TerrainType.Blocking), new Tile()}
            };

            twoByTwoMap = new HeroClixMap(tiles);

            Assert.IsTrue(defaultMap.GetTiles().Length == 384);
            Assert.IsTrue(fiveByFiveMap.GetTiles().Length == 25);
            Assert.IsTrue(twoByTwoMap.GetTiles().Length == 4);
        }
    }
}
