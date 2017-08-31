using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Map
{
    public abstract class Marker : IMarker
    {
        private IGameElement creator;
        protected TerrainType terrainType;

        protected Marker()
        {
            creator = new HeroClixCharacter();
        }

        protected Marker(IGameElement _creator)
        {
            creator = _creator;
        }

        public TerrainType MyTerrainType
        {
            get
            {
                return this.terrainType;
            }
        }
    }
}
