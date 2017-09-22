using HeroClix.GameElements;
using HeroClix.Map.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Map
{
    /// <summary>
    /// A single Tile in a HeroClix Map.
    /// </summary>
    public class Tile
    {
        private TerrainType defaultTerrainType;
        private BorderDetails border;
        private int elevationLevel;
        private List<IGamePiece> gamePieces;
        private Stack<IMarker> markers;

        /// <summary>
        /// Creates a single, unoccupied, clear tile.
        /// </summary>
        public Tile()
        {
            defaultTerrainType = TerrainType.Clear;
            border = ValidateBorderDetails(new BorderDetails());
            markers = new Stack<IMarker>();
            elevationLevel = 1;
            gamePieces = new List<IGamePiece>();
        }

        /// <summary>
        /// Creates a single, unoccupied, clear tile with explicitly defined borders.
        /// </summary>
        /// <param name="top">The BorderDetails of the tile.</param>
        public Tile(BorderDetails borderDetails)
            : this()
        {
            border = ValidateBorderDetails(borderDetails);
        }

        /// <summary>
        /// Creates a single, unoccupied tile of the given TerrainType.
        /// </summary>
        /// <param name="type">The TerrainType of the tile.</param>
        public Tile(TerrainType type)
            : this()
        {
            defaultTerrainType = type;
        }

        /// <summary>
        /// Creates a single, unoccupied tile of the given TerrainType with explicitly defined borders.
        /// </summary>
        /// <param name="type">The TerrainType of the tile.</param>
        /// <param name="borderDetails">The BorderDetails of the tile.</param>
        public Tile(TerrainType type, BorderDetails borderDetails)
            : this(type)
        {
            border = ValidateBorderDetails(borderDetails);
        }

        /// <summary>
        /// Creates a single, clear, unoccupied tile at the given ElevationLevel.
        /// </summary>
        /// <param name="elevation">The ElevationLevel of the tile.</param>
        public Tile(int elevation)
            : this()
        {
            elevationLevel = elevation;
        }

        /// <summary>
        /// Creates a single, clear, unoccupied tile at the given ElevationLevel with explicitly defined borders.
        /// </summary>
        /// <param name="elevation">The ElevationLevel of the tile.</param>
        /// <param name="borderDetails">The BorderDetails of the tile.</param>
        public Tile(int elevation, BorderDetails borderDetails)
            : this(elevation)
        {
            border = ValidateBorderDetails(borderDetails);
        }

        /// <summary>
        /// Creates a single, unoccupied tile of the given TerrainType at the given ElevationLevel.
        /// </summary>
        /// <param name="type">The TerrainType of the tile.</param>
        /// <param name="elevation">The ElevationLevel of the tile.</param>
        public Tile(TerrainType type, int elevation)
            : this(type)
        {
            elevationLevel = elevation;
        }

        /// <summary>
        /// Creates a single, unoccupied tile of the given TerrainType at the given ElevationLevel with border explicitly defined.
        /// </summary>
        /// <param name="type">The TerrainType of the tile.</param>
        /// <param name="elevation">The ElevationLevel of the tile.</param>
        /// <param name="borderDetails">The BorderDetails of the tile.</param>
        public Tile(TerrainType type, int elevation, BorderDetails borderDetails)
            : this(type, elevation)
        {
            border = ValidateBorderDetails(borderDetails);
        }

        /// <summary>
        /// Returns whether the tile is occupied by a character.
        /// </summary>
        public bool IsOccupied
        {
            get
            {
                return gamePieces.Count(x => x.GetType().Equals(typeof(HeroClixCharacter))) > 0;
            }
        }

        /// <summary>
        /// Returns the current TerrainType of the Tile.
        /// </summary>
        /// <returns>The Tile's current TerrainType.</returns>
        public TerrainType GetTerrainType()
        {
            if (!markers.Any())
            {
                return defaultTerrainType;
            }
            return markers.Peek().GetTerrainType;
        }

        /// Adds a specified Marker to the tile.
        /// </summary>
        /// <param name="type">The type of Marker to add.</param>
        public void AddMarker(IMarker marker)
        {
            if ((!markers.Any() && defaultTerrainType.Equals(TerrainType.Blocking))
                || markers.Any() && markers.Peek().GetTerrainType.Equals(TerrainType.Blocking))
            {
                if (!marker.GetType().Equals(typeof(ClearMarker)) && !marker.GetType().Equals(typeof(DebrisMarker)))
                {
                    throw new InvalidOperationException("A " + marker.GetName() + " marker cannot be placed on Blocking terrain.");
                }
            }

            markers.Push(marker);
        }

        /// <summary>
        /// Removes the topmost TerrainMarker to the tile.
        /// </summary>
        public IMarker RemoveMarker()
        {
            return markers.Pop();
        }

        /// <summary>
        /// Returns a list of GamePieces currently occupying the tile.
        /// </summary>
        /// <returns>a list of GamePieces</returns>
        public List<IGamePiece> GetGamePieces()
        {
            return gamePieces;
        }

        /// <summary>
        /// Adds a specified game piece to a tile.
        /// </summary>
        /// <param name="element">The game piece to add to the tile.</param>
        public void AddGamePiece(IGamePiece element)
        {
            if (element is HeroClixCharacter
                && gamePieces.Count(x => x.GetType().Equals(typeof(HeroClixCharacter))) > 0)
            {
                throw new InvalidOperationException("A character is already occupying this tile.");
            }
            gamePieces.Add(element);
        }

        /// <summary>
        /// Returns the BorderDetails of the Tile.
        /// </summary>
        /// <returns>The BorderDetails of the Tile.</returns>
        public BorderDetails GetBorderDetails()
        {
            return border;
        }

        /// <summary>
        /// Returns a valid BorderDetails object for the Tile. Throws an exception if there is an invalid border present.
        /// </summary>
        /// <param name="bordersToValidate">The borders to validate.</param>
        /// <exception cref="InvalidOperationException">Thrown if there is an invalid border in "bordersToValidate".</exception>
        /// <returns>A validated BorderDetails object.</returns>
        private BorderDetails ValidateBorderDetails(BorderDetails bordersToValidate)
        {
            bordersToValidate.Top = ValidateBorder(bordersToValidate.Top);
            bordersToValidate.Right = ValidateBorder(bordersToValidate.Right);
            bordersToValidate.Bottom = ValidateBorder(bordersToValidate.Bottom);
            bordersToValidate.Left = ValidateBorder(bordersToValidate.Left);

            return bordersToValidate;
        }

        /// <summary>
        /// Returns a valid List of BorderTypes for one side of a Tile. Throws an exception if the border is invalid.
        /// </summary>
        /// <param name="borderToValidate">The border to validate.</param>
        /// /// <exception cref="InvalidOperationException">Thrown if the border is invalid.</exception>
        /// <returns>A validated List of BorderTypes for the side of a Tile</returns>
        private List<BorderType> ValidateBorder(List<BorderType> borderToValidate)
        {
            if (borderToValidate == null)
            {
                return new List<BorderType>();
            }

            if (borderToValidate.Count != borderToValidate.Distinct().Count())
            {
                throw new InvalidOperationException("There exists a Tile where the borders on a single side of the tile are not unique.");
            }

            if (borderToValidate.Exists(x => x == BorderType.Wall) && borderToValidate.Exists(x => x == BorderType.Door))
            {
                throw new InvalidOperationException("A Wall cannot share a border with a Door.");
            }

            if (borderToValidate.Exists(x => x == BorderType.Wall) && borderToValidate.Exists(x => x == BorderType.Window))
            {
                throw new InvalidOperationException("A Wall cannot share a border with a Window.");
            }

            if (borderToValidate.Exists(x => x == BorderType.Wall) && borderToValidate.Exists(x => x == BorderType.ElevationChange))
            {
                throw new InvalidOperationException("A Wall cannot share a border with an ElevationChange.");
            }

            if (borderToValidate.Exists(x => x == BorderType.Window) && borderToValidate.Exists(x => x == BorderType.Door))
            {
                throw new InvalidOperationException("A Window cannot share a border with a Door.");
            }
            return borderToValidate;
        }

        /// <summary>
        /// A struct which represents the borders of a Tile.
        /// </summary>
        public struct BorderDetails
        {
            public List<BorderType> Top { get; set; }
            public List<BorderType> Right { get; set; }
            public List<BorderType> Bottom { get; set; }
            public List<BorderType> Left { get; set; }
        }
    }
}
