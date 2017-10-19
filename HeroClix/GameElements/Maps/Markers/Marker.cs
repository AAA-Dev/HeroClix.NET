using HeroClix.GameElements;
using HeroClix.GameElements.GamePieces.Characters;
using HeroClix.Maps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Maps
{
    public abstract class Marker : IMarker, IGamePiece
    {
        private IGameElement creator;
        protected string markerName;
        protected TerrainType terrainType;

        protected Marker()
        {
            creator = new StandardHeroClixCharacter();
        }

        protected Marker(IGameElement _creator)
        {
            creator = _creator;
        }

        public string GetName()
        {
            return this.markerName;
        }

        public TerrainType GetTerrainType
        {
            get
            {
                return this.terrainType;
            }
        }
    }
}
