using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroClix;
using HeroClix.Map;

namespace HeroClix_Tests
{
    [TestClass]
    public class TileTest
    {
        [TestMethod]
        public void Tile_CanAddMultipleObjects()
        {
            Tile tile = new Tile();

            tile.AddGamePiece(new HeroClixObject());
            tile.AddGamePiece(new HeroClixObject());

            Assert.IsTrue(tile.GetGamePieces().Count == 2, "The second object was not added to the tile.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A second character is now occupying the same tile as another character.")]
        public void Tile_CanNotAddTwoCharacters()
        {
            Tile tile = new Tile();

            tile.AddGamePiece(new HeroClixCharacter());
            tile.AddGamePiece(new HeroClixCharacter());
        }

        [TestMethod]
        public void Tile_Empty_IsOccupied_False()
        {
            Tile tile = new Tile();

            Assert.IsFalse(tile.IsOccupied);
        }

        [TestMethod]
        public void Tile_With_SingleCharacter_IsOccupied_True()
        {
            Tile tile = new Tile();
            tile.AddGamePiece(new HeroClixCharacter());

            Assert.IsTrue(tile.IsOccupied);
        }

        [TestMethod]
        public void Tile_CorrectlyDeterminesCurrentTerrain_EmptyTerrainMarkerStack()
        {
            Tile clearTile = new Tile();
            Tile waterTile = new Tile(TerrainType.Water);
            
            Assert.IsTrue(clearTile.GetTerrainType() == TerrainType.Clear);
            Assert.IsTrue(waterTile.GetTerrainType() == TerrainType.Water);
        }

        [TestMethod]
        public void Tile_CorrectlyDeterminesCurrentTerrain_UsingTerrainMarkerStack()
        {
            Tile tile = new Tile();
            HeroClixCharacter character = new HeroClixCharacter();

            tile.AddMarker(new SmokeMarker(character));
            tile.AddMarker(new WaterMarker(character));
            tile.AddMarker(new WaterMarker(character));
            tile.AddMarker(new SmokeMarker(character));

            Assert.IsTrue(tile.GetTerrainType() == TerrainType.Hindering);
            tile.RemoveMarker();
            Assert.IsTrue(tile.GetTerrainType() == TerrainType.Water);
            tile.RemoveMarker();
            Assert.IsTrue(tile.GetTerrainType() == TerrainType.Water);
            tile.RemoveMarker();
            Assert.IsTrue(tile.GetTerrainType() == TerrainType.Hindering);
            tile.RemoveMarker();
            Assert.IsTrue(tile.GetTerrainType() == TerrainType.Clear);
        }
    }
}
