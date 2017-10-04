using HeroClix;
using HeroClix.Map;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroClix.Map.Enums;
using System.Collections.Generic;

namespace HeroClix_Tests
{
    [TestClass]
    public class HeroClixMapFactoryTest
    {
        string setName;
        string mapName;
        IntellectualProperty IpForTests;
        IHeroClixMapFactory mapFactory;

        [TestInitialize]
        public void InitializeTests()
        {
            setName = "TestSet";
            mapName = "TestMap";
            IpForTests = IntellectualProperty.Marvel;
            mapFactory = new HeroClixMapFactory(IpForTests);
        }

        [TestMethod]
        public void HeroClixMapFactory_Create_Default_IndoorMap()
        {
            var myMap = mapFactory.CreateIndoorMap(setName, mapName);

            Assert.IsTrue(myMap.IP == IpForTests);
            Assert.IsTrue(myMap.Set == setName);
            Assert.IsTrue(myMap.Name == mapName);
            Assert.IsTrue(myMap.MapType == MapType.Indoor);
            Assert.IsTrue(myMap.GetTiles().LongLength == 384);
        }

        [TestMethod]
        public void HeroClixMapFactory_Create_Default_OutdoorMap()
        {
            var myMap = mapFactory.CreateOutdoorMap(setName, mapName);

            Assert.IsTrue(myMap.IP == IpForTests);
            Assert.IsTrue(myMap.Set == setName);
            Assert.IsTrue(myMap.Name == mapName);
            Assert.IsTrue(myMap.MapType == MapType.Outdoor);
            Assert.IsTrue(myMap.GetTiles().LongLength == 384);
        }

        [TestMethod]
        public void HeroClixMapFactory_Create_Default_IndoorOutdoorMap()
        {
            var myMap = mapFactory.CreateIndoorOutdoorMap(setName, mapName);

            Assert.IsTrue(myMap.IP == IpForTests);
            Assert.IsTrue(myMap.Set == setName);
            Assert.IsTrue(myMap.Name == mapName);
            Assert.IsTrue(myMap.MapType == MapType.IndoorOutdoor);
            Assert.IsTrue(myMap.GetTiles().LongLength == 384);
        }

        [TestMethod]
        public void HeroClixMapFactory_Create_IndoorMap_CustomSize()
        {
            var myMap = mapFactory.CreateIndoorMap(setName, mapName, 5, 5);

            Assert.IsTrue(myMap.IP == IpForTests);
            Assert.IsTrue(myMap.Set == setName);
            Assert.IsTrue(myMap.Name == mapName);
            Assert.IsTrue(myMap.MapType == MapType.Indoor);
            Assert.IsTrue(myMap.GetTiles().LongLength == 25);
        }

        [TestMethod]
        public void HeroClixMapFactory_Create_OutdoorMap_CustomSize()
        {
            var myMap = mapFactory.CreateOutdoorMap(setName, mapName, 5, 5);

            Assert.IsTrue(myMap.IP == IpForTests);
            Assert.IsTrue(myMap.Set == setName);
            Assert.IsTrue(myMap.Name == mapName);
            Assert.IsTrue(myMap.MapType == MapType.Outdoor);
            Assert.IsTrue(myMap.GetTiles().LongLength == 25);
        }

        [TestMethod]
        public void HeroClixMapFactory_Create_IndoorOutdoorMap_CustomSize()
        {
            var myMap = mapFactory.CreateIndoorOutdoorMap(setName, mapName, 5, 5);

            Assert.IsTrue(myMap.IP == IpForTests);
            Assert.IsTrue(myMap.Set == setName);
            Assert.IsTrue(myMap.Name == mapName);
            Assert.IsTrue(myMap.MapType == MapType.IndoorOutdoor);
            Assert.IsTrue(myMap.GetTiles().LongLength == 25);
        }

        [TestMethod]
        public void HeroClixMapFactory_Create_IndoorMap_CustomTiles()
        {
            Tile[,] myTiles = new Tile[,]{
                { new Tile(), new Tile() },
                { new Tile(), new Tile() }
            };

            var myMap = mapFactory.CreateIndoorMap(setName, mapName, myTiles);

            Assert.IsTrue(myMap.IP == IpForTests);
            Assert.IsTrue(myMap.Set == setName);
            Assert.IsTrue(myMap.Name == mapName);
            Assert.IsTrue(myMap.MapType == MapType.Indoor);
            Assert.IsTrue(myMap.GetTiles().LongLength == 4);
        }

        [TestMethod]
        public void HeroClixMapFactory_Create_OutdoorMap_CustomTiles()
        {
            Tile[,] myTiles = new Tile[,]{
                { new Tile(), new Tile() },
                { new Tile(), new Tile() }
            };

            var myMap = mapFactory.CreateOutdoorMap(setName, mapName, myTiles);

            Assert.IsTrue(myMap.IP == IpForTests);
            Assert.IsTrue(myMap.Set == setName);
            Assert.IsTrue(myMap.Name == mapName);
            Assert.IsTrue(myMap.MapType == MapType.Outdoor);
            Assert.IsTrue(myMap.GetTiles().LongLength == 4);
        }

        [TestMethod]
        public void HeroClixMapFactory_Create_IndoorOutdoorMap_CustomTiles()
        {
            Tuple<List<BorderType>, List<BorderType>, List<BorderType>, List<BorderType>> borderWithIndoorTop;
            borderWithIndoorTop =
                Tuple.Create(
                        new List<BorderType>() { BorderType.Indoor },
                        new List<BorderType>(),
                        new List<BorderType>(),
                        new List<BorderType>());

            Tile[,] myTiles = new Tile[,]{
                { new Tile(), new Tile(borderWithIndoorTop) },
                { new Tile(), new Tile() }
            };

            var myMap = mapFactory.CreateIndoorOutdoorMap(setName, mapName, myTiles);

            Assert.IsTrue(myMap.IP == IpForTests);
            Assert.IsTrue(myMap.Set == setName);
            Assert.IsTrue(myMap.Name == mapName);
            Assert.IsTrue(myMap.MapType == MapType.IndoorOutdoor);
            Assert.IsTrue(myMap.GetTiles().LongLength == 4);
        }
    }
}
