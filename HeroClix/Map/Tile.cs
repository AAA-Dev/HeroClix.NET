using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Map
{
    /// <summary>
    /// A single Tile in HeroClix Map.
    /// </summary>
    public class Tile
    {
        private TerrainType defaultTerrainType;
        private int elevationLevel;
        private List<IGameElement> gameElements;
        private Stack<IMarker> markers;

        /// <summary>
        /// Creates a single, unoccupied, clear tile.
        /// </summary>
        public Tile()
        {
            defaultTerrainType = TerrainType.Clear;
            markers = new Stack<IMarker>();
            elevationLevel = 1;
            gameElements = new List<IGameElement>();
        }

        /// <summary>
        /// Creates a single, unoccupied tile of the given TerrainType.
        /// </summary>
        /// <param name="type">The TerrainType of the tile.</param>
        public Tile(TerrainType type)
            :this()
        {
            defaultTerrainType = type;
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
        /// Creates a single, unoccupied tile of the given TerrainType at the given ElevationLevel.
        /// </summary>
        /// <param name="type">The TerrainType of the tile.</param>
        /// <param name="elevation">The ElevationLevel of the tile.</param>
        public Tile(TerrainType type, int elevation)
            :this(type)
        {
            elevationLevel = elevation;
        }

        /// <summary>
        /// Returns whether the tile is occupied by a character.
        /// </summary>
        public bool IsOccupied
        {
            get
            {
                return gameElements.Count(x => x.GetType().Equals(typeof(HeroClixCharacter))) > 0;
            }
        }

        /// <summary>
        /// Returns the current TerrainType of the Tile.
        /// </summary>
        /// <returns>The Tile's current TerrainType.</returns>
        public TerrainType GetTerrainType()
        {
            if(!markers.Any()){
                return defaultTerrainType;
            }
            return markers.Peek().MyTerrainType;
        }

        /// Adds a specified Marker to the tile.
        /// </summary>
        /// <param name="type">The type of Marker to add.</param>
        public void AddMarker(IMarker marker)
        {
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
        /// Returns a list of GameElements currently occupying the tile.
        /// </summary>
        /// <returns>a list of GameElements</returns>
        public List<IGameElement> GetGameElements()
        {
            return gameElements;
        }
        
        /// <summary>
        /// Adds a specified game element to a tile.
        /// </summary>
        /// <param name="element">The game element to add to the tile.</param>
        public void AddGameElement(IGameElement element)
        {
            if (element is HeroClixCharacter 
                && gameElements.Count(x => x.GetType().Equals(typeof(HeroClixCharacter))) > 0)
            {
                throw new ArgumentException("A character is already occupying this tile.");
            }
            gameElements.Add(element);
        }
    }
}
