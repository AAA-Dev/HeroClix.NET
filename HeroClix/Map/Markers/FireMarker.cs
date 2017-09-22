using HeroClix.Map.Enums;

namespace HeroClix.Map
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
