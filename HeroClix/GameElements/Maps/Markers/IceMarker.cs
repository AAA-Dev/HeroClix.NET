using HeroClix.Maps.Enums;

namespace HeroClix.Maps
{
    public class IceMarker : Marker
    {
        public IceMarker(IGameElement creator)
            : base(creator)
        {
            this.markerName = "Ice";
            this.terrainType = TerrainType.Blocking;
        }
    }
}
