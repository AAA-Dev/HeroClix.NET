using HeroClix;
using HeroClix.GameElements.GamePieces.Characters;
using HeroClix.Maps;
using HeroClix.Maps.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HeroClix_Tests
{
    [TestClass]
    public class TileTest
    {
        [TestMethod]
        public void Tile_Add_MultipleObjects_Succeeds()
        {
            Tile tile = new Tile();

            tile.AddGamePiece(new StandardHeroClixObject());
            tile.AddGamePiece(new SpecialHeroClixObject());

            Assert.IsTrue(tile.GetGamePieces().Count == 2, "The second object was not added to the tile.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A second character is now occupying the same tile as another character.")]
        public void Tile_Add_TwoStandardCharacters_Fails()
        {
            Tile tile = new Tile();

            tile.AddGamePiece(new StandardHeroClixCharacter());
            tile.AddGamePiece(new StandardHeroClixCharacter());
        }

        [TestMethod]
        public void Tile_Empty_IsOccupied_False()
        {
            Tile tile = new Tile();

            Assert.IsFalse(tile.IsOccupied, "A tile is occupied when it should be empty.");
        }

        [TestMethod]
        public void Tile_With_SingleStandardCharacter_IsOccupied_True()
        {
            Tile tile = new Tile();
            tile.AddGamePiece(new StandardHeroClixCharacter());

            Assert.IsTrue(tile.IsOccupied, "A tile with a character in it should be considered occupied.");
        }

        [TestMethod]
        public void Tile_With_SingleObject_IsOccupied_False()
        {
            Tile tile = new Tile();
            tile.AddGamePiece(new StandardHeroClixObject());

            Assert.IsFalse(tile.IsOccupied, "A tile with only an object in it should not be considered occupied.");
        }

        [TestMethod]
        public void Tile_With_MultipleObjects_IsOccupied_False()
        {
            Tile tile = new Tile();
            tile.AddGamePiece(new StandardHeroClixObject());
            tile.AddGamePiece(new SpecialHeroClixObject());

            Assert.IsFalse(tile.IsOccupied, "A tile with multiple objects in it should not be considered occupied.");
        }

        [TestMethod]
        public void Tile_CurrentTerrain_EmptyTerrainMarkerStack()
        {
            Tile clearTile = new Tile();
            Tile waterTile = new Tile(TerrainType.Water);

            Assert.IsTrue(clearTile.GetTerrainType() == TerrainType.Clear, "A tile with no terrain markers should return it's default terrain type: Clear");
            Assert.IsTrue(waterTile.GetTerrainType() == TerrainType.Water, "A tile with no terrain markers should return it's default terrain type: Water");
        }

        [TestMethod]
        public void Tile_CurrentTerrain_NonEmptyTerrainMarkerStack()
        {
            Tile tile = new Tile();
            HeroClixCharacter character = new StandardHeroClixCharacter();

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

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "An invalid marker was placed on a tile of blocking terrain.")]
        public void Tile_AddMarker_ToBlockingTerrain_Fails()
        {
            Tile tile = new Tile(TerrainType.Blocking);
            HeroClixCharacter character = new StandardHeroClixCharacter();

            tile.AddMarker(new SmokeMarker(character));
        }

        [TestMethod]
        public void Tile_AddMarker_Clear_ToBlockingTerrain()
        {
            Tile tile = new Tile(TerrainType.Blocking);
            HeroClixCharacter character = new StandardHeroClixCharacter();

            tile.AddMarker(new ClearMarker(character));

            Assert.IsTrue(tile.GetTerrainType() == TerrainType.Clear, "The tile's terrain type did not change.");
        }

        [TestMethod]
        public void Tile_AddMarker_Debris_ToBlockingTerrain()
        {
            Tile tile = new Tile(TerrainType.Blocking);
            HeroClixCharacter character = new StandardHeroClixCharacter();

            tile.AddMarker(new DebrisMarker(character));

            Assert.IsTrue(tile.GetTerrainType() == TerrainType.Hindering, "The tile's terrain type did not change.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The Top border of a tile contains duplicate BorderTypes.")]
        public void BorderDetails_Borders_MustHaveUniqueBorderTypes()
        {
            Tuple<List<BorderType>, List<BorderType>, List<BorderType>, List<BorderType>> borders =
                Tuple.Create(
                    new List<BorderType> { BorderType.Wall, BorderType.Wall },
                    new List<BorderType>(),
                    new List<BorderType>(),
                    new List<BorderType>());

            Tile tile = new Tile(borders);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Wall and a Door share the same border on a Tile.")]
        public void BorderDetails_Wall_And_Door_CannotShareABorder()
        {
            Tuple<List<BorderType>, List<BorderType>, List<BorderType>, List<BorderType>> borders =
                Tuple.Create(
                    new List<BorderType> { BorderType.Wall, BorderType.Door },
                    new List<BorderType>(),
                    new List<BorderType>(),
                    new List<BorderType>());

            Tile tile = new Tile(borders);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Wall and a Window share the same border on a Tile.")]
        public void BorderDetails_Wall_And_Window_CannotShareABorder()
        {
            Tuple<List<BorderType>, List<BorderType>, List<BorderType>, List<BorderType>> borders =
                Tuple.Create(
                    new List<BorderType> { BorderType.Wall, BorderType.Window },
                    new List<BorderType>(),
                    new List<BorderType>(),
                    new List<BorderType>());

            Tile tile = new Tile(borders);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Wall and an ElevationChange share the same border on a Tile.")]
        public void BorderDetails_Wall_And_ElevationChange_CannotShareABorder()
        {
            Tuple<List<BorderType>, List<BorderType>, List<BorderType>, List<BorderType>> borders =
                Tuple.Create(
                    new List<BorderType> { BorderType.Wall, BorderType.ElevationChange },
                    new List<BorderType>(),
                    new List<BorderType>(),
                    new List<BorderType>());

            Tile tile = new Tile(borders);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Window and a Door share the same border on a Tile.")]
        public void BorderDetails_Window_And_Door_CannotShareABorder()
        {
            Tuple<List<BorderType>, List<BorderType>, List<BorderType>, List<BorderType>> borders =
                Tuple.Create(
                    new List<BorderType> { BorderType.Window, BorderType.Door },
                    new List<BorderType>(),
                    new List<BorderType>(),
                    new List<BorderType>());

            Tile tile = new Tile(borders);
        }

    }
}
