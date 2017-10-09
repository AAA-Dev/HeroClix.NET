using HeroClix.Maps.Enums;

namespace HeroClix.Maps
{
    public class DebrisMarker : Marker
    {
        public DebrisMarker(IGameElement creator)
            : base(creator)
        {
            this.markerName = "Debris";
            this.terrainType = TerrainType.Hindering;
        }
    }
}
