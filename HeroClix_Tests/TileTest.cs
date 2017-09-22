using HeroClix;
using HeroClix.Map;
using HeroClix.Map.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HeroClix_Tests
{
    [TestClass]
    public class TileTest
    {
        [TestMethod]
        public void Tile_Add_MultipleObjects_Succeeds()
        {
            Tile tile = new Tile();

            tile.AddGamePiece(new HeroClixObject());
            tile.AddGamePiece(new HeroClixObject());

            Assert.IsTrue(tile.GetGamePieces().Count == 2, "The second object was not added to the tile.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A second character is now occupying the same tile as another character.")]
        public void Tile_Add_TwoCharacters_Fails()
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
        public void Tile_With_SingleObject_IsOccupied_False()
        {
            Tile tile = new Tile();
            tile.AddGamePiece(new HeroClixObject());

            Assert.IsFalse(tile.IsOccupied);
        }

        [TestMethod]
        public void Tile_With_MultipleObjects_IsOccupied_False()
        {
            Tile tile = new Tile();
            tile.AddGamePiece(new HeroClixObject());
            tile.AddGamePiece(new HeroClixObject());

            Assert.IsFalse(tile.IsOccupied);
        }

        [TestMethod]
        public void Tile_CurrentTerrain_EmptyTerrainMarkerStack()
        {
            Tile clearTile = new Tile();
            Tile waterTile = new Tile(TerrainType.Water);

            Assert.IsTrue(clearTile.GetTerrainType() == TerrainType.Clear);
            Assert.IsTrue(waterTile.GetTerrainType() == TerrainType.Water);
        }

        [TestMethod]
        public void Tile_CurrentTerrain_NonEmptyTerrainMarkerStack()
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

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "An invalid marker was placed on a tile of blocking terrain.")]
        public void Tile_AddMarker_ToBlockingTerrain_Fails()
        {
            Tile tile = new Tile(TerrainType.Blocking);
            HeroClixCharacter character = new HeroClixCharacter();

            tile.AddMarker(new SmokeMarker(character));
        }

        [TestMethod]
        public void Tile_AddMarker_Clear_ToBlockingTerrain()
        {
            Tile tile = new Tile(TerrainType.Blocking);
            HeroClixCharacter character = new HeroClixCharacter();

            tile.AddMarker(new ClearMarker(character));

            Assert.IsTrue(tile.GetTerrainType() == TerrainType.Clear);
        }

        [TestMethod]
        public void Tile_AddMarker_Debris_ToBlockingTerrain()
        {
            Tile tile = new Tile(TerrainType.Blocking);
            HeroClixCharacter character = new HeroClixCharacter();

            tile.AddMarker(new DebrisMarker(character));

            Assert.IsTrue(tile.GetTerrainType() == TerrainType.Hindering);
        }

        [TestMethod]
        public void BorderDetails_Borders_CannotBeNull_True()
        {
            HeroClix.Map.Tile.BorderDetails allNull = new HeroClix.Map.Tile.BorderDetails();

            Tile tile = new Tile(allNull);
            Assert.IsNotNull(tile.GetBorderDetails().Top);
            Assert.IsNotNull(tile.GetBorderDetails().Right);
            Assert.IsNotNull(tile.GetBorderDetails().Bottom);
            Assert.IsNotNull(tile.GetBorderDetails().Left);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The Top border of a tile contains duplicate BorderTypes.")]
        public void BorderDetails_Borders_MustHaveUniqueBorderTypes()
        {
            HeroClix.Map.Tile.BorderDetails borders = new HeroClix.Map.Tile.BorderDetails();

            borders.Top = new System.Collections.Generic.List<BorderType>(){
                BorderType.Wall,
                BorderType.Wall
            };

            Tile tile = new Tile(borders);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Wall and a Door share the same border on a Tile.")]
        public void BorderDetails_Wall_And_Door_CannotShareABorder()
        {
            HeroClix.Map.Tile.BorderDetails borders = new HeroClix.Map.Tile.BorderDetails();

            borders.Top = new System.Collections.Generic.List<BorderType>(){
                BorderType.Wall,
                BorderType.Door
            };

            Tile tile = new Tile(borders);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Wall and a Window share the same border on a Tile.")]
        public void BorderDetails_Wall_And_Window_CannotShareABorder()
        {
            HeroClix.Map.Tile.BorderDetails borders = new HeroClix.Map.Tile.BorderDetails();

            borders.Top = new System.Collections.Generic.List<BorderType>(){
                BorderType.Wall,
                BorderType.Window
            };

            Tile tile = new Tile(borders);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Wall and an ElevationChange share the same border on a Tile.")]
        public void BorderDetails_Wall_And_ElevationChange_CannotShareABorder()
        {
            HeroClix.Map.Tile.BorderDetails borders = new HeroClix.Map.Tile.BorderDetails();

            borders.Top = new System.Collections.Generic.List<BorderType>(){
                BorderType.Wall,
                BorderType.ElevationChange
            };

            Tile tile = new Tile(borders);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A Window and a Door share the same border on a Tile.")]
        public void BorderDetails_Window_And_Door_CannotShareABorder()
        {
            HeroClix.Map.Tile.BorderDetails borders = new HeroClix.Map.Tile.BorderDetails();

            borders.Top = new System.Collections.Generic.List<BorderType>(){
                BorderType.Window,
                BorderType.Door
            };

            Tile tile = new Tile(borders);
        }

    }
}
