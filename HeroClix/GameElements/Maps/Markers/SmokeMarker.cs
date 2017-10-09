using HeroClix.Maps.Enums;

namespace HeroClix.Maps
{
    public class SmokeMarker : Marker
    {
        public SmokeMarker(IGameElement creator)
            : base(creator)
        {
            this.markerName = "Smoke";
            this.terrainType = TerrainType.Hindering;
        }
    }
}
