using HeroClix.Maps.Enums;

namespace HeroClix.Maps
{
    public class FireMarker : Marker
    {
        public FireMarker(IGameElement creator)
            : base(creator)
        {
            this.markerName = "Fire";
            this.terrainType = TerrainType.Blocking;
        }
    }
}
