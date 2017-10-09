using HeroClix.Maps.Enums;

namespace HeroClix.Maps
{
    public class BarrierMarker : Marker
    {
        public BarrierMarker(IGameElement creator)
            : base(creator)
        {
            this.markerName = "Barrier";
            this.terrainType = TerrainType.Blocking;
        }
    }
}
